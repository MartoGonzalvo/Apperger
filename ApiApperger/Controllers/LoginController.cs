using ApiApperger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiApperger.Controllers
{
    public class LoginController : ApiController
    {
        appergerEntities1 DB = new appergerEntities1();

        [HttpGet]
        [ActionName("XAMARIN_Login")]
        // GET: api/Login/5  
        public HttpResponseMessage Xamarin_login(string username, int password)
        {
            var user = DB.usuarios.Where(x => x.sUsuario == username && x.sMatricula == password).FirstOrDefault();
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Please Enter valid UserName and Password");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, "Success");
            }
        }
    }
}
