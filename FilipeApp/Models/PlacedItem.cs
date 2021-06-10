using System.Collections.Generic;

namespace FilipeApp.Models
{
    public class PlacedItem
    {
        public string name { get; set; }
        public string typeNode { get; set; }
        public string group { get; set; } = "unesco";
        public string label { get; set; }
        public NodeMeta metadata { get; set; }
        public List<string> all_linked_elements { get; set; }
    }

    public class NodeIcon
    {
        public string small { get; set; }
        public string large { get; set; }
    }

    public class NodeMedia
    {
        public string url { get; set; }
        public string copyright { get; set; }
        public string title { get; set; }
    }
    
    public class NodeMeta
    {
        public NodeIcon icon { get; set; }
        public string description { get; set; }
        public string list { get; set; } = "LR";
        public string year { get; set; }
        public string multinational { get; set; } = "EN";
        public string link { get; set; }
        public NodeMedia[] images { get; set; }
        public NodeMedia[] videos { get; set; }
        public string sustainability { get; set; }
    }
 
    /*
class NodeMeta(object):
    def __init__(self):
        self.icon = NodeIcon()
        self.description = ""
        self.liste = "LR"
        self.year = ""
        self.multinational = "EN"
        self.link = ""
        self.images = [NodeImage]
        self.videos = [NodeVideo]
        self.sustainability = ""

     */
    
}