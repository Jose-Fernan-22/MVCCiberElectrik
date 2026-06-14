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
    public class TipoDocumentoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoDocumento
        public ActionResult Index()
        {
            return View(db.tipodocumento.ToList());
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

            var tipoDocumento = db.tipodocumento.Find(id);
            if (tipoDocumento == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tipoDocumento);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tipoDocumento = db.tipodocumento.Find(id);
            if (tipoDocumento == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tipoDocumento);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tipoDocumento = db.tipodocumento.Find(id);
            if (tipoDocumento == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tipoDocumento);
            }
        }

        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tipoDocumento = db.tipodocumento.Find(id);
            if (tipoDocumento == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tipoDocumento);
            }
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "nombre, estado")] TipoDocumento obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.tipodocumento.Add(obj);
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
        public ActionResult Edit(int? id, [Bind(Include = "codigo, nombre, estado")] TipoDocumento obj)
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
        public ActionResult Delete(int? id, [Bind(Include = "codigo, nombre, estado")] TipoDocumento obj)
        {
            try
            {
                var tipoDocumento = db.tipodocumento.Find(id);
                if (tipoDocumento != null)
                {
                    tipoDocumento.estado = false;
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
        public ActionResult Enable(int? id, [Bind(Include = "codigo, nombre, estado")] Rol obj)
        {
            try
            {
                var tipoDocumento = db.tipodocumento.Find(id);
                if (tipoDocumento != null)
                {
                    tipoDocumento.estado = true;
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