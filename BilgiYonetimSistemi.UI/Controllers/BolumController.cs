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
        public ActionResult Create([Bind(Include = "BolumID,BolumAdi,EgitimDili")] Bolum bolum, FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                var department = bolumConcrete.GetByNameLanguage(bolum.BolumAdi, bolum.EgitimDili);

                if (fakulteBolumlerConcrete.GetByFacultyDepartment(int.Parse(frm["fakulteid"]), bolum) == null)
                {
                    if (department == null)
                    {
                        bolumConcrete._bolumRepository.Insert(bolum);
                        bolumConcrete._bolumUnitOfWork.SaveChanges();
                        bolumConcrete._bolumUnitOfWork.Dispose();
                        FakulteBolumler fakulteBolumler = new FakulteBolumler()
                        {
                            BolumID = bolum.BolumID,
                            FakulteID = int.Parse(frm["fakulteid"])
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
                            FakulteID = int.Parse(frm["fakulteid"])
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
            if (fakulteBolumler == null)
            {
                return HttpNotFound();
            }
            return View(fakulteBolumler);
        }

        // POST: Bolum/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BolumID,FakulteID,FakulteBolumlerID")] FakulteBolumler fakulteBolumler, FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                string bolumAdi = frm["FakulteninBolumu.BolumAdi"];
                string egitimDili = frm["FakulteninBolumu.EgitimDili"];

                Bolum bolum = db.Bolumler.FirstOrDefault(x => x.EgitimDili == egitimDili && x.BolumAdi == bolumAdi);
                if (bolum == null)
                {
                    bolum = new Bolum()
                    {
                        BolumAdi = frm["FakulteninBolumu.BolumAdi"],
                        EgitimDili = frm["FakulteninBolumu.EgitimDili"]
                    };
                  


                    bolumConcrete._bolumRepository.Insert(bolum);
                    bolumConcrete._bolumUnitOfWork.SaveChanges();
                    bolumConcrete._bolumUnitOfWork.Dispose();
                    fakulteBolumler.BolumID = bolum.BolumID;
                }
                else
                {
                    fakulteBolumler.BolumID = bolum.BolumID;
                }

                fakulteBolumlerConcrete._fakulteBolumlerRepository.Update(fakulteBolumler);
                fakulteBolumlerConcrete._fakulteBolumlerUnitOfWork.SaveChanges();
                fakulteBolumlerConcrete._fakulteBolumlerUnitOfWork.Dispose();




                return RedirectToAction("Index");
            }
            return View(fakulteBolumler);
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
