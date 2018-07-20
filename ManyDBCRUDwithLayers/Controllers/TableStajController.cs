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

        // POST: TableStaj/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TableStaj/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TableStaj/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
