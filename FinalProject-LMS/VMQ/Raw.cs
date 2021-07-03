using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_LMS.VMQ
{
    public class DetailVMQ
    {
        public string Questions { get; set; }
        public string Answer { get; set; }
        public string Answer2 { get; set; }
    }
    public class AllSummaryVMQ
    {
        public int Testid { get; set; }
        public string StdName { get; set; }
        public string CourseName { get; set; }
        public string QuizName { get; set; }
    }
    public class SummaryVMQ
    {
        public string QuizName { get; set; }
        public string CourseName { get; set; }
    }
    public class QuizVMQ
    {
        public int Quizid { get; set; }
        public string QuizName { get; set; }
        public string CourseName { get; set; }
    }
}