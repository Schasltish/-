using System;

namespace TestingProlect.Models
{
    public class TestResult
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string GroupName { get; set; } = string.Empty;
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public DateTime TestDate { get; set; } = DateTime.Now;
    }
}
