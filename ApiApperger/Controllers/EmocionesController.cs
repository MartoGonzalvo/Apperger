using ApiApperger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiApperger.Controllers
{
    public class EmocionesController : ApiController
    {
        appergerEntities1 DB = new appergerEntities1();

        [HttpGet]
        [ActionName("XAMARIN_REG")]
        
        public HttpResponseMessage Xamarin_reg(int idEmocionElegida, int idEmocion, int idTratamiento)
        {

            //usuario usu = new usuario();
            Selfie self = new Selfie();
            //self.nIdEmocionRealizada = idEmocion;

            if (idEmocion < 0)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Please Enter valid UserName and Password");
            }
            else
            {
                try
                {

                    self.nIdTratamiento = idTratamiento;
                    self.nIdEmocionElegida = idEmocionElegida;
                    self.nIdEmocionRealizada = idEmocion;

                    DB.Selfies.Add(self);
                    DB.SaveChanges();
                    //return Request.CreateResponse(HttpStatusCode.Accepted, "Guardada correctamente");
                    return Request.CreateResponse(HttpStatusCode.Accepted, "Success");
                }
                catch(Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Error");
                }
                
            }
            /*DB.Selfie.Add(self);
            DB.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Accepted, "Guardada correctamente");*/
        }
    }
}
