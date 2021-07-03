using FinalProject_LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_LMS.ViewModels
{
    public class TestVM
    {
        public Test Test { get; set; }
        public List<Course> CourseList { get; set; }
        public QuizChild QuizChildList { get; set; }
        public int Quizid { get; set; }
        public int minid { get; set; }
        public int Count { get; set; }
        public int CountDb { get; set; }
    }
}