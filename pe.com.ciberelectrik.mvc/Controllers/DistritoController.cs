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
    public class DistritoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Distrito
        public ActionResult Index()
        {
            return View(db.distrito.ToList());
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

            var distrito = db.distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(distrito);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var distrito = db.distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(distrito);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var distrito = db.distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(distrito);
            }
        }

        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var distrito = db.distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(distrito);
            }
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "nombre, estado")] Distrito obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.distrito.Add(obj);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
                
            } catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Include = "codigo, nombre, estado")] Distrito obj)
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
        public ActionResult Delete(int? id, [Bind(Include = "codigo, nombre, estado")] Distrito obj)
        {
            try
            {
                var distrito = db.distrito.Find(id);
                if (distrito != null)
                {
                    distrito.estado = false;
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
        public ActionResult Enable(int? id, [Bind(Include = "codigo, nombre, estado")] Distrito obj)
        {
            try
            {
                var distrito = db.distrito.Find(id);
                if (distrito != null )
                {
                    distrito.estado = true;
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