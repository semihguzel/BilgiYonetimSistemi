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
using BilgiYonetimSistemi.BLL.Repository.Concrete;

namespace BilgiYonetimSistemi.UI.Controllers
{
    public class DersController : Controller
    {
        DersConcrete dersConcrete;
        BolumConcrete bolumConcrete;
        BolumDerslerConcrete bolumDerslerConcrete;
        public DersController()
        {
            dersConcrete = new DersConcrete();
            bolumConcrete = new BolumConcrete();
            bolumDerslerConcrete = new BolumDerslerConcrete();
        }
        // GET: Ders
        public ActionResult Index()
        {
            return View(dersConcrete._dersRepository.GetAll());
        }

        // GET: Ders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ders ders = dersConcrete._dersRepository.GetById(id);
            if (ders == null)
            {
                return HttpNotFound();
            }
            return View(ders);
        }

        // GET: Ders/Create
        public ActionResult Create()
        {
            List<Bolum> bolumler = bolumConcrete.GetByLanguage("türkçe");
            ViewBag.BolumID = new SelectList(bolumler, "BolumID", "BolumAdi");
            return View();
        }

        // POST: Ders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DersID,DersAdi,DersKredisi,DersKodu")] Ders ders, [Bind(Include = "BolumID")] Bolum bolum)
        {
            if (ModelState.IsValid)
            {
                dersConcrete._dersRepository.Insert(ders);
                dersConcrete._derslerUnitOfWork.SaveChanges();
                dersConcrete._derslerUnitOfWork.Dispose();
                bolum = bolumConcrete._bolumRepository.GetById(bolum.BolumID);
                for (int i = 0; i < bolumConcrete.GetByName(bolum.BolumAdi).Count(); i++)
                {                    
                    BolumlerDersler bolumlerDersler = new BolumlerDersler()
                    {
                        BolumID = bolum.BolumID,
                        DersID = ders.DersID
                    };
                    bolumDerslerConcrete._bolumDerslerRepository.Insert(bolumlerDersler);
                    bolumDerslerConcrete._bolumDerslerUnitOfWork.SaveChanges();
                    bolumDerslerConcrete._bolumDerslerUnitOfWork.Dispose();
                }
                return RedirectToAction("Index");
            }

            return View(ders);
        }

        // GET: Ders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ders ders = dersConcrete._dersRepository.GetById(id);
            if (ders == null)
            {
                return HttpNotFound();
            }
            return View(ders);
        }

        // POST: Ders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DersID,DersAdi,DersKredisi,DersKodu")] Ders ders)
        {
            if (ModelState.IsValid)
            {
                dersConcrete._dersRepository.Update(ders);
                dersConcrete._derslerUnitOfWork.SaveChanges();
                dersConcrete._derslerUnitOfWork.Dispose();

                return RedirectToAction("Index");
            }
            return View(ders);
        }

        // GET: Ders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ders ders = dersConcrete._dersRepository.GetById(id);
            if (ders == null)
            {
                return HttpNotFound();
            }
            return View(ders);
        }

        // POST: Ders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dersConcrete._dersRepository.Delete(id);
            dersConcrete._derslerUnitOfWork.SaveChanges();
            dersConcrete._derslerUnitOfWork.Dispose();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dersConcrete._derslerUnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
