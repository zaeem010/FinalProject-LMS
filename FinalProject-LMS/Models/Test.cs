using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_LMS.Models
{
    public class Test
    {
        public int id { get; set; }
        public int Testid { get; set; }
        public int Courseid { get; set; }
        public int Quizid { get; set; }
        public string StdName { get; set; }
    }
    public class TestChild
    {
        public int id { get; set; }
        public int Testid { get; set; }
        public string Questions { get; set; }
        public string Answer { get; set; }
    }
}