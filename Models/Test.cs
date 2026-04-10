using System;
using System.Collections.Generic;

namespace TestingProlect.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<Question> Questions { get; set; } = new();
    }
}
