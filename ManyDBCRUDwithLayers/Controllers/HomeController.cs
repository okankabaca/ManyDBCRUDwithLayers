using ManyDBCRUDwithLayers.App_Start;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            ConfigurationManager.AppSettings["DBType"] = "MSSQL";
            return RedirectToAction("FindAll", "TableStaj");

        }

        public ActionResult UsePostgreSql()
        {
            ConfigurationManager.AppSettings["DBType"] = "POSTGRESQL";
            return RedirectToAction("FindAll", "TableStaj");

        }

        public ActionResult Hata(string hataMesaji)
        {
            ViewBag.HataMesaji = hataMesaji;
            return View();
        }


    }
}