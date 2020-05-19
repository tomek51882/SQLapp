using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using SQLapp.Models;
using System.Data.Entity;
using System.Globalization;

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
            ViewBag.error = "";
            return View();
        }
        // POST: TaskCreator
        [HttpPost]
        public ActionResult Index(string SQLheader, string SQLcode, string modelID)
        {

            try
            {
                string test = Convert.ToString(SQLheader) + Convert.ToString(SQLcode);

                if(db.Database.ExecuteSqlCommand(test)==0)
                {
                    return View();
                }
                db.AnswerModelNames.Add(new AnswerModelNames { ModelName = "Model_"+ modelID });
                db.SaveChangesAsync();
                return RedirectToAction("Continue", new { @modelID = modelID });
            }
            catch
            {
                ViewBag.id = int.Parse(modelID);
                ViewBag.error = "0004";
                return View();
            }
            //return test;
        }
        // GET: TaskCreator/Continue/modelID
        public async Task<ActionResult> Continue(int? modelID)
        {
            int taskID;
            try
            {
                taskID = db.Tasks.Max(p => p.Id) + 1;
            }
            catch (Exception e)
            {
                taskID = 1;
            }
            ViewBag.modelID = modelID;
            ViewBag.taskID = taskID;
            ViewBag.userID = User.Identity.GetUserId();
            ViewBag.error = "";
            var subcategories = await db.Subcategory.ToListAsync();
            ViewBag.subcategories = subcategories;
            return View();
        }
        // POST: TaskCreator/Continue
        [HttpPost]
        public async Task<ActionResult> Continue(string taskID, string Description, string CreatorId, string SubcategoryID, string AnswerModelId, string CreatedAt, string ModifiedAt)
        {
            //return taskID + "\n" + Description + "\n" + CreatorId + "\n" + SubcategoryID + "\n" + AnswerModelId + "\n" + DateTime.ParseExact(CreatedAt, "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture) + "\n" + ModifiedAt;
            try
            {
                db.Tasks.Add(new Tasks 
                { 
                    Description = Description, 
                    CreatorId = CreatorId, 
                    SubcategoryId = int.Parse(SubcategoryID),
                    AnswerModelId = int.Parse(AnswerModelId)
                });
                await db.SaveChangesAsync();
                return RedirectToAction("Done");
            }
            catch (Exception e)
            {
                ViewBag.modelID = int.Parse(AnswerModelId);
                ViewBag.taskID = int.Parse(taskID); //brzydkie rozwiązanie pewnego problemu
                ViewBag.userID = User.Identity.GetUserId();
                ViewBag.error = "0005";
                ViewBag.errorMsg = e.Message + "\n" + e.InnerException;
                var subcategories = db.Subcategory.ToList();
                ViewBag.subcategories = subcategories;
                return View();
            }
        }

        // GET: TaskCreator/Debug
        public ActionResult Debug()
        {
            return RedirectToAction("Continue", new { @modelID = 5 });
        }

        // GET: TaskCreator/Done
        public ActionResult Done()
        {
            return View();
        }
    }
}