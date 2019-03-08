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
    public class FakulteBolumlerController : Controller
    {
        FakulteBolumlerConcrete fakulteBolumlerConcrete;
        public FakulteBolumlerController()
        {
            fakulteBolumlerConcrete = new FakulteBolumlerConcrete();
        }
        // GET: FakulteBolumler
        public ActionResult Index()
        {
            return View(fakulteBolumlerConcrete._fakulteBolumlerRepository.GetAll());
        }
    }
}
