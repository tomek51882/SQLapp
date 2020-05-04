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
    public class SubcategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subcategories
        public async Task<ActionResult> Index()
        {
            return View(await db.Subcategory.ToListAsync());
        }

        // GET: Subcategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategories subcategories = await db.Subcategory.FindAsync(id);
            if (subcategories == null)
            {
                return HttpNotFound();
            }
            return View(subcategories);
        }

        // GET: Subcategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subcategories/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,CategoryId")] Subcategories subcategories)
        {
            if (ModelState.IsValid)
            {
                db.Subcategory.Add(subcategories);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(subcategories);
        }

        // GET: Subcategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategories subcategories = await db.Subcategory.FindAsync(id);
            if (subcategories == null)
            {
                return HttpNotFound();
            }
            return View(subcategories);
        }

        // POST: Subcategories/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,CategoryId")] Subcategories subcategories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcategories).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(subcategories);
        }

        // GET: Subcategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategories subcategories = await db.Subcategory.FindAsync(id);
            if (subcategories == null)
            {
                return HttpNotFound();
            }
            return View(subcategories);
        }

        // POST: Subcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Subcategories subcategories = await db.Subcategory.FindAsync(id);
            db.Subcategory.Remove(subcategories);
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
