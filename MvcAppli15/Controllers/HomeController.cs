using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAppli15.Models;

namespace MvcAppli15.Controllers
{
    public class HomeController : Controller
    {
        // Create an instance of DatabaseContext class
        hdfcDBContext db = new hdfcDBContext();

        public ActionResult Index()
        {
            return View();
        }

        // Return all students
        public PartialViewResult All()
        {
            System.Threading.Thread.Sleep(1000);
            List<Student> model = db.Students.ToList();
            return PartialView("_Student", model);
        }

        // Return Top3 students
        public PartialViewResult Top3()
        {
            System.Threading.Thread.Sleep(1000);
            List<Student> model = db.Students.OrderByDescending(x => x.TotalMarks).Take(3).ToList();
            return PartialView("_Student", model);
        }

        // Return Bottom3 students
        public PartialViewResult Bottom3()
        {
            System.Threading.Thread.Sleep(1000);
            List<Student> model = db.Students.OrderBy(x => x.TotalMarks).Take(3).ToList();
            return PartialView("_Student", model);
        }
    }
}
