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
    public class JuegoController : Controller
    {
        private EmulatorDbContext db = new EmulatorDbContext();

        // GET: Juego
        //public ActionResult Index()
        //{
        //    var juego = db.Juego.Include(j => j.Desarrollador).Include(j => j.Distribuidor).Include(j => j.Plataforma);
        //    return View(juego.ToList());
        //}


        public ActionResult Index(int? id, bool? juego)

        {

            var juegos = db.Juego.Include(p => p.Desarrollador).Include(p => p.Distribuidor);

            //Si el método Index recibe un parámetro id != null y > 0 

            if (id != null && id > 0)

            {

                if (juego != null)

                {

                    if (juego == true)

                    {

                        juegos = juegos.Where(x => x.Desarrollador.id == id);

                        if (juegos != null && juegos.Count() > 0)

                        {

                            ViewBag.Message = "Nombre del Desarrollador : " + juegos.FirstOrDefault().Desarrollador.nombre;
                             

                        }

                    }

                    else

                    {

                        juegos = juegos.Where(x => x.Distribuidor.id == id);

                        if (juegos != null && juegos.Count() > 0)

                        {

                            ViewBag.Message = "Nombre del Distribuidor: " + juegos.FirstOrDefault().Distribuidor.nombre 
                               

                                            ;

                        }

                    }

                }

            }

            return View(juegos.ToList());

        }
        // GET: Juego/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juego juego = db.Juego.Find(id);
            if (juego == null)
            {
                return HttpNotFound();
            }
            return View(juego);
        }

        // GET: Juego/Create
        public ActionResult Create()
        {
            ViewBag.id_desarrollador = new SelectList(db.Desarrollador, "id", "nombre");
            ViewBag.id_distribuidor = new SelectList(db.Distribuidor, "id", "nombre");
            ViewBag.id_plataforma = new SelectList(db.Plataforma, "id", "nombre");
            return View();
        }

        // POST: Juego/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,id_plataforma,id_distribuidor,id_desarrollador,fecha_lanzamiento,foto")] Juego juego)
        {
            if (ModelState.IsValid)
            {
                db.Juego.Add(juego);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_desarrollador = new SelectList(db.Desarrollador, "id", "nombre", juego.id_desarrollador);
            ViewBag.id_distribuidor = new SelectList(db.Distribuidor, "id", "nombre", juego.id_distribuidor);
            ViewBag.id_plataforma = new SelectList(db.Plataforma, "id", "nombre", juego.id_plataforma);
            return View(juego);
        }

        // GET: Juego/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juego juego = db.Juego.Find(id);
            if (juego == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_desarrollador = new SelectList(db.Desarrollador, "id", "nombre", juego.id_desarrollador);
            ViewBag.id_distribuidor = new SelectList(db.Distribuidor, "id", "nombre", juego.id_distribuidor);
            ViewBag.id_plataforma = new SelectList(db.Plataforma, "id", "nombre", juego.id_plataforma);
            return View(juego);
        }

        // POST: Juego/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,id_plataforma,id_distribuidor,id_desarrollador,fecha_lanzamiento,foto")] Juego juego)
        {
            if (ModelState.IsValid)
            {
                db.Entry(juego).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_desarrollador = new SelectList(db.Desarrollador, "id", "nombre", juego.id_desarrollador);
            ViewBag.id_distribuidor = new SelectList(db.Distribuidor, "id", "nombre", juego.id_distribuidor);
            ViewBag.id_plataforma = new SelectList(db.Plataforma, "id", "nombre", juego.id_plataforma);
            return View(juego);
        }

        // GET: Juego/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juego juego = db.Juego.Find(id);
            if (juego == null)
            {
                return HttpNotFound();
            }
            return View(juego);
        }

        // POST: Juego/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Juego juego = db.Juego.Find(id);
            db.Juego.Remove(juego);
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
