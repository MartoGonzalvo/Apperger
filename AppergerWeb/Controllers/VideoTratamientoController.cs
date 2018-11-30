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
    public class VideoTratamientoController : Controller
    {
        private appergerEntities1 db = new appergerEntities1();

        // GET: VideoTratamiento
        public ActionResult Index(int tratamientoId)
        {
            var usuario = db.Tratamiento.Single(x => x.nIdTratamiento == tratamientoId);
            ViewBag.Usuario = usuario.usuario.sNombre + ' ' + usuario.usuario.sApellido;
            ViewBag.tratamientoId = tratamientoId;
            var videoTratamiento = db.VideoTratamiento.Where(x => x.nIdTratamiento == tratamientoId);
            
            return View(videoTratamiento.ToList());
        }

        // GET: VideoTratamiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoTratamiento videoTratamiento = db.VideoTratamiento.Find(id);
            if (videoTratamiento == null)
            {
                return HttpNotFound();
            }
            return View(videoTratamiento);
        }

        // GET: VideoTratamiento/Create
        public ActionResult Create(int tratamientoId)
        {
            ViewBag.tratamientoId = tratamientoId;
            ViewBag.nIdVideo = new SelectList(db.Video, "nIdVideo", "sDescripcion");
            ViewBag.nIdTratamiento = new SelectList(db.Tratamiento, "nIdTratamiento", "nIdTratamiento");
            return View();
        }

        // POST: ImagenTratamiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nIdImagenTra,nIdTratamiento,nIdVideo")] VideoTratamiento videoTratamiento, int tratamientoId)
        {
            if (ModelState.IsValid)
            {
               videoTratamiento.nIdTratamiento = tratamientoId;
                db.VideoTratamiento.Add(videoTratamiento);
                db.SaveChanges();
                return RedirectToAction("Index", new { tratamientoId = tratamientoId });
            }
            ViewBag.nIdVideo = new SelectList(db.Video, "nIdVideo", "sVideo", videoTratamiento.nIdVideo);
            ViewBag.nIdTratamiento = new SelectList(db.Tratamiento, "nIdTratamiento", "nIdTratamiento", videoTratamiento.nIdTratamiento);
            return View(videoTratamiento);
         
        }

        // GET: VideoTratamiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoTratamiento videoTratamiento = db.VideoTratamiento.Find(id);
            if (videoTratamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.nIdVideo = new SelectList(db.Video, "nIdVideo", "sVideo", videoTratamiento.nIdVideo);
            ViewBag.nIdTratamiento = new SelectList(db.Tratamiento, "nIdTratamiento", "nIdTratamiento", videoTratamiento.nIdTratamiento);
            return View(videoTratamiento);
        }

        // POST: ImagenTratamiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nIdVideoTra,nIdTratamiento,nIdVideo")] VideoTratamiento videoTratamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoTratamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { tratamientoId = videoTratamiento.nIdTratamiento });
            }
            ViewBag.nIdVideo = new SelectList(db.Imagen, "nIdVideo", "sVideo", videoTratamiento.nIdVideo);
            ViewBag.nIdTratamiento = new SelectList(db.Tratamiento, "nIdTratamiento", "nIdTratamiento", videoTratamiento.nIdTratamiento);
            return View(videoTratamiento);
        }

        // GET: VideoTratamiento/Delete/5
        public ActionResult Delete(int? id, int tratamientoId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoTratamiento videoTratamiento = db.VideoTratamiento.Find(id);
            if (videoTratamiento == null)
            {
                return HttpNotFound();
            }
            db.VideoTratamiento.Remove(videoTratamiento);
            db.SaveChanges();
            return RedirectToAction("Index", new { tratamientoId = tratamientoId });
        }

        // POST: VideoTratamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoTratamiento videoTratamiento = db.VideoTratamiento.Find(id);
            db.VideoTratamiento.Remove(videoTratamiento);
            db.SaveChanges();
            return RedirectToAction("Index", new { tratamientoId = videoTratamiento.nIdTratamiento});
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
