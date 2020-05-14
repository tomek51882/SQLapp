using SQLapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SQLapp.Controllers
{
    public class TaskCreatorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: TaskCreator
        public ActionResult Index()
        {
            int max = 0;
            try
            {
                max = db.Tasks.Max(p => p.Id);
            }
            catch (Exception e)
            {
                max = 0;
            }


            ViewBag.id = max;
            return View();
        }
    }
}