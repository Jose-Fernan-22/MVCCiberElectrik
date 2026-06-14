using pe.com.ciberelectrik.mvc.Models;
using pe.com.ciberelectrik.mvc.Models.db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace pe.com.ciberelectrik.mvc.Controllers
{
    public class ClienteController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Cliente
        public ActionResult Index()
        {
            return View(db.cliente.ToList());
        }

        public ActionResult Create()
        {
            //valres para los combos 
            ViewBag.coddis = new SelectList(db.distrito, "codigo", "nombre");
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
            var cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            // valores para los combos con el dato ya seleccionado
            ViewBag.coddis = new SelectList(db.distrito, "codigo", "nombre", cliente.coddis);
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codigo", "nombre", cliente.codtipd);
            ViewBag.codsex = new SelectList(db.sexo, "codigo", "nombre", cliente.codsex);
            return View(cliente);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente
        [HttpPost]
        public ActionResult Create([Bind(Include = "nombre, apellidopaterno, apellidomaterno, documento, " +
            "direccion, telefono, celular, correo, estado, coddis, codtipd, codsex")] Cliente obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.cliente.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index");//solamenete salimos de aqui si se guardo con exito
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            ViewBag.coddis = new SelectList(db.distrito, "codigo", "nombre", obj.coddis);
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codigo", "nombre", obj.codtipd);
            ViewBag.codsex = new SelectList(db.sexo, "codigo", "nombre", obj.codsex);
            return View(obj);//mostramos el formulario nuevo con sus errores en rojo
        }


        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Include = "codigo, nombre, apellidopaterno, apellidomaterno, documento, " +
            "direccion, telefono, celular, correo, estado, coddis, codtipd, codsex")] Cliente obj)
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
            // Si algo falla en la edición, recargamos las listas desplegables
            ViewBag.coddis = new SelectList(db.distrito, "codigo", "nombre", obj.coddis);
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codigo", "nombre", obj.codtipd);
            ViewBag.codsex = new SelectList(db.sexo, "codigo", "nombre", obj.codsex);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Delete(int? id, [Bind(Include = "codigo, nombre, estado")] Cliente obj)
        {
            try
            {
                var cliente = db.cliente.Find(id);
                if (cliente != null)
                {
                    cliente.estado = false;
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
        public ActionResult Enable(int? id, [Bind(Include = "codigo, nombre, estado")] Cliente obj)
        {
            try
            {
                var cliente = db.cliente.Find(id);
                if (cliente != null)
                {
                    cliente.estado = true;
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