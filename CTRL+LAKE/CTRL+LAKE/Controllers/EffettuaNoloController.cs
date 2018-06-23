using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CTRL_LAKE.Controllers
{
    public class EffettuaNoloController : Controller
    {
        private static GestionePrenotazioniController gpc;
        private static bool initialized=false;

        // GET: EffettuaNolo
        public ActionResult EffettuaNolo()
        {

            return View();
        }
    }
}