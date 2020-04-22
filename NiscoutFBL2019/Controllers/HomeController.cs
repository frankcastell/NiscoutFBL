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
            // FUNCION PARA TEXTO ALEATORIOS
            List<string> quotes = new List<string>();
            quotes.Add("La religión es una cosa bien sencilla, primero: amar y servir a Dios, segundo: amar y servir al prójimo.");
            quotes.Add("Si buscas resultados distintos, no hagas siempre lo mismo.");
            quotes.Add("Una sonrisa es la llave secreta que abre muchos corazones.");
            quotes.Add("Un scout debe hacer una buena acción a los demás por cortesía y buena voluntad sin aceptar recompensa.");
            quotes.Add("En los momentos de crisis, sólo la imaginación es más importante que el conocimiento.");

            Random rnd = new Random();
            ViewBag.rando = quotes[rnd.Next(quotes.Count)];

            //FIN             
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