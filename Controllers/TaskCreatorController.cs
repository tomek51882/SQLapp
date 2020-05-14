using SQLapp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace SQLapp.Controllers
{
    public class TaskCreatorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: TaskCreator
        public ActionResult Index()
        {
            int max;
            try
            {
                max = db.AnswerModelNames.Max(p => p.Id)+1;
            }
            catch (Exception e)
            {
                max = 1;
            }
            ViewBag.id = max;
            return View();
        }
        // POST: TaskCreator
        [HttpPost]
        public ActionResult Index(string SQLheader, string SQLcode, string taskID)
        {
            try
            {
                string test = Convert.ToString(SQLheader) + Convert.ToString(SQLcode);

                if(db.Database.ExecuteSqlCommand(test)==0)
                {
                    return View();
                }
                db.AnswerModelNames.Add(new AnswerModelNames { ModelName = "Model_"+taskID });
                db.SaveChangesAsync();
                return RedirectToAction("Continue", new { @taskID = taskID });
            }
            catch
            {
                return View();
            }
            //return test;
        }
        // GET: TaskCreator/Continue
        public ActionResult Continue(int? taskID)
        {
            ViewBag.taskID = taskID;
            ViewBag.userID = User.Identity.GetUserId();
            return View();
        }

        // GET: TaskCreator/Debug
        public ActionResult Debug()
        {
            return RedirectToAction("Continue", new { @taskID = 5 });
        }
    }
}