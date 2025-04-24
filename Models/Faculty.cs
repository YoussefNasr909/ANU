using System.Collections.Generic;

namespace ANU.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FullDescription { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public List<Program> Programs { get; set; } = new List<Program>();
    }

    public class Program
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
