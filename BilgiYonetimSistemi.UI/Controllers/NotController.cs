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
    public class NotController : Controller
    {
        private Context db = new Context();

        // GET: Not
        public ActionResult Index()
        {
            var notlar = db.Notlar.Include(n => n.NotunOgrenciDersDonemi).Include(n => n.NotunSinavi);
            return View(notlar.ToList());
        }

        // GET: Not/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Not not = db.Notlar.Find(id);
            if (not == null)
            {
                return HttpNotFound();
            }
            return View(not);
        }

        // GET: Not/Create
        public ActionResult Create()
        {
            ViewBag.OgrenciDerslerDonemlerID = new SelectList(db.OgrencilerDersler, "OgrenciDerslerDonemler", "OgrenciDerslerDonemler");
            ViewBag.SinavID = new SelectList(db.Sinavlar, "SinavID", "SinavTipi");
            return View();
        }

        // POST: Not/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NotID,Puan,SinavID,OgrenciDerslerDonemlerID")] Not not)
        {
            if (ModelState.IsValid)
            {
                db.Notlar.Add(not);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OgrenciDerslerDonemlerID = new SelectList(db.OgrencilerDersler, "OgrenciDerslerDonemler", "OgrenciDerslerDonemler", not.OgrenciDerslerDonemlerID);
            ViewBag.SinavID = new SelectList(db.Sinavlar, "SinavID", "SinavTipi", not.SinavID);
            return View(not);
        }

        // GET: Not/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Not not = db.Notlar.Find(id);
            if (not == null)
            {
                return HttpNotFound();
            }
            ViewBag.OgrenciDerslerDonemlerID = new SelectList(db.OgrencilerDersler, "OgrenciDerslerDonemler", "OgrenciDerslerDonemler", not.OgrenciDerslerDonemlerID);
            ViewBag.SinavID = new SelectList(db.Sinavlar, "SinavID", "SinavTipi", not.SinavID);
            return View(not);
        }

        // POST: Not/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NotID,Puan,SinavID,OgrenciDerslerDonemlerID")] Not not)
        {
            if (ModelState.IsValid)
            {
                db.Entry(not).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OgrenciDerslerDonemlerID = new SelectList(db.OgrencilerDersler, "OgrenciDerslerDonemler", "OgrenciDerslerDonemler", not.OgrenciDerslerDonemlerID);
            ViewBag.SinavID = new SelectList(db.Sinavlar, "SinavID", "SinavTipi", not.SinavID);
            return View(not);
        }

        // GET: Not/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Not not = db.Notlar.Find(id);
            if (not == null)
            {
                return HttpNotFound();
            }
            return View(not);
        }

        // POST: Not/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Not not = db.Notlar.Find(id);
            db.Notlar.Remove(not);
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
