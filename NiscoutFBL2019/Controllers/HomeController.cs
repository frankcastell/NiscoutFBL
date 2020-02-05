using NiscoutFBL2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NiscoutFBL2019.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();
        public static int Contador = 0;
        public static int ContadorJ = 0;
        public static int ContAJ = 0;

        public ActionResult Index()
        {
            ViewBag.Contador = db.Adultos.Count();
            ViewBag.ContadorJ = db.Juveniles.Count();

            ViewBag.ContAJ = db.Personas.Count();
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
        public ActionResult NotFound()
        {
            
            return View();
        }
        public ActionResult Catalogos()
        {

            return View();
        }
    }
}