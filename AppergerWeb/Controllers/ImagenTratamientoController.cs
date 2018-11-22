using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppergerWeb.Models;

namespace AppergerWeb.Controllers
{
    public class ImagenTratamientoController : Controller
    {
        private appergerEntities1 db = new appergerEntities1();

        // GET: ImagenTratamiento
        public ActionResult Index()
        {
            var imagenTratamiento = db.ImagenTratamiento.Include(i => i.Imagen).Include(i => i.Tratamiento);
            return View(imagenTratamiento.ToList());
        }

        // GET: ImagenTratamiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagenTratamiento imagenTratamiento = db.ImagenTratamiento.Find(id);
            if (imagenTratamiento == null)
            {
                return HttpNotFound();
            }
            return View(imagenTratamiento);
        }

        // GET: ImagenTratamiento/Create
        public ActionResult Create()
        {
            ViewBag.nIdImagen = new SelectList(db.Imagen, "nIdImagen", "sDescripcion");
            ViewBag.nIdTratamiento = new SelectList(db.Tratamiento, "nIdTratamiento", "nIdTratamiento");
            return View();
        }

        // POST: ImagenTratamiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nIdImagenTra,nIdTratamiento,nIdImagen")] ImagenTratamiento imagenTratamiento)
        {
            if (ModelState.IsValid)
            {
                db.ImagenTratamiento.Add(imagenTratamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.nIdImagen = new SelectList(db.Imagen, "nIdImagen", "sImagen", imagenTratamiento.nIdImagen);
            ViewBag.nIdTratamiento = new SelectList(db.Tratamiento, "nIdTratamiento", "nIdTratamiento", imagenTratamiento.nIdTratamiento);
            return View(imagenTratamiento);
        }

        // GET: ImagenTratamiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagenTratamiento imagenTratamiento = db.ImagenTratamiento.Find(id);
            if (imagenTratamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.nIdImagen = new SelectList(db.Imagen, "nIdImagen", "sImagen", imagenTratamiento.nIdImagen);
            ViewBag.nIdTratamiento = new SelectList(db.Tratamiento, "nIdTratamiento", "nIdTratamiento", imagenTratamiento.nIdTratamiento);
            return View(imagenTratamiento);
        }

        // POST: ImagenTratamiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nIdImagenTra,nIdTratamiento,nIdImagen")] ImagenTratamiento imagenTratamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagenTratamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nIdImagen = new SelectList(db.Imagen, "nIdImagen", "sImagen", imagenTratamiento.nIdImagen);
            ViewBag.nIdTratamiento = new SelectList(db.Tratamiento, "nIdTratamiento", "nIdTratamiento", imagenTratamiento.nIdTratamiento);
            return View(imagenTratamiento);
        }

        // GET: ImagenTratamiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagenTratamiento imagenTratamiento = db.ImagenTratamiento.Find(id);
            if (imagenTratamiento == null)
            {
                return HttpNotFound();
            }
            return View(imagenTratamiento);
        }

        // POST: ImagenTratamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImagenTratamiento imagenTratamiento = db.ImagenTratamiento.Find(id);
            db.ImagenTratamiento.Remove(imagenTratamiento);
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
