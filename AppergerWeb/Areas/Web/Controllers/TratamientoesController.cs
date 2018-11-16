using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppergerWeb.Models;

namespace AppergerWeb.Areas.Web.Controllers
{
    public class TratamientoesController : Controller
    {
        private appergerEntities1 db = new appergerEntities1();

        // GET: Web/Tratamientoes
        public ActionResult Index()
        {
            var tratamiento = db.Tratamiento.Include(t => t.usuario).Include(t => t.usuario1);
            return View(tratamiento.ToList());
        }

        // GET: Web/Tratamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento tratamiento = db.Tratamiento.Find(id);
            if (tratamiento == null)
            {
                return HttpNotFound();
            }
            return View(tratamiento);
        }

        // GET: Web/Tratamientoes/Create
        public ActionResult Create()
        {
            ViewBag.nIdPaciente = new SelectList(db.usuario, "nIdUsuario", "sUsuario");
            ViewBag.nIdPsicologo = new SelectList(db.usuario, "nIdUsuario", "sUsuario");
            return View();
        }

        // POST: Web/Tratamientoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nIdTratamiento,dFechaInicio,dFechaFin,bSelfie,bImagen,bVideo,nIdPsicologo,nIdPaciente")] Tratamiento tratamiento)
        {
            if (ModelState.IsValid)
            {
                db.Tratamiento.Add(tratamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.nIdPaciente = new SelectList(db.usuario, "nIdUsuario", "sUsuario", tratamiento.nIdPaciente);
            ViewBag.nIdPsicologo = new SelectList(db.usuario, "nIdUsuario", "sUsuario", tratamiento.nIdPsicologo);
            return View(tratamiento);
        }

        // GET: Web/Tratamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento tratamiento = db.Tratamiento.Find(id);
            if (tratamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.nIdPaciente = new SelectList(db.usuario, "nIdUsuario", "sUsuario", tratamiento.nIdPaciente);
            ViewBag.nIdPsicologo = new SelectList(db.usuario, "nIdUsuario", "sUsuario", tratamiento.nIdPsicologo);
            return View(tratamiento);
        }

        // POST: Web/Tratamientoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nIdTratamiento,dFechaInicio,dFechaFin,bSelfie,bImagen,bVideo,nIdPsicologo,nIdPaciente")] Tratamiento tratamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tratamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nIdPaciente = new SelectList(db.usuario, "nIdUsuario", "sUsuario", tratamiento.nIdPaciente);
            ViewBag.nIdPsicologo = new SelectList(db.usuario, "nIdUsuario", "sUsuario", tratamiento.nIdPsicologo);
            return View(tratamiento);
        }

        // GET: Web/Tratamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento tratamiento = db.Tratamiento.Find(id);
            if (tratamiento == null)
            {
                return HttpNotFound();
            }
            return View(tratamiento);
        }

        // POST: Web/Tratamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tratamiento tratamiento = db.Tratamiento.Find(id);
            db.Tratamiento.Remove(tratamiento);
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
