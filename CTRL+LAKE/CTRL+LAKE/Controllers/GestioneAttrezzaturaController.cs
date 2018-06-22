using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CTRL_LAKE.Controllers
{
    public class GestioneAttrezzaturaController : Controller
    {
        private Dictionary<string, int[]> map = new Dictionary<string, int[]>();
        private bool initialized = false;
        
        public void init() {
            map.Add("barcaVela", new int[] { 5, 1 });
            map.Add("canoa", new int[] { 12, 3 });
            map.Add("windsurf", new int[] { 15, 2 });
            map.Add("sup", new int[] { 12, 6 });
        }

        public ActionResult GestioneAttrezzatura()
        {
            if (!initialized)
                init();
            ViewData["MapAttrezzature"] = map;
            return View();
        }
    }
}