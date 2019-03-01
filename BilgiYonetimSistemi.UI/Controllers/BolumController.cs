using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BilgiYonetimSistemi.BLL.Repository.Concrete;
using BilgiYonetimSistemi.DAL;
using BilgiYonetimSistemi.DATA;

namespace BilgiYonetimSistemi.UI.Controllers
{
    public class BolumController : Controller
    {
        BolumConcrete bolumConcrete;
        public BolumController()
        {
            bolumConcrete = new BolumConcrete();
        }


        // GET: Bolum
        public ActionResult Index()
        {
            return View(bolumConcrete._bolumRepository.GetAll());
        }

        // GET: Bolum/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolum bolum = bolumConcrete._bolumRepository.GetById(id);
            if (bolum == null)
            {
                return HttpNotFound();
            }
            return View(bolum);
        }

        // GET: Bolum/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bolum/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BolumID,BolumAdi,EgitimDili")] Bolum bolum)
        {
            if (ModelState.IsValid)
            {
                bolumConcrete._bolumRepository.Insert(bolum);
                bolumConcrete._bolumUnitOfWork.SaveChanges();
                bolumConcrete._bolumUnitOfWork.Dispose();
                return RedirectToAction("Index");
            }

            return View(bolum);
        }

        // GET: Bolum/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolum bolum = bolumConcrete._bolumRepository.GetById(id);
            if (bolum == null)
            {
                return HttpNotFound();
            }
            return View(bolum);
        }

        // POST: Bolum/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BolumID,BolumAdi,EgitimDili")] Bolum bolum)
        {
            if (ModelState.IsValid)
            {
                bolumConcrete._bolumRepository.Update(bolum);
                bolumConcrete._bolumUnitOfWork.SaveChanges();
                bolumConcrete._bolumUnitOfWork.Dispose();
                return RedirectToAction("Index");
            }
            return View(bolum);
        }

        // GET: Bolum/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolum bolum = bolumConcrete._bolumRepository.GetById(id);
            if (bolum == null)
            {
                return HttpNotFound();
            }
            return View(bolum);
        }

        // POST: Bolum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            bolumConcrete._bolumRepository.Delete(id);
            bolumConcrete._bolumUnitOfWork.SaveChanges();
            bolumConcrete._bolumUnitOfWork.Dispose();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bolumConcrete._bolumUnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
