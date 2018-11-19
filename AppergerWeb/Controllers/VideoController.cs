using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppergerWeb.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;

namespace AppergerWeb.Controllers
{
    public class VideoController : Controller
    {
        private appergerEntities1 db = new appergerEntities1();
       
        // GET: Video
        public ActionResult Index()
        {
            var video = db.Video.Include(i => i.Categoria);
            return View(video.ToList());
        }

        // GET: video/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Video.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // GET: Video/Create
        public ActionResult Create()
        {

            ViewBag.nIdCategoria = new SelectList(db.Categoria, "nIdCategoria", "sDescripcion");
            return View();
        }

        // POST: Video/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nIdVideo,sVideo,nInicio,nFin,sDescripcion,nIdCategoria")] Video video)
        {
            
                if (ModelState.IsValid)
                {

                   
                    db.Video.Add(video);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            
            ViewBag.nIdCategoria = new SelectList(db.Categoria, "nIdCategoria", "sDescripcion", video.nIdCategoria);
            return View(video);
        }

        // GET: Video/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Video.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            ViewBag.nIdCategoria = new SelectList(db.Categoria, "nIdCategoria", "sDescripcion", video.nIdCategoria);
            return View(video);
        }

        // POST: Video/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nIdVideo,sVideo,nInicio,nFin,sDescripcion,nIdCategoria")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nIdCategoria = new SelectList(db.Categoria, "nIdCategoria", "sDescripcion", video.nIdCategoria);
            return View(video);
        }

        // GET: Video/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Video.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: Video/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Video video = db.Video.Find(id);
            db.Video.Remove(video);
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
//Aca muestra como tiene que tomar la url para que el video tenga un inicio y fin
//https://www.misingresospasivos.com/embeber-video-youtube-empiece-acabe-momento-concreto/
//<iframe width="700" height="394" src="https://www.youtube.com/embed/TYgL-cVEEA0?start=235&end=240&version=3" frameborder="0" allowfullscreen></iframe>