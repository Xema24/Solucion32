using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _04_Data.Datos;

namespace _00_Mvc.Controllers
{
    public class DesarrolladorController : Controller
    {
        private EmulatorDbContext db = new EmulatorDbContext();

        // GET: Desarrollador
        public ActionResult Index()
        {
            return View(db.Desarrollador.ToList());
        }

        // GET: Desarrollador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desarrollador desarrollador = db.Desarrollador.Find(id);
            if (desarrollador == null)
            {
                return HttpNotFound();
            }
            return View(desarrollador);
        }

        // GET: Desarrollador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Desarrollador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,foto")] Desarrollador desarrollador)
        {
            if (ModelState.IsValid)
            {
                db.Desarrollador.Add(desarrollador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(desarrollador);
        }

        // GET: Desarrollador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desarrollador desarrollador = db.Desarrollador.Find(id);
            if (desarrollador == null)
            {
                return HttpNotFound();
            }
            return View(desarrollador);
        }

        // POST: Desarrollador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,foto")] Desarrollador desarrollador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(desarrollador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(desarrollador);
        }

        // GET: Desarrollador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desarrollador desarrollador = db.Desarrollador.Find(id);
            if (desarrollador == null)
            {
                return HttpNotFound();
            }
            return View(desarrollador);
        }

        // POST: Desarrollador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Desarrollador desarrollador = db.Desarrollador.Find(id);
            db.Desarrollador.Remove(desarrollador);
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
