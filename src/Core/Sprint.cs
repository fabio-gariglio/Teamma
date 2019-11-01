using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class Sprint
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<Story> Stories { get; set; } = Enumerable.Empty<Story>();
    }
}
