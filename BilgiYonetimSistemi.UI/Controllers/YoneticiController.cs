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
            return View(yoneticiConcrete._yoneticiRepository.GetAll());
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
            Yonetici yonetici = yoneticiConcrete._yoneticiRepository.GetById(id);
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
        public ActionResult Create([Bind(Include = "YoneticiID,TC,Ad,Soyad,KullaniciAdi,Sifre")] Yonetici yonetici, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string ad = "";
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        if (Path.GetExtension(file.FileName).ToLower() == ".jpg" || Path.GetExtension(file.FileName).ToLower() == ".png" || Path.GetExtension(file.FileName).ToLower() == ".gif" || Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                        {
                            ad = Guid.NewGuid() + Path.GetExtension(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/images"), ad);
                            file.SaveAs(path);
                        }
                    }
                }
                yonetici.Fotograf = ad;
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
            Yonetici yonetici = yoneticiConcrete._yoneticiRepository.GetById(id);
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
                yoneticiConcrete._yoneticiRepository.Update(yonetici);
                yoneticiConcrete._yoneticiUnitOfWork.SaveChanges();
                yoneticiConcrete._yoneticiUnitOfWork.Dispose();
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
            Yonetici yonetici = yoneticiConcrete._yoneticiRepository.GetById(id);
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
            Yonetici yonetici = yoneticiConcrete._yoneticiRepository.GetById(id);
            yoneticiConcrete._yoneticiRepository.Delete(yonetici);
            yoneticiConcrete._yoneticiUnitOfWork.SaveChanges();
            yoneticiConcrete._yoneticiUnitOfWork.Dispose();
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
