using FinalProject_LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_LMS.ViewModels
{
    public class QuizVM
    {
        public List<Course> CourseList { get; set; }
        public Quiz Quiz { get; set; }
        public List<QuizChild> QuizChildList { get; set; }
    }
}