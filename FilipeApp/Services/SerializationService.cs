using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ConstellationEditor.Models;
using FilipeApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FilipeApp.Services
{
    public class SerializationService
    {

        public static async Task<GraphData> ConvertToGraphData(List<PlacedItem> elements) {
            List<EdgeItem> edgeItems = new List<EdgeItem>();
            foreach (var element in elements) {
                    foreach (var s in element.all_linked_node) { edgeItems.Add(new EdgeItem() { Object = element.name, predicate = "related", subject = s, weight = 2}); }
            }
            
            GraphData graphData = new GraphData() {
                Meta = new Meta() {generated = "Generated with FilipeApp", langage = "en"},
                Elements = elements, EdgeItems = edgeItems
            };

            return graphData;
        }

        public static void BuildGraphData(string buildPath, GraphData graphData)
        {
            JObject o = new JObject();
            JObject nodeElementArray = new JObject();
            
            foreach (var node in graphData.Elements)
            {
                nodeElementArray.Add(new JProperty(node.name, JObject.Parse(JsonConvert.SerializeObject(node))));
            }
            
            o["meta"] = JObject.Parse(JsonConvert.SerializeObject(graphData.Meta));
            o["nodes"] = nodeElementArray;
            o["edges"] = JArray.Parse(JsonConvert.SerializeObject(graphData.EdgeItems));
            
            File.WriteAllText(buildPath, o.ToString());
        }

        public static void BuildLocationFile(string buildPath, GraphData graphData)
        {
            string outputText = "";
            foreach (var element in graphData.Elements)
            {
                List<string> items = element.all_linked_node;
                int linkedCount = 0;
                if (items.Count > 0)
                    linkedCount = items.Count;
                outputText += $"element.{element.name}:{linkedCount};\n";
            }
            
            File.WriteAllText(buildPath, outputText);
        }
        
    }
}