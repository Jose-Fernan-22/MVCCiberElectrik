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
    public class EmpleadoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Empleado
        public ActionResult Index()
        {
            return View(db.empleado.ToList());
        }

        public ActionResult Create()
        {
            //valres para los combos 
            ViewBag.coddis = new SelectList(db.distrito, "codigo", "nombre");
            ViewBag.codrol = new SelectList(db.rol, "codigo", "nombre");
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codigo", "nombre");
            ViewBag.codsex = new SelectList(db.sexo, "codigo", "nombre");
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            // valores para los combos con el dato ya seleccionado
            ViewBag.coddis = new SelectList(db.distrito, "codigo", "nombre", empleado.coddis);
            ViewBag.codrol = new SelectList(db.rol, "codigo", "nombre", empleado.codrol);
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codigo", "nombre", empleado.codtipd);
            ViewBag.codsex = new SelectList(db.sexo, "codigo", "nombre", empleado.codsex);
            return View(empleado);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        //POST: Empleado Acciones

        [HttpPost]
        public ActionResult Create([Bind(Include = "nombre, apellidopaterno,apellidomaterno,documento, " +
            "direccion, telefono, celular, correo, usuario, clave, estado, coddis, codrol, codtipd, codsex")] Empleado obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.empleado.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                
            }
            // SI LLEGA HASTA AQUÍ ES PORQUE ALGO FALLÓ. RECARGAMOS LOS COMBOS Y MOSTRAMOS ERRORES
            ViewBag.coddis = new SelectList(db.distrito, "codigo", "nombre", obj.coddis);
            ViewBag.codrol = new SelectList(db.rol, "codigo", "nombre", obj.codrol);
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codigo", "nombre", obj.codtipd);
            ViewBag.codsex = new SelectList(db.sexo, "codigo", "nombre", obj.codsex);

            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Include = "codigo,nombre, apellidopaterno,apellidomaterno,documento, " +
            "direccion, telefono, celular, correo, usuario, clave, estado, coddis, codrol, codtipd, codsex")] Empleado obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            // SI ALGO FALLÓ AL EDITAR, VOLVEMOS A LLENAR LOS COMBOS
            ViewBag.coddis = new SelectList(db.distrito, "codigo", "nombre", obj.coddis);
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codigo", "nombre", obj.codtipd);
            ViewBag.codsex = new SelectList(db.sexo, "codigo", "nombre", obj.codsex);

            return View(obj);

        }

        [HttpPost]
        public ActionResult Delete(int? id, [Bind(Include = "codigo, nombre, estado")] Empleado obj)
        {
            try
            {
                var empleado = db.empleado.Find(id);
                if (empleado != null)
                {
                    empleado.estado = false;
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
        public ActionResult Enable(int? id, [Bind(Include = "codigo, nombre, estado")] Empleado obj)
        {
            try
            {
                var empleado = db.empleado.Find(id);
                if (empleado != null)
                {
                    empleado.estado = true;
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

        protected override void Dispose(bool disposing) {
            if (disposing) { 
                db.Dispose();
            }
                base.Dispose(disposing);
        }
    }
}