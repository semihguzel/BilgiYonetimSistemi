using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BilgiYonetimSistemi.BLL;
using BilgiYonetimSistemi.BLL.Repository.Concrete;
using BilgiYonetimSistemi.DAL;
using BilgiYonetimSistemi.DATA.Entities;

namespace BilgiYonetimSistemi.UI.Controllers
{
    public class YoneticiController : Controller
    {
        private Context db = new Context();
        YoneticiConcrete yoneticiConcrete = new YoneticiConcrete();

        // GET: Yonetici
        public ActionResult Index()
        {
            var yoneticis = db.Yoneticiler.Include(y => y.Kullanici);
            return View(yoneticis.ToList());
        }

        public ActionResult Anasayfa()
        {
            var kullanici = Session["Kullanici"] as Kullanici;
            return View(yoneticiConcrete._yoneticiRepository.GetById(kullanici.Id));
        }

        // GET: Yonetici/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yonetici yonetici = db.Yoneticiler.Find(id);
            if (yonetici == null)
            {
                return HttpNotFound();
            }
            return View(yonetici);
        }

        // GET: Yonetici/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yonetici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YoneticiID,TC,Ad,Soyad,KullaniciAdi,Sifre")] Yonetici yonetici)
        {
            if (ModelState.IsValid)
            {
                KullaniciIslemleri.YoneticiEkle(yonetici);
                return RedirectToAction("Index");
            }

            return View(yonetici);
        }

        // GET: Yonetici/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yonetici yonetici = db.Yoneticiler.Find(id);
            if (yonetici == null)
            {
                return HttpNotFound();
            }
            return View(yonetici);
        }

        // POST: Yonetici/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YoneticiID,TC,Ad,Soyad,KullaniciAdi,Sifre")] Yonetici yonetici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yonetici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yonetici);
        }

        // GET: Yonetici/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yonetici yonetici = db.Yoneticiler.Find(id);
            if (yonetici == null)
            {
                return HttpNotFound();
            }
            return View(yonetici);
        }

        // POST: Yonetici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Yonetici yonetici = db.Yoneticiler.Find(id);
            db.Yoneticiler.Remove(yonetici);
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
