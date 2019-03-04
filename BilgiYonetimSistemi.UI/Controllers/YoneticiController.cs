using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgiYonetimSistemi.UI.Controllers
{
    [Authorize(Roles = "yonetici")]
    public class YoneticiController : Controller
    {
        // GET: Yonetici
        public ActionResult Index()
        {
            return View();
        }
    }
}