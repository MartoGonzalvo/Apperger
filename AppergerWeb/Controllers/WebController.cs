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
        appergerEntities DB = new appergerEntities(); //conexion a la db de la api

        // GET: Web
        public ActionResult Index()
        {
            //logica 
            //var logicusuario = new 
            //usuario usuario = new usuario();
            //DB.usuario.Where(x => x.nPacienteDe).tolist();

            return View();
        }
        public ActionResult Pacientes()
        {
            return View();
        }

        

        
        public ActionResult CrearEditarUsuario(usuario modelo)
        {
            return View();

        }

        
        public ActionResult CrearEditarUsuario1(usuario modelo)
        {           
            try
            {
                DB.usuario.Add(modelo);
                DB.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            ;
            return View("Pacientes");
        }
                    }
}