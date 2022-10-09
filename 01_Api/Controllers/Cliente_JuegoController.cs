using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using _04_Data.Datos;

namespace _01_Api.Controllers
{
    public class Cliente_JuegoController : ApiController
    {
        private EmulatorDbContext db = new EmulatorDbContext();

        // GET: api/Cliente_Juegos
        public IQueryable<Cliente_Juego> GetCliente_Juego()
        {
            return db.Cliente_Juego;
        }

        // GET: api/Cliente_Juegos/5
        [ResponseType(typeof(Cliente_Juego))]
        public IHttpActionResult GetCliente_Juego(int id)
        {
            Cliente_Juego cliente_Juego = db.Cliente_Juego.Find(id);
            if (cliente_Juego == null)
            {
                return NotFound();
            }

            return Ok(cliente_Juego);
        }

        // PUT: api/Cliente_Juegos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCliente_Juego(int id, Cliente_Juego cliente_Juego)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente_Juego.id)
            {
                return BadRequest();
            }

            db.Entry(cliente_Juego).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cliente_JuegoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cliente_Juegos
        [ResponseType(typeof(Cliente_Juego))]
        public IHttpActionResult PostCliente_Juego(Cliente_Juego cliente_Juego)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cliente_Juego.Add(cliente_Juego);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cliente_Juego.id }, cliente_Juego);
        }

        // DELETE: api/Cliente_Juegos/5
        [ResponseType(typeof(Cliente_Juego))]
        public IHttpActionResult DeleteCliente_Juego(int id)
        {
            Cliente_Juego cliente_Juego = db.Cliente_Juego.Find(id);
            if (cliente_Juego == null)
            {
                return NotFound();
            }

            db.Cliente_Juego.Remove(cliente_Juego);
            db.SaveChanges();

            return Ok(cliente_Juego);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Cliente_JuegoExists(int id)
        {
            return db.Cliente_Juego.Count(e => e.id == id) > 0;
        }



        [ResponseType(typeof(Cliente_Juego))]
        public IHttpActionResult Getpelicula(int? id, int? siguiente)
        {
            Cliente_Juego peliculaTabla = null;
            if (siguiente == null)
            {
                peliculaTabla = db.Cliente_Juego.Where(x => x.id == id.Value).FirstOrDefault();
            }
            else
            {
                if (siguiente.Value == 1)
                {
                    peliculaTabla = db.Cliente_Juego.Where(x => x.id > id.Value).FirstOrDefault();
                }
                else
                {
                    IList<Cliente_Juego> peliculaTablas = db.Cliente_Juego.Where(x => x.id < id.Value).ToList();
                    if (peliculaTablas != null && peliculaTablas.Count() > 0)
                    {
                        int? idpelicula = peliculaTablas.Max(x => x.id);
                        peliculaTabla = db.Cliente_Juego.Where(x => x.id == idpelicula.Value).FirstOrDefault();
                    }
                }
            }
            if (peliculaTabla == null)
            {
                peliculaTabla = db.Cliente_Juego.Where(x => x.id == id.Value).FirstOrDefault();
            }
            Cliente_Juego pelicula = new Cliente_Juego();
            pelicula.id = peliculaTabla.id;
            pelicula.id_cliente = peliculaTabla.id_cliente;
            pelicula.id_juego = peliculaTabla.id_juego;
            pelicula.Cliente = peliculaTabla.Cliente;
            pelicula.Juego = peliculaTabla.Juego;
            

            return Ok(pelicula);
        }



    }
}