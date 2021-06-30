using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using FilipeApp.Models;
using Newtonsoft.Json;
using ontoUcmd.Services;

namespace FilipeApp.Services
{
    public class DataService
    {
        public static void AddItem(PlacedItem item)
        {
            Global.PlacedItems.Add(item);
            Save();
        }

        public static void RemoveItem(PlacedItem item)
        {
            Global.PlacedItems.Remove(item);
            Save();
        }
        
        public static void Save()
        {
            string path = $"{Environment.CurrentDirectory}/data";
            string file = $"{path}/data.json";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            File.WriteAllText(file, JsonConvert.SerializeObject(Global.PlacedItems));
        }

        public static List<PlacedItem> Load()
        {
            string path = $"{Environment.CurrentDirectory}/data";
            string file = $"{path}/data.json";
            return JsonConvert.DeserializeObject<List<PlacedItem>>(File.ReadAllText(file));
        }

        public static async Task<byte[]> Build()
        {
            string path = $"{Environment.CurrentDirectory}/data/temp";
            string dataPath = $"{Environment.CurrentDirectory}/data";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            
            var graph = await SerializationService.ConvertToGraphData(Global.PlacedItems);
            SerializationService.BuildGraphData($"{path}/graph_en.json", graph);
            SerializationService.BuildLocationFile($"{path}/location.txt", graph);
            ConstellationLocationGenerator.Build($"{path}/location.txt", $"{path}/constellation-node-locations.json");
            
            if(File.Exists($"{dataPath}/output.zip"))
                File.Delete($"{dataPath}/output.zip");
            if(File.Exists($"{path}/imports.zip"))
                File.Delete($"{path}/imports.zip");
            
            await Task.Run(() => {
                ZipFile.CreateFromDirectory($"{Environment.CurrentDirectory}/wwwroot/imports", $"{path}/imports.zip");
            });
            await Task.Run(() => {
                ZipFile.CreateFromDirectory(path, $"{dataPath}/output.zip");
            });
            return await File.ReadAllBytesAsync($"{dataPath}/output.zip");
        }
        
    }
}