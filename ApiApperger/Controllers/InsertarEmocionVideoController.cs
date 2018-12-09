using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiApperger.Models;

namespace ApiApperger.Controllers
{
    public class InsertarEmocionVideoController : ApiController
    {
        appergerEntities1 DB = new appergerEntities1();

        [HttpGet]
        [ActionName("XAMARIN_InsertarEmocionVideo")]
        // GET: api/Login/5  
        public HttpResponseMessage Xamarin_InsertarEmocionVideo(int idEmocion, int idVideo)
        {


            var query = DB.VideoTratamientoes.Where(x => x.nIdVideo == idVideo).FirstOrDefault();

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
