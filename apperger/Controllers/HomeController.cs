using CodeFirst.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace apperger.Controllers
{
    
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            //        using (var dc = new appergerDb())
            //        {
            //            //var Persona = new Persona
            //            //{
            //            //    Id = 1,
            //            //    Nombre = "Masi Trolo"
            //            //};
            //            //dc.personas.Add(Persona);
            //            //dc.SaveChanges();

            //   }
            using (var dc = new appergerDb())
            {
                var imagen = new Imagen
                {
                    Id = 1,
                    Descripcion = "Masi Trolo",
                    Nombre ="pachichi"
                };
               dc.imagenes.Add(imagen);
                      dc.SaveChanges();

            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}