using System.Collections.Generic;

namespace Core
{
    public class Story
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public IEnumerable<string> Components { get; set; }
    }
}
