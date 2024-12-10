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
    public class VIAJEROSController : Controller
    {
        private DBControlMigracionEntities db = new DBControlMigracionEntities();

        // GET: VIAJEROS
        public ActionResult Index()
        {
            return View(db.VIAJEROS.ToList());
        }

        // GET: VIAJEROS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIAJEROS vIAJEROS = db.VIAJEROS.Find(id);
            if (vIAJEROS == null)
            {
                return HttpNotFound();
            }
            return View(vIAJEROS);
        }

        // GET: VIAJEROS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VIAJEROS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,segundo,apellido1,apellido2,fechaNacimiento,nacionalidad,correoElectronico,genero")] VIAJEROS vIAJEROS)
        {
            if (ModelState.IsValid)
            {
                db.VIAJEROS.Add(vIAJEROS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vIAJEROS);
        }

        // GET: VIAJEROS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIAJEROS vIAJEROS = db.VIAJEROS.Find(id);
            if (vIAJEROS == null)
            {
                return HttpNotFound();
            }
            return View(vIAJEROS);
        }

        // POST: VIAJEROS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,segundo,apellido1,apellido2,fechaNacimiento,nacionalidad,correoElectronico,genero")] VIAJEROS vIAJEROS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vIAJEROS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vIAJEROS);
        }

        // GET: VIAJEROS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIAJEROS vIAJEROS = db.VIAJEROS.Find(id);
            if (vIAJEROS == null)
            {
                return HttpNotFound();
            }
            return View(vIAJEROS);
        }

        // POST: VIAJEROS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VIAJEROS vIAJEROS = db.VIAJEROS.Find(id);
            db.VIAJEROS.Remove(vIAJEROS);
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
