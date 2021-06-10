using System.Collections.Generic;

namespace FilipeApp.Models
{
    public class ElementSubmit
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public bool IconImported { get; set; }
        public string Icon { get; set; }
        public bool ImageImported { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public string People { get; set; }
        public List<string> LinkedElements { get; set; } = new();
    }
}