using ManyDBCRUDwithLayers.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManyDBCRUDwithLayers.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UseSqlServer()
        {
            Global.setDB(true);
            return View();
        }

        public ActionResult UsePostgreSql()
        {
            Global.setDB(false);
            return View();
        }

        public ActionResult Hata(string hataMesaji)
        {
            ViewBag.HataMesaji = hataMesaji;
            return View();
        }


    }
}