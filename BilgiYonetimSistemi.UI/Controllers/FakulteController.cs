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
    public class FakulteController : Controller
    {        
        FakulteConcrete fakulteConcrete;
        public FakulteController()
        {
            fakulteConcrete = new FakulteConcrete();
        }
        // GET: Fakulte
        public ActionResult Index()
        {
            return View(fakulteConcrete._fakulteRepository.GetAll());
        }

        // GET: Fakulte/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fakulte fakulte = fakulteConcrete._fakulteRepository.GetById(id);
            if (fakulte == null)
            {
                return HttpNotFound();
            }
            return View(fakulte);
        }

        // GET: Fakulte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fakulte/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FakulteID,FakulteAdi")] Fakulte fakulte)
        {
            if (ModelState.IsValid)
            {
                var faculty = fakulteConcrete.GetByName(fakulte.FakulteAdi);

                if (faculty == null)
                {
                    fakulteConcrete._fakulteRepository.Insert(fakulte);
                    fakulteConcrete._fakulteUnitOfWork.SaveChanges();
                    fakulteConcrete._fakulteUnitOfWork.Dispose();
                    return RedirectToAction("Index");
                }
                else
                    return RedirectToAction("Index");
            }

            return View(fakulte);
        }

        // GET: Fakulte/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fakulte fakulte = fakulteConcrete._fakulteRepository.GetById(id);
            if (fakulte == null)
            {
                return HttpNotFound();
            }
            return View(fakulte);
        }

        // POST: Fakulte/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FakulteID,FakulteAdi")] Fakulte fakulte)
        {
            if (ModelState.IsValid)
            {
                fakulteConcrete._fakulteRepository.Update(fakulte);
                fakulteConcrete._fakulteUnitOfWork.SaveChanges();
                fakulteConcrete._fakulteUnitOfWork.Dispose();                
                return RedirectToAction("Index");
            }
            return View(fakulte);
        }

        // GET: Fakulte/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fakulte fakulte =fakulteConcrete._fakulteRepository.GetById(id);
            if (fakulte == null)
            {
                return HttpNotFound();
            }
            return View(fakulte);
        }

        // POST: Fakulte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fakulteConcrete._fakulteRepository.Delete(id);
            fakulteConcrete._fakulteUnitOfWork.SaveChanges();
            fakulteConcrete._fakulteUnitOfWork.Dispose();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               fakulteConcrete._fakulteUnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
