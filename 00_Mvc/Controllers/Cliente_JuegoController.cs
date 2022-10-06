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
    public class Cliente_JuegoController : Controller
    {
        private EmulatorDbContext db = new EmulatorDbContext();

        // GET: Cliente_Juego
        //public ActionResult Index()
        //{
        //    var cliente_Juego = db.Cliente_Juego.Include(c => c.Cliente).Include(c => c.Juego);
        //    return View(cliente_Juego.ToList());
        //}
        public ActionResult Index(int? id, bool? cliente_juego)

        {

            var juegos = db.Cliente_Juego.Include(p => p.Cliente).Include(p => p.Juego);

            //Si el método Index recibe un parámetro id != null y > 0 

            if (id != null && id > 0)

            {

                if (cliente_juego != null)

                {

                    if (cliente_juego == true)

                    {

                        juegos = juegos.Where(x => x.Cliente.id == id);

                        if (juegos != null && juegos.Count() > 0)

                        {

                            ViewBag.Message = "Nombre del Desarrollador : " + juegos.FirstOrDefault().Cliente.nombre +
                                "Login : " + juegos.FirstOrDefault().Cliente.login +
                                "Permisos : " + juegos.FirstOrDefault().Cliente.permisos +
                                "Contraseña : " + juegos.FirstOrDefault().Cliente.contraseña

                                ;


                        }

                    }

                    else

                    {

                        juegos = juegos.Where(x => x.Juego.id == id);

                        if (juegos != null && juegos.Count() > 0)

                        {

                            ViewBag.Message = "Nombre del Juego: " + juegos.FirstOrDefault().Juego.nombre +
                                "Fecha de lanzamiento: " + juegos.FirstOrDefault().Juego.fecha_lanzamiento


                                            ;

                        }

                    }

                }

            }
            return View(juegos.ToList());

        }
        // GET: Cliente_Juego/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente_Juego cliente_Juego = db.Cliente_Juego.Find(id);
            if (cliente_Juego == null)
            {
                return HttpNotFound();
            }
            return View(cliente_Juego);
        }

        // GET: Cliente_Juego/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.Cliente, "id", "nombre");
            ViewBag.id_juego = new SelectList(db.Juego, "id", "nombre");
            return View();
        }

        // POST: Cliente_Juego/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_cliente,id_juego")] Cliente_Juego cliente_Juego)
        {
            if (ModelState.IsValid)
            {
                db.Cliente_Juego.Add(cliente_Juego);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.Cliente, "id", "nombre", cliente_Juego.id_cliente);
            ViewBag.id_juego = new SelectList(db.Juego, "id", "nombre", cliente_Juego.id_juego);
            return View(cliente_Juego);
        }

        // GET: Cliente_Juego/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente_Juego cliente_Juego = db.Cliente_Juego.Find(id);
            if (cliente_Juego == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.Cliente, "id", "nombre", cliente_Juego.id_cliente);
            ViewBag.id_juego = new SelectList(db.Juego, "id", "nombre", cliente_Juego.id_juego);
            return View(cliente_Juego);
        }

        // POST: Cliente_Juego/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_cliente,id_juego")] Cliente_Juego cliente_Juego)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente_Juego).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.Cliente, "id", "nombre", cliente_Juego.id_cliente);
            ViewBag.id_juego = new SelectList(db.Juego, "id", "nombre", cliente_Juego.id_juego);
            return View(cliente_Juego);
        }

        // GET: Cliente_Juego/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente_Juego cliente_Juego = db.Cliente_Juego.Find(id);
            if (cliente_Juego == null)
            {
                return HttpNotFound();
            }
            return View(cliente_Juego);
        }

        // POST: Cliente_Juego/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente_Juego cliente_Juego = db.Cliente_Juego.Find(id);
            db.Cliente_Juego.Remove(cliente_Juego);
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
        // GET: api/Empleados/5 
        [HttpPost]

        //[ValidateInput(false)] 

        public ActionResult _Cliente_JuegoOtraPartialView(Cliente_Juego cliente_juego)

        {

            return View("_Cliente_JuegoOtraPartialView", cliente_juego);

        }

    }
}
