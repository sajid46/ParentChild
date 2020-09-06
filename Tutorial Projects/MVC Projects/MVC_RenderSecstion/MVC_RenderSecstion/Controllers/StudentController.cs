using MVC_RenderSecstion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_RenderSecstion.Controllers
{
    public class StudentController : Controller
    {
        StudentsContext context = new StudentsContext();
        StudentContext context2 = new StudentContext();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetStudents()
        {
            try
            {
                List<Student> students = new List<Student>();
                students = context2.Students.ToList();
                return Json(students, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

    
}