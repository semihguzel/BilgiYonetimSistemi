using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BilgiYonetimSistemi.BLL;
using BilgiYonetimSistemi.DAL;
using BilgiYonetimSistemi.DATA;


namespace BilgiYonetimSistemi.UI.Controllers
{
    public class OgretmenController : Controller
    {
        private Context db = new Context();

        // GET: Ogretmen
        public ActionResult Index()
        {
            return View(db.Ogretmenler.Where(x => x.IsActive == true).ToList());
        }

        // GET: Ogretmen/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogretmen ogretmen = db.Ogretmenler.Find(id);
            if (ogretmen == null)
            {
                return HttpNotFound();
            }
            return View(ogretmen);
        }

        // GET: Ogretmen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ogretmen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OgretmenID,OgretmenAdi,OgretmenSoyadi,Unvan,BaslangicTarihi,AyrilisTarihi,PersonelNumarasi,Sifre")] Ogretmen ogretmen, FormCollection frm, HttpPostedFileBase file)
        {
            ogretmen.IsActive = true;
            ogretmen.AyrilisTarihi = DateTime.Now;
            ogretmen.BaslangicTarihi = DateTime.Now;
            if (ModelState.IsValid)
            {
                var path = "";
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        if (Path.GetExtension(file.FileName).ToLower() == ".jpg" || Path.GetExtension(file.FileName).ToLower() == ".png" || Path.GetExtension(file.FileName).ToLower() == ".gif" || Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                        {
                            path = Path.Combine(Server.MapPath("~/Content/Images"), file.FileName);
                            file.SaveAs(path);
                        }
                    }
                }

                KullaniciIslemleri.OgretmenEkle(ogretmen);
                OgretmenBilgileri ogretmenBilgileri = new OgretmenBilgileri()
                {
                    OgretmenMail = frm["OgretmeninBilgisi.OgretmenMail"],
                    TCNo = frm["OgretmeninBilgisi.TCNo"],
                    Fotograf = path,
                    OgretmenID = ogretmen.OgretmenID,
                };
                db.OgretmenBilgileri.Add(ogretmenBilgileri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ogretmen);
        }

        // GET: Ogretmen/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogretmen ogretmen = db.Ogretmenler.Find(id);
            if (ogretmen == null)
            {
                return HttpNotFound();
            }
            return View(ogretmen);
        }

        // POST: Ogretmen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgretmenID,OgretmenAdi,OgretmenSoyadi,Unvan,BaslangicTarihi,AyrilisTarihi,PersonelNumarasi,Sifre")] Ogretmen ogretmen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogretmen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogretmen);
        }

        // GET: Ogretmen/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogretmen ogretmen = db.Ogretmenler.Find(id);
            if (ogretmen == null)
            {
                return HttpNotFound();
            }
            return View(ogretmen);
        }

        // POST: Ogretmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ogretmen ogretmen = db.Ogretmenler.Find(id);
            ogretmen.IsActive = false;
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
