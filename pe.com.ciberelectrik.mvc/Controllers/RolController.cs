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
    public class RolController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rol
        public ActionResult Index()
        {
            return View(db.rol.ToList());
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

            var rol = db.rol.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(rol);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var rol = db.rol.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(rol);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var rol = db.rol.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(rol);
            }
        }

        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var rol = db.rol.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(rol);
            }
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "nombre, estado")] Rol obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.rol.Add(obj);
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
        public ActionResult Edit(int? id, [Bind(Include = "codigo, nombre, estado")] Rol obj)
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
        public ActionResult Delete(int? id, [Bind(Include = "codigo, nombre, estado")] Rol obj)
        {
            try
            {
                var rol = db.rol.Find(id);
                if (rol != null)
                {
                    rol.estado = false;
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
                var rol = db.rol.Find(id);
                if (rol != null)
                {
                    rol.estado = true;
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