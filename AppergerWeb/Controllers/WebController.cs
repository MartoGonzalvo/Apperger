using ApiApperger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppergerWeb.Controllers
{
    public class WebController : Controller
    {
        // GET: Web
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Pacientes()
        {
            return View();
        }

        appergerEntities DB = new appergerEntities();

        public ActionResult CrearEditarUsuario()
        {
            try
            {
                var usuario1 = new usuario
                {
                    sApellido = "Perez",
                    nRol = 1,
                    nEdad = 12,
                    sProvincia = "buenos aires",
                    sPais = "Argentina",
                    dFechaNacimiento = DateTime.Now,
                    nIdUsuario = 1,
                    nPacienteDe = 1,
                    sUsuario = "Sol perez"

                };

                DB.usuario.Add(usuario1);
                //  DB.Rol.Add(rol2);
                DB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ;
            return View();
        }


    }
}