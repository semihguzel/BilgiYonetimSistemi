using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BilgiYonetimSistemi.DAL;
using BilgiYonetimSistemi.DATA;

namespace BilgiYonetimSistemi.UI.Controllers
{
    public class FakulteController : Controller
    {
        private Context db = new Context();

        // GET: Fakulte
        public ActionResult Index()
        {
            return View(db.Fakulteler.ToList());
        }

        // GET: Fakulte/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fakulte fakulte = db.Fakulteler.Find(id);
            if (fakulte == null)
            {
                return HttpNotFound();
            }
            return View(fakulte);
        }

        // GET: Fakulte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fakulte/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FakulteID,FakulteAdi")] Fakulte fakulte)
        {
            if (ModelState.IsValid)
            {
                db.Fakulteler.Add(fakulte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fakulte);
        }

        // GET: Fakulte/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fakulte fakulte = db.Fakulteler.Find(id);
            if (fakulte == null)
            {
                return HttpNotFound();
            }
            return View(fakulte);
        }

        // POST: Fakulte/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FakulteID,FakulteAdi")] Fakulte fakulte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fakulte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fakulte);
        }

        // GET: Fakulte/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fakulte fakulte = db.Fakulteler.Find(id);
            if (fakulte == null)
            {
                return HttpNotFound();
            }
            return View(fakulte);
        }

        // POST: Fakulte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fakulte fakulte = db.Fakulteler.Find(id);
            db.Fakulteler.Remove(fakulte);
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
