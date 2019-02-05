using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CursoASP.NETMVC.Models;

namespace CursoASP.NETMVC.Controllers
{
    public class PersonasController : Controller
    {
        private ApplicationDbContex db = new ApplicationDbContex();

        // GET: Personas
        public ActionResult Index()
        {
            //var persona = db.Persona.Include("Direcciones").FirstOrDefault(x => x.Id == 2);
            //var direcciones = persona.Direcciones;
            var direccion = db.Direccion.FirstOrDefault(x => x.CodigoDirección == 4);
            var nombre = direccion.Persona.Nombre;
            return View(db.Persona.ToList());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Fecha,Edad")] Persona persona)
        {
            if (ModelState.IsValid)
            {
               // db.Persona.AddRange();Con este metodo le puedo pasar un listado de personas

                db.Persona.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(persona);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Fecha,Edad")] Persona persona)
        {
            //Método 1: Trae el objeto y lo actualiza
            var personaEditar = db.Persona.FirstOrDefault(x => x.Id == 2);
            personaEditar.Nombre = "Editado metodo 1";
            personaEditar.Edad = personaEditar.Edad + 1;
            db.SaveChanges();

            // Método 2: Actualización parcial
            var personaEditar2 = new Persona();
            personaEditar2.Nombre = "Editado metodo 2";
            personaEditar2.Edad = 33;
            db.Persona.Attach(personaEditar2);
            db.Entry(personaEditar2).Property(x => x.Nombre).IsModified = true;
            db.SaveChanges();


            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(persona);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Persona.Find(id);
            db.Persona.Remove(persona);
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
