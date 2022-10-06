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
    public class PlataformaController : Controller
    {
        private EmulatorDbContext db = new EmulatorDbContext();

        // GET: Plataforma
        public ActionResult Index()
        {
            return View(db.Plataforma.ToList());
        }

        // GET: Plataforma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plataforma plataforma = db.Plataforma.Find(id);
            if (plataforma == null)
            {
                return HttpNotFound();
            }
            return View(plataforma);
        }

        // GET: Plataforma/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plataforma/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,foto")] Plataforma plataforma)
        {
            if (ModelState.IsValid)
            {
                db.Plataforma.Add(plataforma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plataforma);
        }

        // GET: Plataforma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plataforma plataforma = db.Plataforma.Find(id);
            if (plataforma == null)
            {
                return HttpNotFound();
            }
            return View(plataforma);
        }

        // POST: Plataforma/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,foto")] Plataforma plataforma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plataforma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plataforma);
        }

        // GET: Plataforma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plataforma plataforma = db.Plataforma.Find(id);
            if (plataforma == null)
            {
                return HttpNotFound();
            }
            return View(plataforma);
        }

        // POST: Plataforma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plataforma plataforma = db.Plataforma.Find(id);
            db.Plataforma.Remove(plataforma);
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
