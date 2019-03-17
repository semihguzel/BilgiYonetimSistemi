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
        Context db = new Context();
        BolumConcrete bolumConcrete;
        FakulteConcrete fakulteConcrete;
        FakulteBolumlerConcrete fakulteBolumlerConcrete;
        public BolumController()
        {
            bolumConcrete = new BolumConcrete();
            fakulteBolumlerConcrete = new FakulteBolumlerConcrete();
            fakulteConcrete = new FakulteConcrete();
        }


        // GET: Bolum
        public ActionResult Index()
        {
            return View(fakulteBolumlerConcrete._fakulteBolumlerRepository.GetAll());
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
            ViewBag.FakulteID = new SelectList(fakulteConcrete._fakulteRepository.GetEntity(), "FakulteID", "FakulteAdi");
            return View();
        }

        // POST: Bolum/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BolumID,BolumAdi,EgitimDili")] Bolum bolum, [Bind(Include = "FakulteID")] Fakulte fakulte)
        {
            if (ModelState.IsValid)
            {
                var department = bolumConcrete.GetByNameLanguage(bolum.BolumAdi, bolum.EgitimDili);
                fakulte = fakulteConcrete._fakulteRepository.GetById(fakulte.FakulteID);

                if (fakulteBolumlerConcrete.GetByFacultyDepartment(fakulte, bolum) == null)
                {
                    if (department == null)
                    {
                        bolumConcrete._bolumRepository.Insert(bolum);
                        bolumConcrete._bolumUnitOfWork.SaveChanges();
                        bolumConcrete._bolumUnitOfWork.Dispose();
                        FakulteBolumler fakulteBolumler = new FakulteBolumler()
                        {
                            BolumID = bolum.BolumID,
                            FakulteID = fakulte.FakulteID
                        };
                        fakulteBolumlerConcrete._fakulteBolumlerRepository.Insert(fakulteBolumler);
                        fakulteBolumlerConcrete._fakulteBolumlerUnitOfWork.SaveChanges();
                        fakulteBolumlerConcrete._fakulteBolumlerUnitOfWork.Dispose();

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        FakulteBolumler fakulteBolumler = new FakulteBolumler()
                        {
                            BolumID = department.BolumID,
                            FakulteID = fakulte.FakulteID
                        };
                        fakulteBolumlerConcrete._fakulteBolumlerRepository.Insert(fakulteBolumler);
                        fakulteBolumlerConcrete._fakulteBolumlerUnitOfWork.SaveChanges();
                        fakulteBolumlerConcrete._fakulteBolumlerUnitOfWork.Dispose();

                        return RedirectToAction("Index");
                    }
                }
                else
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
            FakulteBolumler fakulteBolumler = fakulteBolumlerConcrete._fakulteBolumlerRepository.GetById(id);
            Bolum bolum = bolumConcrete._bolumRepository.GetById(fakulteBolumler.BolumID);
            if (fakulteBolumler == null)
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
        public ActionResult Edit([Bind(Include = "BolumID,BolumAdi,EgitimDili")] Bolum bolum, int id)
        {
            var department = bolumConcrete.GetByNameLanguage(bolum.BolumAdi, bolum.EgitimDili);

            if (ModelState.IsValid)
            {
                if (department == null)
                {
                    bolumConcrete._bolumRepository.Insert(bolum);
                    bolumConcrete._bolumUnitOfWork.SaveChanges();
                    bolumConcrete._bolumUnitOfWork.Dispose();
                    FakulteBolumler fakulteBolumler = fakulteBolumlerConcrete._fakulteBolumlerRepository.GetById(id);
                    fakulteBolumler.BolumID = bolum.BolumID;
                    fakulteBolumlerConcrete._fakulteBolumlerRepository.Update(fakulteBolumler);
                    fakulteBolumlerConcrete._fakulteBolumlerUnitOfWork.SaveChanges();
                    fakulteBolumlerConcrete._fakulteBolumlerUnitOfWork.Dispose();
                    return RedirectToAction("Index");
                }
                else
                {
                    FakulteBolumler fakulteBolumler = fakulteBolumlerConcrete._fakulteBolumlerRepository.GetById(id);
                    Fakulte fakulte = fakulteConcrete._fakulteRepository.GetById(fakulteBolumler.FakulteID);
                    if (fakulteBolumlerConcrete.GetByFacultyDepartment(fakulte, bolum) == null)
                    {
                        fakulteBolumler.BolumID = department.BolumID;
                        fakulteBolumlerConcrete._fakulteBolumlerRepository.Update(fakulteBolumler);
                        fakulteBolumlerConcrete._fakulteBolumlerUnitOfWork.SaveChanges();
                        fakulteBolumlerConcrete._fakulteBolumlerUnitOfWork.Dispose();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        fakulteBolumlerConcrete._fakulteBolumlerRepository.Delete(id);
                        fakulteBolumlerConcrete._fakulteBolumlerUnitOfWork.SaveChanges();
                        fakulteBolumlerConcrete._fakulteBolumlerUnitOfWork.Dispose();
                        return RedirectToAction("Index");
                    }
                }
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
            FakulteBolumler fakulteBolumler = fakulteBolumlerConcrete._fakulteBolumlerRepository.GetById(id);
            if (fakulteBolumler == null)
            {
                return HttpNotFound();
            }
            return View(fakulteBolumler);
        }

        // POST: Bolum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fakulteBolumlerConcrete._fakulteBolumlerRepository.Delete(id);
            fakulteBolumlerConcrete._fakulteBolumlerUnitOfWork.SaveChanges();
            fakulteBolumlerConcrete._fakulteBolumlerUnitOfWork.Dispose();
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
