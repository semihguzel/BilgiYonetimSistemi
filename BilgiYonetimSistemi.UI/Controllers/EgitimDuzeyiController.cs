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
    public class EgitimDuzeyiController : Controller
    {
        private Context db = new Context();

        // GET: EgitimDuzeyi
        public ActionResult Index()
        {
            return View(db.EgitimDuzeyleri.ToList());
        }

        // GET: EgitimDuzeyi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EgitimDuzeyi egitimDuzeyi = db.EgitimDuzeyleri.Find(id);
            if (egitimDuzeyi == null)
            {
                return HttpNotFound();
            }
            return View(egitimDuzeyi);
        }

        // GET: EgitimDuzeyi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EgitimDuzeyi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EgitimDuzeyiID,EgitimDuzeyTipi")] EgitimDuzeyi egitimDuzeyi)
        {
            if (ModelState.IsValid)
            {
                db.EgitimDuzeyleri.Add(egitimDuzeyi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(egitimDuzeyi);
        }

        // GET: EgitimDuzeyi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EgitimDuzeyi egitimDuzeyi = db.EgitimDuzeyleri.Find(id);
            if (egitimDuzeyi == null)
            {
                return HttpNotFound();
            }
            return View(egitimDuzeyi);
        }

        // POST: EgitimDuzeyi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EgitimDuzeyiID,EgitimDuzeyTipi")] EgitimDuzeyi egitimDuzeyi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(egitimDuzeyi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(egitimDuzeyi);
        }

        // GET: EgitimDuzeyi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EgitimDuzeyi egitimDuzeyi = db.EgitimDuzeyleri.Find(id);
            if (egitimDuzeyi == null)
            {
                return HttpNotFound();
            }
            return View(egitimDuzeyi);
        }

        // POST: EgitimDuzeyi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EgitimDuzeyi egitimDuzeyi = db.EgitimDuzeyleri.Find(id);
            db.EgitimDuzeyleri.Remove(egitimDuzeyi);
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
