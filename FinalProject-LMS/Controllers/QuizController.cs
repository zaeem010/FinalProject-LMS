using FinalProject_LMS.Models;
using FinalProject_LMS.ViewModels;
using FinalProject_LMS.VMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_LMS.Controllers
{
    public class QuizController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Quiz
        public ActionResult Index()
        {
            var List = _db.Database.SqlQuery<QuizVMQ>("SELECT Quizs.QuizName, Quizs.Quizid, Courses.Name AS CourseName FROM Quizs INNER JOIN Courses ON Quizs.Courseid = Courses.Id").ToList();
            return View(List);
        }
        public ActionResult Create(Quiz Quiz)
        {
            var Courses = _db.Courses.ToList();
            Quiz.Quizid = _db.Database.SqlQuery<int>("SELECT ISNULL(MAX(Quizid), 0) + 1 AS Quizid FROM Quizs").Single();
            var VM = new QuizVM
            {
                CourseList=Courses,
                Quiz=Quiz
            };
            return View(VM);
        }
        [HttpPost]
        public ActionResult Create(Quiz Quiz ,string[] Question ,string[] Answer)
        {
            if (Quiz.id == 0)
            {
                _db.Quiz.Add(Quiz);
                for (int i = 0; i < Question.Count(); i++)
                {
                    _db.Database.ExecuteSqlCommand("INSERT INTO QuizChild(Quizid, Questions, Answer) VALUES " +
                        "(" + Quiz.Quizid + ",'" + Question[i] + "','" + Answer[i] + "')");
                }
            }
            else 
            {
                var db = _db.Quiz.SingleOrDefault(c => c.Quizid == Quiz.Quizid);
                db.Courseid = Quiz.Courseid;
                db.QuizName = Quiz.QuizName;
                _db.Database.ExecuteSqlCommand("DELETE FROM QuizChild WHERE (Quizid = "+ Quiz.Quizid +")");
                for (int i = 0; i < Question.Count(); i++)
                {
                    _db.Database.ExecuteSqlCommand("INSERT INTO QuizChild(Quizid, Questions, Answer) VALUES " +
                        "(" + Quiz.Quizid + ",'" + Question[i] + "','" + Answer[i] + "')");
                }
            }
            _db.SaveChanges();
            return RedirectToAction("Create");
        }
        public ActionResult Edit(int id)
        {
            var dbQuiz = _db.Quiz.SingleOrDefault(c=>c.Quizid == id);
            var dbQuizChild = _db.QuizChild.SqlQuery("SELECT * FROM QuizChild WHERE (Quizid = "+ id +")").ToList();
            var Courses = _db.Courses.ToList();
            var VM = new QuizVM
            {
                Quiz=dbQuiz,
                CourseList=Courses,
                QuizChildList=dbQuizChild,
            };
            return View("Create",VM); 
        }
    }
}