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
    public class ProductoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        //rutas
        public ActionResult Index()
        {
            return View(db.producto.ToList());
        }

        public ActionResult Create()
        {
            //valores del combo
            ViewBag.codcat = new SelectList(db.categoria, "codigo", "nombre");
            ViewBag.codmar = new SelectList(db.marca, "codigo", "nombre");
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            else
            {
                //valores del combo
                ViewBag.codcat = new SelectList(db.categoria, "codigo", "nombre", producto.codcat);
                ViewBag.codmar = new SelectList(db.marca, "codigo", "nombre", producto.codmar);
                return View(producto);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(producto);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(producto);
            }
        }

        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(producto);
            }
        }

        //acciones -> Post
        [HttpPost]
        public ActionResult Create([Bind(Include = "nombre,descripcion,precio,cantidad," +
            "fechaingreso,estado,codmar,codcat")] Producto obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.producto.Add(obj);
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
        public ActionResult Edit(int? id, [Bind(Include = "codigo,nombre,descripcion,precio," +
            "cantidad,fechaingreso,estado,codmar,codcat")] Producto obj)
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
        public ActionResult Delete(int? id, [Bind(Include = "codigo,nombre,estado")] Producto obj)
        {
            try
            {
                var producto = db.producto.Find(id);
                if (producto != null)
                {
                    producto.estado = false;
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
        public ActionResult Enable(int? id, [Bind(Include = "codigo,nombre,estado")] Producto obj)
        {
            try
            {
                var producto = db.producto.Find(id);
                if (producto != null)
                {
                    producto.estado = true;
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

        //limpiamos los objeto de memoria
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
