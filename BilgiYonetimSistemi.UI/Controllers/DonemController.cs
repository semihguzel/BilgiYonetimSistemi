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
    public class DonemController : Controller
    {
        private Context db = new Context();

        // GET: Donem
        public ActionResult Index()
        {
            return View(db.Donemler.ToList());
        }

        // GET: Donem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donem donem = db.Donemler.Find(id);
            if (donem == null)
            {
                return HttpNotFound();
            }
            return View(donem);
        }

        // GET: Donem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonemID,DonemYili")] Donem donem)
        {
            if (ModelState.IsValid)
            {
                db.Donemler.Add(donem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donem);
        }

        // GET: Donem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donem donem = db.Donemler.Find(id);
            if (donem == null)
            {
                return HttpNotFound();
            }
            return View(donem);
        }

        // POST: Donem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonemID,DonemYili")] Donem donem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donem);
        }

        // GET: Donem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donem donem = db.Donemler.Find(id);
            if (donem == null)
            {
                return HttpNotFound();
            }
            return View(donem);
        }

        // POST: Donem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donem donem = db.Donemler.Find(id);
            db.Donemler.Remove(donem);
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
