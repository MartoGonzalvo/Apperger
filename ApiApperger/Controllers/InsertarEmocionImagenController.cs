using ApiApperger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiApperger.Controllers
{
    public class InsertarEmocionImagenController : ApiController
    {
        appergerEntities1 DB = new appergerEntities1();

        [HttpGet]
        [ActionName("XAMARIN_Login")]
        // GET: api/Login/5  
        public HttpResponseMessage Xamarin_login(int idEmocion, int idImagen)
        {
            

            var query = DB.ImagenTratamientoes.Where(x => x.nIdImagen == idImagen).FirstOrDefault();
            if (query != null)
            {
                query.nIdEmocionElegida = idEmocion;
                DB.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Datos actualizados");
            }
            else
            {

                return Request.CreateResponse(HttpStatusCode.Accepted, "Error al actualizar");
            }
        }


    }
}
