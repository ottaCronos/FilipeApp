using System.Collections.Generic;
using FilipeApp.Models;
using Newtonsoft.Json;

namespace ConstellationEditor.Models
{
    public class GraphData
    {
        public Meta Meta { get; set; }
        public List<PlacedItem> Elements { get; set; }
        public List<EdgeItem> EdgeItems { get; set; }
    }

    public class Meta
    {
        public string langage { get; set; }
        public string generated { get; set; }
    }

    public class NodeElement
    {
        public string name { get; set; }
        public string type { get; set; }
        public string label { get; set; }
        public NodeMeta meta { get; set; }
    }

    public class NodeMeta
    {
        public NodeIcon icon { get; set; }
        public string description { get; set; }
        public string list { get; set; }
        public int year { get; set; }
        public bool multinational { get; set; }
        public string link { get; set; }
        public List<NodeImage> images { get; set; }
        public List<NodeVideo> videos { get; set; }
        public string sustainability { get; set; }
    }

    public class NodeIcon
    {
        public string small { get; set; }
        public string large { get; set; }
    }

    public class NodeImage
    {
        public string url { get; set; }
        public string copyright { get; set; }
        public string title { get; set; }
    }
    
    public class NodeVideo
    {
        public string url { get; set; }
        public string copyright { get; set; }
        public string title { get; set; }
    }

    public class EdgeItem
    {
        public string subject { get; set; }
        public string predicate { get; set; }
        [JsonProperty("object")]
        public string Object { get; set; }
        public int weight { get; set; }
    }

}