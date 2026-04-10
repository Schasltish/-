using System;

namespace TestingProject.Models
{
    public class TestResult
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string GroupName { get; set; }
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public DateTime TestDate { get; set; } = DateTime.Now;
    }
}
