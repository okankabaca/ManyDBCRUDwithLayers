using ManyDBCRUDwithLayers.App_Start;
using ManyDBCRUDwithLayers.Layers;
using ManyDBCRUDwithLayers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManyDBCRUDwithLayers.Controllers
{
    public class TableStajController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FindAll()
        {
            if (Global.myDB != null)
                return View(Global.myDB.FindAll());

            return RedirectToAction("Hata", "Home", new { hataMesaji = "DB has not found" });
        }

        // GET: TableStaj/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TableStaj/Create
        public ActionResult Create()
        {
            return View(new TableStajModel());
        }

        // POST: TableStaj/Create
        [HttpPost]
        public ActionResult Create(TableStajModel tableStajModel)
        {
            int result;
            result = Global.myDB.Create(tableStajModel);

            if (result > 0)
                return RedirectToAction("FindAll", "TableStaj");

            return RedirectToAction("Hata", "Home", new { hataMesaji = "Create error" });

        }

        public ActionResult Edit(int id)
        {
            if (Global.myDB != null)
                return View(Global.myDB.FindOne(id));

            return RedirectToAction("Hata", "Home", new { hataMesaji = "DB has not found" });
        }

        [HttpPost]
        public ActionResult Edit(int id, TableStajModel tableStajModel)
        {
            int result = -1;
            if (Global.myDB != null)
                result = Global.myDB.Edit(id, tableStajModel);
            else
                return RedirectToAction("Hata", "Home", new { hataMesaji = "DB has not found" });

            if (result > 0)
                return RedirectToAction("FindAll", "TableStaj");

            return RedirectToAction("Hata", "Home", new { hataMesaji = "Edit Error" });

        }

        [HttpPost]
        public int Delete(int id)
        {
            int result = -1;
            if (Global.myDB != null)
                result = Global.myDB.Delete(id);

            return result;
        }


    }
}
