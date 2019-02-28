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
    public class OgrenimSekliController : Controller
    {
        private Context db = new Context();

        // GET: OgrenimSekli
        public ActionResult Index()
        {
            return View(db.OgrenimSekilleri.ToList());
        }

        // GET: OgrenimSekli/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenimSekli ogrenimSekli = db.OgrenimSekilleri.Find(id);
            if (ogrenimSekli == null)
            {
                return HttpNotFound();
            }
            return View(ogrenimSekli);
        }

        // GET: OgrenimSekli/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OgrenimSekli/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OgrenimID,OgrenimTipi")] OgrenimSekli ogrenimSekli)
        {
            if (ModelState.IsValid)
            {
                db.OgrenimSekilleri.Add(ogrenimSekli);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ogrenimSekli);
        }

        // GET: OgrenimSekli/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenimSekli ogrenimSekli = db.OgrenimSekilleri.Find(id);
            if (ogrenimSekli == null)
            {
                return HttpNotFound();
            }
            return View(ogrenimSekli);
        }

        // POST: OgrenimSekli/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgrenimID,OgrenimTipi")] OgrenimSekli ogrenimSekli)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenimSekli).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogrenimSekli);
        }

        // GET: OgrenimSekli/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenimSekli ogrenimSekli = db.OgrenimSekilleri.Find(id);
            if (ogrenimSekli == null)
            {
                return HttpNotFound();
            }
            return View(ogrenimSekli);
        }

        // POST: OgrenimSekli/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OgrenimSekli ogrenimSekli = db.OgrenimSekilleri.Find(id);
            db.OgrenimSekilleri.Remove(ogrenimSekli);
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
