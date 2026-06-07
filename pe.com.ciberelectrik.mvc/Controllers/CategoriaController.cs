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

    //controlador es un controlador web -> maneja las acciones de la aplicacion web 
    // hereda de Controller
    public class CategoriaController : Controller
    {
        //creamos un objeto del contexto
        ApplicationDbContext db = new ApplicationDbContext();

        //primero manejamos las rutas 
        // GET: Categoria
        //[HttpGet] -> se entiende por defecto
        //listar

        public ActionResult Index()
        {
            return View(db.categoria.ToList());
        }

        //GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }
        // GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null) { 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var categoria = db.categoria.Find(id);
            if( categoria == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoria);
            }
            
        }
        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var categoria = db.categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoria);
            }

        }

        //GET: Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var categoria = db.categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoria);
            }

        }
        //GET: Categoria/Enable/5
        
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var categoria = db.categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoria);
            }

        }

        //acciones -> Post
        //POST: Categoria/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "nombre, estado")] Categoria obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.categoria.Add(obj);
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

        //POST: Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Include = "codigo, nombre, estado")] Categoria obj)
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

        //POST: Categoria/Delete/5
        //Eliminacion fisica
        //[HttpPost]
        //public ActionResult Delete(int? id, [Bind(Include = "codigo, nombre, estado")] Categoria obj)
        //{
        //    try
        //    {


        //        db.categoria.Remove(obj);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");

        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //        return View();
        //    }
        //}

        [HttpPost]
        public ActionResult Delete(int? id, [Bind(Include = "codigo, nombre, estado")] Categoria obj)
        {
            try
            {
                var categoria = db.categoria.Find(id);
                if( categoria != null)
                {
                    categoria.estado = false;
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

        //POST: Categiria/Enable/5
        [HttpPost]
        public ActionResult Enable(int? id, [Bind(Include = "codigo, nombre, estado")] Categoria obj)
        {
            try
            {
                var categoria = db.categoria.Find(id);
                if (categoria != null)
                {
                    categoria.estado = true;
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

        //limpiamos los obj de memoria
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}