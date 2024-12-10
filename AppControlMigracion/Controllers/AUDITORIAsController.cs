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
    public class AUDITORIAsController : Controller
    {
        private DBControlMigracionEntities db = new DBControlMigracionEntities();

        // GET: AUDITORIAs
        public ActionResult Index()
        {
            var aUDITORIA = db.AUDITORIA.Include(a => a.USUARIO);
            return View(aUDITORIA.ToList());
        }

        // GET: AUDITORIAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUDITORIA aUDITORIA = db.AUDITORIA.Find(id);
            if (aUDITORIA == null)
            {
                return HttpNotFound();
            }
            return View(aUDITORIA);
        }

        // GET: AUDITORIAs/Create
        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.USUARIO, "idUsuario", "nombre");
            return View();
        }

        // POST: AUDITORIAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAuditoria,idUsuario,fechaAccion,descripcion")] AUDITORIA aUDITORIA)
        {
            if (ModelState.IsValid)
            {
                db.AUDITORIA.Add(aUDITORIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.USUARIO, "idUsuario", "nombre", aUDITORIA.idUsuario);
            return View(aUDITORIA);
        }

        // GET: AUDITORIAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUDITORIA aUDITORIA = db.AUDITORIA.Find(id);
            if (aUDITORIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.USUARIO, "idUsuario", "nombre", aUDITORIA.idUsuario);
            return View(aUDITORIA);
        }

        // POST: AUDITORIAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAuditoria,idUsuario,fechaAccion,descripcion")] AUDITORIA aUDITORIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aUDITORIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.USUARIO, "idUsuario", "nombre", aUDITORIA.idUsuario);
            return View(aUDITORIA);
        }

        // GET: AUDITORIAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUDITORIA aUDITORIA = db.AUDITORIA.Find(id);
            if (aUDITORIA == null)
            {
                return HttpNotFound();
            }
            return View(aUDITORIA);
        }

        // POST: AUDITORIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AUDITORIA aUDITORIA = db.AUDITORIA.Find(id);
            db.AUDITORIA.Remove(aUDITORIA);
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
