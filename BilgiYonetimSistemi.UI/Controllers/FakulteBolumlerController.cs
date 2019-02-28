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
    public class FakulteBolumlerController : Controller
    {
        private Context db = new Context();

        // GET: FakulteBolumler
        public ActionResult Index()
        {
            var fakulteBolumler = db.FakulteBolumler.Include(f => f.BolumunFakultesi).Include(f => f.FakulteninBolumu);
            return View(fakulteBolumler.ToList());
        }

        // GET: FakulteBolumler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FakulteBolumler fakulteBolumler = db.FakulteBolumler.Find(id);
            if (fakulteBolumler == null)
            {
                return HttpNotFound();
            }
            return View(fakulteBolumler);
        }

        // GET: FakulteBolumler/Create
        public ActionResult Create()
        {
            ViewBag.FakulteID = new SelectList(db.Fakulteler, "FakulteID", "FakulteAdi");
            ViewBag.BolumID = new SelectList(db.Bolumler, "BolumID", "BolumAdi");
            return View();
        }

        // POST: FakulteBolumler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FakulteBolumlerID,FakulteID,BolumID")] FakulteBolumler fakulteBolumler)
        {
            if (ModelState.IsValid)
            {
                db.FakulteBolumler.Add(fakulteBolumler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FakulteID = new SelectList(db.Fakulteler, "FakulteID", "FakulteAdi", fakulteBolumler.FakulteID);
            ViewBag.BolumID = new SelectList(db.Bolumler, "BolumID", "BolumAdi", fakulteBolumler.BolumID);
            return View(fakulteBolumler);
        }

        // GET: FakulteBolumler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FakulteBolumler fakulteBolumler = db.FakulteBolumler.Find(id);
            if (fakulteBolumler == null)
            {
                return HttpNotFound();
            }
            ViewBag.FakulteID = new SelectList(db.Fakulteler, "FakulteID", "FakulteAdi", fakulteBolumler.FakulteID);
            ViewBag.BolumID = new SelectList(db.Bolumler, "BolumID", "BolumAdi", fakulteBolumler.BolumID);
            return View(fakulteBolumler);
        }

        // POST: FakulteBolumler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FakulteBolumlerID,FakulteID,BolumID")] FakulteBolumler fakulteBolumler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fakulteBolumler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FakulteID = new SelectList(db.Fakulteler, "FakulteID", "FakulteAdi", fakulteBolumler.FakulteID);
            ViewBag.BolumID = new SelectList(db.Bolumler, "BolumID", "BolumAdi", fakulteBolumler.BolumID);
            return View(fakulteBolumler);
        }

        // GET: FakulteBolumler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FakulteBolumler fakulteBolumler = db.FakulteBolumler.Find(id);
            if (fakulteBolumler == null)
            {
                return HttpNotFound();
            }
            return View(fakulteBolumler);
        }

        // POST: FakulteBolumler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FakulteBolumler fakulteBolumler = db.FakulteBolumler.Find(id);
            db.FakulteBolumler.Remove(fakulteBolumler);
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
