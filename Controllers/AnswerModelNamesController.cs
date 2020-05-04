using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SQLapp.Models;

namespace SQLapp.Controllers
{
    public class AnswerModelNamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AnswerModelNames
        public async Task<ActionResult> Index()
        {
            return View(await db.AnswerModelNames.ToListAsync());
        }

        // GET: AnswerModelNames/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerModelNames answerModelNames = await db.AnswerModelNames.FindAsync(id);
            if (answerModelNames == null)
            {
                return HttpNotFound();
            }
            return View(answerModelNames);
        }

        // GET: AnswerModelNames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnswerModelNames/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ModelName")] AnswerModelNames answerModelNames)
        {
            if (ModelState.IsValid)
            {
                db.AnswerModelNames.Add(answerModelNames);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(answerModelNames);
        }

        // GET: AnswerModelNames/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerModelNames answerModelNames = await db.AnswerModelNames.FindAsync(id);
            if (answerModelNames == null)
            {
                return HttpNotFound();
            }
            return View(answerModelNames);
        }

        // POST: AnswerModelNames/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ModelName")] AnswerModelNames answerModelNames)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answerModelNames).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(answerModelNames);
        }

        // GET: AnswerModelNames/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerModelNames answerModelNames = await db.AnswerModelNames.FindAsync(id);
            if (answerModelNames == null)
            {
                return HttpNotFound();
            }
            return View(answerModelNames);
        }

        // POST: AnswerModelNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AnswerModelNames answerModelNames = await db.AnswerModelNames.FindAsync(id);
            db.AnswerModelNames.Remove(answerModelNames);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
