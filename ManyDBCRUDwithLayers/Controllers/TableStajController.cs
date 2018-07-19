using ManyDBCRUDwithLayers.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManyDBCRUDwithLayers.Controllers
{
    public class TableStajController : Controller
    {

        public LayerBaseDB myDB = new LayerPostgreSql();
        public ActionResult Index()
        {
            return View(myDB.FindAll());
        }

        // GET: TableStaj/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TableStaj/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TableStaj/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TableStaj/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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
