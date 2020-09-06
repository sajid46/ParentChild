using MVC_RenderSecstion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_RenderSecstion.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        StudentContext context = new StudentContext();

        [HttpPost]
        public ActionResult createStudent(Student std)
        {
            try
            {
                context.Students.Add(std);
                context.SaveChanges();
                string message = "Success";
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
            catch (Exception EX)
            {
                return null;
            }
            
        }

        public JsonResult getStudent(string id)
        {
            List<Student> students = new List<Student>();
            ViewBag.Title = "Student List";
            students = context.Students.ToList();
            return Json(students, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult deleteStudent(string id)
        {
            int _id = Convert.ToInt32(id);
            var st = context.Students.Where(i => i.StudentID == _id).FirstOrDefault();

            context.Students.Remove(st);
            context.SaveChanges();
            string message = "Deleted";
            var o = Json(message, JsonRequestBehavior.AllowGet);
            return o;
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    
}