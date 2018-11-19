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
    public class CategoriaController : Controller
    {
        private appergerEntities1 db = new appergerEntities1();

         
        // GET: Video/Create
        public ActionResult Create()
        {
           return View();
        }

        // POST: Video/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nIdCategoria,sDescripcion")] Categoria categoria)
        {

            if (ModelState.IsValid)
            {


                db.Categoria.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("../home/Index");
            }

           
            return View(categoria);
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

