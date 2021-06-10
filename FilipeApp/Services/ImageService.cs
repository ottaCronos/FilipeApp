using System;
using System.IO;
using System.Net;

namespace FilipeApp.Services
{
    public class ImageService
    {
        public static bool CheckUrl(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HEAD";
            bool exists;
            try {
                request.GetResponse();
                return true;
            } catch {
                return false;
            }
        }

        public static string ImportImage(string url)
        {
            var client = new WebClient();
            
            string path = $"{Environment.CurrentDirectory}/wwwroot/imports";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            
            Uri uri = new Uri(url);
            string filename = Path.GetFileName(uri.LocalPath);
            
            client.DownloadFileTaskAsync(url,$"{path}/{filename}");
            return $"/imports/{filename}";
        }
    }
}