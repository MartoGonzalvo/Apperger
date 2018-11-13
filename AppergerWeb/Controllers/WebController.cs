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
        public ActionResult Login1(string usuario, string password)
        {
            var user = DB.usuario.Where(x => x.sUsuario == usuario && x.sContraseña == password).FirstOrDefault();
            if (user == null)
            {
                return View("Login");
            }
            else
            {
                ViewBag.id = user.nIdUsuario;
                System.Web.HttpContext.Current.Session["sessionLogin"] = ViewBag.id;
                return View("../Home/Index");

            }

        }
        public ActionResult Logout()
        {
            System.Web.HttpContext.Current.Session["sessionLogin"] = null;
            return View("Login");


        }

        public ActionResult CrearPsicologo(usuario modelo)
        {
            return View();

        }

        public ActionResult CrearPsicologo1(usuario modelo)
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
            return View("../Home/Index");
        }

        public ActionResult CrearEditarUsuario(int? nUsuarioId) //despues que reciba id de psicologue para listar sus pacientes
        {
            if (nUsuarioId.Equals(null))
            {
                return View();

            }
            else
            {

                var usuario = DB.usuario.Single(x => x.nIdUsuario == nUsuarioId);

                return View(usuario);
            }



        }


        public ActionResult CrearEditarUsuario1(usuario modelo)
        {
            if (modelo.nIdUsuario.Equals(null))
            {
                try
                {
                    DB.usuario.Add(modelo);
                    // modelo.nPacienteDe=user
                    DB.SaveChanges();
                    var listado = DB.usuario.ToList();



                    return RedirectToAction("Pacientes", listado);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
               

                var usuario = DB.usuario.Single(x => x.nIdUsuario == modelo.nIdUsuario);
                DB.Entry(usuario).CurrentValues.SetValues(modelo);
            //    DB.usuario.Add(modelo);
                DB.SaveChanges();
                var listado = DB.usuario.ToList();
                return RedirectToAction("Pacientes", listado);





            }




        }
    }
}
           
           
        //}
        //            }
