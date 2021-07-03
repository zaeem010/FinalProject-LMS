using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_LMS.Models
{
    public class Quiz
    {
        public int id { get; set; }
        public int Courseid { get; set; }
        public int Quizid { get; set; }
        public string QuizName { get; set; }
    }
    public class QuizChild
    {
        public int id { get; set; }
        public int Quizid { get; set; }
        public string Questions { get; set; }
        public string Answer { get; set; }
    }
}