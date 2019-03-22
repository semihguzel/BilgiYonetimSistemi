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
    public class OgretmenlerDerslerDonemlerController : Controller
    {
        private Context db = new Context();

        // GET: OgretmenlerDerslerDonemler
        public ActionResult Index()
        {
            var ogretmenlerDersler = db.OgretmenlerDersler.Include(o => o.DersinOgretmeni).Include(o => o.OgretmenDersinDonemi).Include(o => o.OgretmeninDersi);
            return View(ogretmenlerDersler.ToList());
        }

        // GET: OgretmenlerDerslerDonemler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgretmenlerDerslerDonemler ogretmenlerDerslerDonemler = db.OgretmenlerDersler.Find(id);
            if (ogretmenlerDerslerDonemler == null)
            {
                return HttpNotFound();
            }
            return View(ogretmenlerDerslerDonemler);
        }

        // GET: OgretmenlerDerslerDonemler/Create
        public ActionResult Create()
        {
            
            
            ViewBag.OgretmenID = new SelectList(db.Ogretmenler, "OgretmenID", "OgretmenAdi");
            ViewBag.DonemID = new SelectList(db.Donemler, "DonemID", "DonemYili");
            ViewBag.DersID = new SelectList(db.Dersler, "DersID", "DersAdi");
            return View();
        }

        // POST: OgretmenlerDerslerDonemler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OgretmenlerDerslerID,OgretmenID,DersID")] OgretmenlerDerslerDonemler ogretmenlerDerslerDonemler)
        {
            var kullanici = Session["Kullanici"] as DATA.Entities.Kullanici;
            ogretmenlerDerslerDonemler.DonemID = db.Donemler.FirstOrDefault(x => x.DonemYili == DateTime.Now.Year.ToString()).DonemID;
            if (ModelState.IsValid)
            {
                if (BilgiYonetimSistemi.BLL.KullaniciIslemleri.RolGecerliMi(kullanici, "ogretmen"))
                    ogretmenlerDerslerDonemler.OgretmenID = kullanici.Id;
                db.OgretmenlerDersler.Add(ogretmenlerDerslerDonemler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OgretmenID = new SelectList(db.Ogretmenler, "OgretmenID", "OgretmenAdi", ogretmenlerDerslerDonemler.OgretmenID);
            ViewBag.DonemID = new SelectList(db.Donemler, "DonemID", "DonemYili", ogretmenlerDerslerDonemler.DonemID);
            ViewBag.DersID = new SelectList(db.Dersler, "DersID", "DersAdi", ogretmenlerDerslerDonemler.DersID);
            return View(ogretmenlerDerslerDonemler);
        }

        // GET: OgretmenlerDerslerDonemler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgretmenlerDerslerDonemler ogretmenlerDerslerDonemler = db.OgretmenlerDersler.Find(id);
            if (ogretmenlerDerslerDonemler == null)
            {
                return HttpNotFound();
            }
            ViewBag.OgretmenID = new SelectList(db.Ogretmenler, "OgretmenID", "OgretmenAdi", ogretmenlerDerslerDonemler.OgretmenID);
            ViewBag.DonemID = new SelectList(db.Donemler, "DonemID", "DonemYili", ogretmenlerDerslerDonemler.DonemID);
            ViewBag.DersID = new SelectList(db.Dersler, "DersID", "DersAdi", ogretmenlerDerslerDonemler.DersID);
            return View(ogretmenlerDerslerDonemler);
        }

        // POST: OgretmenlerDerslerDonemler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgretmenlerDerslerID,OgretmenID,DersID,DonemID")] OgretmenlerDerslerDonemler ogretmenlerDerslerDonemler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogretmenlerDerslerDonemler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OgretmenID = new SelectList(db.Ogretmenler, "OgretmenID", "OgretmenAdi", ogretmenlerDerslerDonemler.OgretmenID);
            ViewBag.DonemID = new SelectList(db.Donemler, "DonemID", "DonemYili", ogretmenlerDerslerDonemler.DonemID);
            ViewBag.DersID = new SelectList(db.Dersler, "DersID", "DersAdi", ogretmenlerDerslerDonemler.DersID);
            return View(ogretmenlerDerslerDonemler);
        }

        // GET: OgretmenlerDerslerDonemler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgretmenlerDerslerDonemler ogretmenlerDerslerDonemler = db.OgretmenlerDersler.Find(id);
            if (ogretmenlerDerslerDonemler == null)
            {
                return HttpNotFound();
            }
            return View(ogretmenlerDerslerDonemler);
        }

        // POST: OgretmenlerDerslerDonemler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OgretmenlerDerslerDonemler ogretmenlerDerslerDonemler = db.OgretmenlerDersler.Find(id);
            db.OgretmenlerDersler.Remove(ogretmenlerDerslerDonemler);
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
