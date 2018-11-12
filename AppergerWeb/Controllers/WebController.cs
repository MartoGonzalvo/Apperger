using AppergerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace AppergerWeb.Controllers
{
    public class WebController : Controller
    {
        appergerEntities1 DB = new AppergerWeb.Models.appergerEntities1(); //conexion a la db de la api

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
            var listado = DB.usuario.ToList();

            return View(listado);
          
        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CrearEditarUsuario() //despues que reciba id de psicologue para listar sus pacientes
        {
        

            return View();

        }

        
        public ActionResult CrearEditarUsuario1(usuario modelo)
        {           
            try
            {
                DB.usuario.Add(modelo);
                DB.SaveChanges();
                var listado = DB.usuario.ToList();



                return View("Pacientes", listado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ;
           
        }
                    }
}