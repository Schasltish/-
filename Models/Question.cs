using System.Collections.Generic;

namespace TestingProject.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; } = null!;
        public string Text { get; set; } = string.Empty;
        public List<AnswerOption> Options { get; set; } = new();
    }
}
