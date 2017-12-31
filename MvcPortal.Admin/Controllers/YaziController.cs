using MvcPortal.Admin.CustomFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPortal.Admin.Controllers
{
    public class YaziController : Controller
    {
        // GET: Yazi
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [LoginFilter]
        public ActionResult Ekle()
        {
            return View();
        }
    }
}