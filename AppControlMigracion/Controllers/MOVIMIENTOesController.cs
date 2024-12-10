using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AppControlMigracion.Controllers
{
    public class MOVIMIENTOesController : Controller
    {
        private DBControlMigracionEntities db = new DBControlMigracionEntities();

        // GET: MOVIMIENTOes
        public ActionResult Index()
        {
            var mOVIMIENTO = db.MOVIMIENTO.Include(m => m.ESTADOS).Include(m => m.USUARIO).Include(m => m.VIAJEROS);
            return View(mOVIMIENTO.ToList());
        }

        // GET: MOVIMIENTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIMIENTO mOVIMIENTO = db.MOVIMIENTO.Find(id);
            if (mOVIMIENTO == null)
            {
                return HttpNotFound();
            }
            return View(mOVIMIENTO);
        }

        // GET: MOVIMIENTOes/Create
        public ActionResult Create()
        {
            ViewBag.idEstado = new SelectList(db.ESTADOS, "idEstado", "descripcion");
            ViewBag.idUsuario = new SelectList(db.USUARIO, "idUsuario", "nombre");
            ViewBag.idViajero = new SelectList(db.VIAJEROS, "id", "nombre");
            return View();
        }

        // POST: MOVIMIENTOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMovimientoViajero,fecha,destino,origen,tipoSolicitud,idUsuario,idEstado,idViajero")] MOVIMIENTO mOVIMIENTO)
        {
            if (ModelState.IsValid)
            {
                db.MOVIMIENTO.Add(mOVIMIENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstado = new SelectList(db.ESTADOS, "idEstado", "descripcion", mOVIMIENTO.idEstado);
            ViewBag.idUsuario = new SelectList(db.USUARIO, "idUsuario", "nombre", mOVIMIENTO.idUsuario);
            ViewBag.idViajero = new SelectList(db.VIAJEROS, "id", "nombre", mOVIMIENTO.idViajero);
            return View(mOVIMIENTO);
        }

        // GET: MOVIMIENTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIMIENTO mOVIMIENTO = db.MOVIMIENTO.Find(id);
            if (mOVIMIENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstado = new SelectList(db.ESTADOS, "idEstado", "descripcion", mOVIMIENTO.idEstado);
            ViewBag.idUsuario = new SelectList(db.USUARIO, "idUsuario", "nombre", mOVIMIENTO.idUsuario);
            ViewBag.idViajero = new SelectList(db.VIAJEROS, "id", "nombre", mOVIMIENTO.idViajero);
            return View(mOVIMIENTO);
        }

        // POST: MOVIMIENTOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMovimientoViajero,fecha,destino,origen,tipoSolicitud,idUsuario,idEstado,idViajero")] MOVIMIENTO mOVIMIENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mOVIMIENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstado = new SelectList(db.ESTADOS, "idEstado", "descripcion", mOVIMIENTO.idEstado);
            ViewBag.idUsuario = new SelectList(db.USUARIO, "idUsuario", "nombre", mOVIMIENTO.idUsuario);
            ViewBag.idViajero = new SelectList(db.VIAJEROS, "id", "nombre", mOVIMIENTO.idViajero);
            return View(mOVIMIENTO);
        }

        // GET: MOVIMIENTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIMIENTO mOVIMIENTO = db.MOVIMIENTO.Find(id);
            if (mOVIMIENTO == null)
            {
                return HttpNotFound();
            }
            return View(mOVIMIENTO);
        }

        // POST: MOVIMIENTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MOVIMIENTO mOVIMIENTO = db.MOVIMIENTO.Find(id);
            db.MOVIMIENTO.Remove(mOVIMIENTO);
            db.SaveChanges();
            return RedirectToAction("Index");
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
