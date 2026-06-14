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
    public class SexoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: SexoController
        public ActionResult Index()
        {
            return View(db.sexo.ToList());
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

            var sexo = db.sexo.Find(id);
            if (sexo == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(sexo);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var sexo = db.sexo.Find(id);
            if (sexo == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(sexo);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var sexo = db.sexo.Find(id);
            if (sexo == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(sexo);
            }
        }

        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var sexo = db.sexo.Find(id);
            if (sexo == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(sexo);
            }
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "nombre, estado")] Sexo obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.sexo.Add(obj);
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
        public ActionResult Edit(int? id, [Bind(Include = "codigo, nombre, estado")] Sexo obj)
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
        public ActionResult Delete(int? id, [Bind(Include = "codigo, nombre, estado")] Sexo obj)
        {
            try
            {
                var sexo = db.sexo.Find(id);
                if (sexo != null)
                {
                    sexo.estado = false;
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
        public ActionResult Enable(int? id, [Bind(Include = "codigo, nombre, estado")] Sexo obj)
        {
            try
            {
                var sexo = db.sexo.Find(id);
                if (sexo != null)
                {
                    sexo.estado = true;
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