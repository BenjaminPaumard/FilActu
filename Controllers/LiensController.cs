using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FilActualite.Models;

namespace FilActualite.Controllers
{
    public class LiensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Liens
        public ActionResult Index()
        {
            var liens = db.Liens.Include(l => l.Categorie);
            return View(liens.ToList());
        }

        // GET: Liens/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lien lien = db.Liens.Find(id);
            if (lien == null)
            {
                return HttpNotFound();
            }
            return View(lien);
        }

        // GET: Liens/Create
        public ActionResult Create()
        {
            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Nom");
            return View();
        }

        // POST: Liens/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Adrs,CategorieId")] Lien lien)
        {
            if (ModelState.IsValid)
            {
                lien.Id = Guid.NewGuid();
                db.Liens.Add(lien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Nom", lien.CategorieId);
            return View(lien);
        }

        // GET: Liens/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lien lien = db.Liens.Find(id);
            if (lien == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Nom", lien.CategorieId);
            return View(lien);
        }

        // POST: Liens/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Adrs,CategorieId")] Lien lien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Nom", lien.CategorieId);
            return View(lien);
        }

        // GET: Liens/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lien lien = db.Liens.Find(id);
            if (lien == null)
            {
                return HttpNotFound();
            }
            return View(lien);
        }

        // POST: Liens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Lien lien = db.Liens.Find(id);
            db.Liens.Remove(lien);
            db.SaveChanges();
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
