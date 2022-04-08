using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DrugaMVC.Models;

namespace DrugaMVC.Controllers
{
    public class StudentiController : Controller
    {
        // GET: Studenti
        public ActionResult Index()
        {
            var studentList = new List<Student>{
            new Student() { StudentId = 1, StudentName = "John Deer", Age = 18 } ,
            new Student() { StudentId = 2, StudentName = "Steve", Age = 21 } ,
            new Student() { StudentId = 3, StudentName = "Brotherman Bill", Age = 25 } ,
            new Student() { StudentId = 4, StudentName = "Ram Ranch" , Age = 20 } ,
            new Student() { StudentId = 5, StudentName = "Ronald McDonald" , Age = 31 } ,
            new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
            new Student() { StudentId = 4, StudentName = "Rob Ross" , Age = 19 }
            };

            return View(studentList);
        }

        public ActionResult TestRazorja() {
            Student miha = new Student() { StudentId = 12, StudentName = "Miha", Age = 21 };
            return View(miha);
        }

        public ActionResult Edit(int? id) {
            var studentList = new List<Student>{
            new Student() { StudentId = 1, StudentName = "John Deer", Age = 18 } ,
            new Student() { StudentId = 2, StudentName = "Steve", Age = 21 } ,
            new Student() { StudentId = 3, StudentName = "Brotherman Bill", Age = 25 } ,
            new Student() { StudentId = 4, StudentName = "Ram Ranch" , Age = 20 } ,
            new Student() { StudentId = 5, StudentName = "Ronald McDonald" , Age = 31 } ,
            new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
            new Student() { StudentId = 4, StudentName = "Rob Ross" , Age = 19 }
            };

            var miha = studentList.Where(a => a.StudentId == id).FirstOrDefault();
            return View(miha);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Include ="StudentID, StudentName")]Student std) {
            string x = std.StudentName;
            //dejansko posodobi bazo lol
            return RedirectToAction("Index");
        }
    }
}