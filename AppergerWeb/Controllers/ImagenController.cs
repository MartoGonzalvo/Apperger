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
    public class ImagenController : Controller
    {
        private appergerEntities1 db = new appergerEntities1();

        // GET: Imagen
        public ActionResult Index()
        {
            var imagen = db.Imagen.Include(i => i.Categoria);
            return View(imagen.ToList());
        }

        // GET: Imagen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagen imagen = db.Imagen.Find(id);
            if (imagen == null)
            {
                return HttpNotFound();
            }
            return View(imagen);
        }

        // GET: Imagen/Create
        public ActionResult Create()
        {
           
            ViewBag.nIdCategoria = new SelectList(db.Categoria, "nIdCategoria", "sDescripcion");
            return View();
        }

        // POST: Imagen/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nIdImagen,sImagen,sDescripcion,nIdCategoria")] Imagen imagen)
        {
            var file = Request.Files[0];
            if (file != null && file.ContentLength > 0)
            {
                CloudStorageAccount StorageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["appergerstorage_AzureStorageConnectionString"].ConnectionString);
                CloudBlobClient blobclient = StorageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobclient.GetContainerReference("apperger");
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(file.FileName);
                blockBlob.Properties.ContentType = "image/jpeg";
                var url1 = blockBlob.Uri.AbsoluteUri;
                blockBlob.UploadFromStream(file.InputStream);
           

            if (ModelState.IsValid)
            {

                    imagen.sImagen = url1;
                db.Imagen.Add(imagen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            ViewBag.nIdCategoria = new SelectList(db.Categoria, "nIdCategoria", "sDescripcion", imagen.nIdCategoria);
            return View(imagen);
        }

        // GET: Imagen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagen imagen = db.Imagen.Find(id);
            if (imagen == null)
            {
                return HttpNotFound();
            }
            ViewBag.nIdCategoria = new SelectList(db.Categoria, "nIdCategoria", "sDescripcion", imagen.nIdCategoria);
            return View(imagen);
        }

        // POST: Imagen/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nIdImagen,sImagen,sDescripcion,nIdCategoria")] Imagen imagen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nIdCategoria = new SelectList(db.Categoria, "nIdCategoria", "sDescripcion", imagen.nIdCategoria);
            return View(imagen);
        }

        // GET: Imagen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagen imagen = db.Imagen.Find(id);
            if (imagen == null)
            {
                return HttpNotFound();
            }
            return View(imagen);
        }

        // POST: Imagen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Imagen imagen = db.Imagen.Find(id);
            db.Imagen.Remove(imagen);
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
