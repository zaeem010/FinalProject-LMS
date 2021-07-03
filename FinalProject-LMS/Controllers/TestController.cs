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
    public class TestController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Test
        public ActionResult Index()
        {
            List<AllSummaryVMQ> List = new List<AllSummaryVMQ>();
            if(User.IsInRole("Student"))
            {
                 List = _db.Database.SqlQuery<AllSummaryVMQ>("SELECT Tests.Testid, Tests.StdName, Courses.Name AS CourseName, Quizs.QuizName FROM Tests INNER JOIN Courses ON Tests.Courseid = Courses.Id INNER JOIN Quizs ON Tests.Quizid = Quizs.id WHERE(Tests.StdName = '" + Session["UserName"] + "')").ToList();
            }
            else 
            {
                List = _db.Database.SqlQuery<AllSummaryVMQ>("SELECT Tests.Testid, Tests.StdName, Courses.Name AS CourseName, Quizs.QuizName FROM Tests INNER JOIN Courses ON Tests.Courseid = Courses.Id INNER JOIN Quizs ON Tests.Quizid = Quizs.id").ToList();
            }
                
            return View(List);
        }
        public ActionResult Test(Test Test)
        {
            var Course = _db.Courses.ToList();
            Test.Testid = _db.Database.SqlQuery<int>("SELECT ISNULL(MAX(Testid), 0) + 1 AS Expr1 FROM Tests").Single();
            var VM = new TestVM
            {
                Test=Test,
               CourseList=Course,
            };
            return View(VM);
        }
        public ActionResult ShowData(int message)
        {
            var lst = _db.Quiz.SqlQuery("Select * From Quizs where (Courseid = " + message + ") ").ToList();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ProceedTest(Test Test ,int Quizid, int minid,string Que,string Ans,int count)
        {
            Test.Quizid = Quizid;
            QuizChild List = new QuizChild();
            int countdb = 0;
            countdb = _db.Database.SqlQuery<int>("select count(*) From QuizChild WHERE Quizid="+ Quizid +" ").Single();
            if(countdb==count)
            {
                _db.Database.ExecuteSqlCommand("INSERT INTO TestChilds (Testid, Questions, Answer) VALUES " +
                   "(" + Test.Testid + ",'" + Que + "','" + Ans + "')");
                var Summ = _db.Database.SqlQuery<SummaryVMQ>("SELECT Quizs.QuizName, Courses.Name AS CourseName FROM Tests INNER JOIN Quizs ON Tests.Quizid = Quizs.Quizid INNER JOIN Courses ON Tests.Courseid = Courses.Id WHERE(Tests.Testid = "+ Test.Testid +")").Single();
                var Total = _db.Database.SqlQuery<int>("SELECT COUNT(Questions) AS Expr1 FROM TestChilds WHERE (Testid = "+ Test.Testid +")").Single();
                var Cor = _db.Database.SqlQuery<int>("SELECT COUNT(Answer3) AS Expr1 FROM(SELECT id, Testid, Questions, Answer, Answer2, CASE WHEN Answer = Answer2 THEN 1 ELSE 0 END AS Answer3 FROM (SELECT id, Testid, Questions, Answer, (SELECT Answer FROM QuizChild WHERE (Questions = TestChilds.Questions)) AS Answer2 FROM TestChilds WHERE (Testid = "+ Test.Testid +")) AS derivedtbl_1) AS derivedtbl_2 WHERE (Answer3 = 1)").Single();
                var wrong = _db.Database.SqlQuery<int>("SELECT COUNT(Answer3) AS Expr1 FROM(SELECT id, Testid, Questions, Answer, Answer2, CASE WHEN Answer = Answer2 THEN 1 ELSE 0 END AS Answer3 FROM (SELECT id, Testid, Questions, Answer, (SELECT Answer FROM QuizChild WHERE (Questions = TestChilds.Questions)) AS Answer2 FROM TestChilds WHERE (Testid = "+ Test.Testid +")) AS derivedtbl_1) AS derivedtbl_2 WHERE (Answer3 = 0)").Single();
                
                var VM1 = new SummaryVM
                {
                    SummaryVMQ=Summ,
                    cor=Cor,
                    worng=wrong,
                    tot=Total,
                };
                return View("Summary", VM1);
            }
                if (minid == 0)
            {
                Test.StdName = (string)Session["UserName"];
                _db.Test.Add(Test);
                _db.SaveChanges();
                 List = _db.QuizChild.SqlQuery("select top(1)* From QuizChild WHERE Quizid="+ Quizid +" order by id ASC").SingleOrDefault();
                 minid = _db.Database.SqlQuery<int>("SELECT min(id)From QuizChild WHERE Quizid="+ Quizid + "  ").Single();
            }
            else
            {
                 List = _db.QuizChild.SqlQuery("select top(1)* From QuizChild WHERE id > " + minid + " AND Quizid="+ Quizid +" ").SingleOrDefault();
                 minid = _db.Database.SqlQuery<int>("SELECT min(id)From QuizChild WHERE Quizid=" + Quizid + " AND id > "+ minid +" ").Single();
                _db.Database.ExecuteSqlCommand("INSERT INTO TestChilds (Testid, Questions, Answer) VALUES " +
                   "(" + Test.Testid + ",'" + Que + "','" + Ans + "')");
                count += 1;
            }
             //List = _db.QuizChild.SqlQuery("SELECT * FROM QuizChild WHERE (Quizid = "+ Test.Quizid +")").ToList();
            var VM = new TestVM
            {
                Test = Test,
                QuizChildList=List,
                Quizid=Quizid,
                minid=minid,
                Count=count,
                CountDb=countdb
            };
            return View(VM);
        }
        public ActionResult Summary()
        {
            return View();
        }
        public ActionResult View(int testid)
        {
            var List = _db.Database.SqlQuery<DetailVMQ>("SELECT Questions, Answer, Answer2, Answer3 FROM(SELECT id, Testid, Questions, Answer, Answer2, CASE WHEN Answer = Answer2 THEN 1 ELSE 0 END AS Answer3 FROM (SELECT id, Testid, Questions, Answer, (SELECT Answer FROM QuizChild WHERE (Questions = TestChilds.Questions)) AS Answer2 FROM TestChilds WHERE (Testid = "+ testid +")) AS derivedtbl_1) AS derivedtbl_2").ToList();
            return View(List);
        }
        
    }
}