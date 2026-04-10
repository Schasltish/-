namespace TestingProject.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; } // Правильный ответ
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}

