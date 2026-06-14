using pe.com.ciberelectrik.mvc.Models;
using pe.com.ciberelectrik.mvc.Models.db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace pe.com.ciberelectrik.mvc.Controllers
{
    public class MarcaController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Marca
        public ActionResult Index()
        {
            return View(db.marca.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var marca = db.marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(marca);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var marca = db.marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            } else
            {
                return View(marca);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var marca = db.marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(marca);
            }
        }

        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var marca = db.marca.Find(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(marca);
            }
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "nombre, estado")] Marca obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.marca.Add(obj);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Include = "codigo, nombre, estado")] Marca obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int? id, [Bind(Include = "codigo, nombre, estado")] Marca obj)
        {
            try
            {
                var marca = db.marca.Find(id);
                if (marca != null)
                {
                    marca.estado = false;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View();
            }
        }

        [HttpPost]
        public ActionResult Enable(int? id, [Bind(Include = "codigo, nombre, estado")] Marca obj)
        {
            try
            {
                var marca = db.marca.Find(id);
                if (marca != null)
                {
                    marca.estado = true;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}