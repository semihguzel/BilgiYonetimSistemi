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
        public ActionResult Details(int id)
        {
            List<BolumlerDersler> bolumlerDersler = bolumDerslerConcrete.GetByName(id);
            if (bolumlerDersler == null)
            {
                return HttpNotFound();
            }
            Bolum bolum = bolumConcrete._bolumRepository.GetById(id);
            ViewBag.Bolum = bolum;
            return View(bolumlerDersler);
        }

        public ActionResult Department()
        {
            return View(bolumConcrete._bolumRepository.GetAll());
        }

        public ActionResult Departments()
        {
            return View(bolumConcrete._bolumRepository.GetAll());
        }

        // GET: Ders/Create
        public ActionResult Create(int id)
        {
            Bolum bolum = bolumConcrete._bolumRepository.GetById(id);
            ViewBag.Bolum = bolum;
            return View();
        }

        // POST: Ders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DersID,DersAdi,DersKredisi,DersKodu")] Ders ders, int id)
        {
            if (ModelState.IsValid)
            {
                var lesson = dersConcrete.GetByLessons(ders.DersKodu);
                if (bolumDerslerConcrete.GetByDepartmentLesson(id, ders.DersKodu) == null)
                {
                    if (lesson == null)
                    {
                        dersConcrete._dersRepository.Insert(ders);
                        dersConcrete._derslerUnitOfWork.SaveChanges();
                        dersConcrete._derslerUnitOfWork.Dispose();
                        Bolum bolum = bolumConcrete._bolumRepository.GetById(id);

                        BolumlerDersler bolumlerDersler = new BolumlerDersler()
                        {
                            BolumID = bolum.BolumID,
                            DersID = ders.DersID
                        };
                        bolumDerslerConcrete._bolumDerslerRepository.Insert(bolumlerDersler);
                        bolumDerslerConcrete._bolumDerslerUnitOfWork.SaveChanges();
                        bolumDerslerConcrete._bolumDerslerUnitOfWork.Dispose();
                    }
                    else
                    {
                        Bolum bolum = bolumConcrete._bolumRepository.GetById(id);
                        BolumlerDersler bolumlerDersler = new BolumlerDersler()
                        {
                            BolumID = bolum.BolumID,
                            DersID = lesson.DersID
                        };
                        bolumDerslerConcrete._bolumDerslerRepository.Insert(bolumlerDersler);
                        bolumDerslerConcrete._bolumDerslerUnitOfWork.SaveChanges();
                        bolumDerslerConcrete._bolumDerslerUnitOfWork.Dispose();
                    }
                    return RedirectToAction("Index");
                }
                else
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
