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
        Apperger db = new appergerEntities();

    }
}