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
    public class TratamientoController : Controller
    {
        private appergerEntities2 db = new appergerEntities2();

        // GET: Tratamiento
        public ActionResult Index()
        {
            int idPsicologo= Convert.ToInt16(Session["usuario"]);
            var tratamiento = db.Tratamiento.Include(t => t.usuario).Include(t => t.usuario1).Where(t=> t.nIdPsicologo==idPsicologo);
            return View(tratamiento.ToList());
        }

        // GET: Tratamiento/Details/5
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

        // GET: Tratamiento/Create
        public ActionResult Create()
        {
            int idPsicologo = Convert.ToInt16(Session["usuario"]);


            ViewBag.nIdCategoria = new SelectList(db.Categoria.ToList(), "nIdCategoria", "sDescripcion");

            ViewBag.nIdPaciente = new SelectList(db.usuario.Where(t => t.nPacienteDe == idPsicologo), "nIdUsuario", "sNombre");
            ViewBag.bSelfie = new List<SelectListItem>
                  {
                     new SelectListItem{ Text="Activo", Value = "True" },
                     new SelectListItem{ Text="No activo", Value = "False" }
                  };
            ViewBag.bImagen = new List<SelectListItem>
                  {
                     new SelectListItem{ Text="Activo", Value = "True" },
                     new SelectListItem{ Text="No activo", Value = "False" }
                  };
            ViewBag.bVideo = new List<SelectListItem>
                  {
                     new SelectListItem{ Text="Activo", Value = "True" },
                     new SelectListItem{ Text="No activo", Value = "False" }
                  };
            return View();
        }

        // POST: Tratamiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nIdTratamiento,dFechaInicio,dFechaFin,bSelfie,bImagen,bVideo,nIdPsicologo,nIdPaciente")] Tratamiento tratamiento)
        {
            if (ModelState.IsValid)
            {
                tratamiento.nIdPsicologo = Convert.ToInt16(Session["usuario"]);
                db.Tratamiento.Add(tratamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.nIdPaciente = new SelectList(db.usuario, "nIdUsuario", "sUsuario", tratamiento.nIdPaciente);
            ViewBag.nIdPsicologo = new SelectList(db.usuario, "nIdUsuario", "sUsuario", tratamiento.nIdPsicologo);
            ViewBag.bSelfie = new List<SelectListItem>
                  {
                     new SelectListItem{ Text="Activo", Value = "True" },
                     new SelectListItem{ Text="No activo", Value = "False" }
                  };
            ViewBag.bImagen = new List<SelectListItem>
                  {
                     new SelectListItem{ Text="Activo", Value = "True" },
                     new SelectListItem{ Text="No activo", Value = "False" }
                  };
            ViewBag.bVideo = new List<SelectListItem>
                  {
                     new SelectListItem{ Text="Activo", Value = "True" },
                     new SelectListItem{ Text="No activo", Value = "False" }
                  };
            return View(tratamiento);
        }

        // GET: Tratamiento/Edit/5
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

        // POST: Tratamiento/Edit/5
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

        // GET: Tratamiento/Delete/5
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

        // POST: Tratamiento/Delete/5
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
    
    public ActionResult Estadisticas(int? TratamientoId)
    {

        Tratamiento tratamiento = db.Tratamiento.Include(x => x.ImagenTratamiento).
            Include(x => x.ImagenTratamiento.Select(y => y.Imagen)).
            Include(x => x.VideoTratamiento.Select(y => y.Video)).
             Include(x => x.Selfie.Select(y=> y.Emocion)).
             Include(x => x.Selfie.Select(y => y.Emocion1)).
            Single(z => z.nIdTratamiento == TratamientoId);
        if (tratamiento == null)
        {
            return HttpNotFound();
        }
        int error = 0;
        int acierto = 0;
        foreach (var item in tratamiento.ImagenTratamiento)
        {
            int emocionPosta = Convert.ToInt16(item.Imagen.nIdEmocion);
            int emocionElegida = Convert.ToInt16(item.nIdEmocionElegida);
            if (emocionPosta == emocionElegida)
            { acierto++; }
            else { error++; }
        }
        ViewBag.acierto = acierto;
        ViewBag.error = error;

        int errorVideo = 0;
        int aciertoVideo = 0;
        foreach (var item in tratamiento.VideoTratamiento)
        {
            int emocionPosta = Convert.ToInt16(item.Video.nIdEmocion);
            int emocionElegida = Convert.ToInt16(item.nIdEmocionElegida);
            if (emocionPosta == emocionElegida)
            { aciertoVideo++; }
            else { errorVideo++; }
        }
        ViewBag.aciertoVideo = aciertoVideo;
        ViewBag.errorVideo = errorVideo;

            int errorSelfie= 0;
            int aciertoSelfie = 0;
            foreach (var item in tratamiento.Selfie)
            {
                int emocionPosta = Convert.ToInt16(item.nIdEmocionElegida);
                int emocionElegida = Convert.ToInt16(item.nIdEmocionRealizada);
                if (emocionPosta == emocionElegida)
                { aciertoSelfie++; }
                else { errorSelfie++; }
            }
            ViewBag.aciertoSelfie = aciertoSelfie;
            ViewBag.errorSelfie = errorSelfie;

            ViewBag.usuario = tratamiento.usuario.sNombre + ' ' + tratamiento.usuario.sApellido;
        return View(tratamiento);
    }
}
}
