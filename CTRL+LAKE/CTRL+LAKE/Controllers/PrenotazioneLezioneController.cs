using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CTRL_LAKE.Controllers.Interfaces;
using CTRL_LAKE.Models;

namespace CTRL_LAKE.Controllers
{
    public class PrenotazioneLezioneController : Controller, IPrenotazioneLezioneController
    {
        private GestionePrenotazioniController ctrl;

        public PrenotazioneLezioneController(GestionePrenotazioniController ctrl)
        {
            this.ctrl = ctrl;
        }



        // GET: PrenotazioneLezione
        public ActionResult Index()
        {
            return View();
        }




        public Lezione creaLezione(DateTime inizio, DateTime fine, Cliente c, Istruttore i, int partecipanti, int id)
        {

            Lezione lezione = null;
            try
            {
                lezione = new Lezione(101, i, inizio, fine, partecipanti, c);
                /*operazione di retrieve del costo della lezione*/ double costo = 30;
                lezione.Costo = costo;
                ctrl.ElencoLezioni.Add(lezione); //qui o in GestionePrenotazioniController?
            } catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return lezione;
        }

        public void eliminaLezione(int id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, List<Attrezzatura>> mostraDisponibilitaAttrezzatura(DateTime giorno, string tipo)
        {
            DateTime dt, dt2;
            List<Attrezzatura> attr;
            Dictionary<int, List<Attrezzatura>> res = new Dictionary<int, List<Attrezzatura>>();
            for (int ora = 9; ora <= 18; ora++)
            {
                dt = new DateTime(giorno.Year, giorno.Month, giorno.Day, ora, 0, 0);
                dt2 = new DateTime(giorno.Year, giorno.Month, giorno.Day, ora+1, 0, 0);
                attr = new List<Attrezzatura>();
                foreach (Attrezzatura a in ctrl.ElencoAttrezzatura)
                    if (a.IsLibero(dt, dt2))
                        attr.Add(a);
                res.Add(ora-8, attr);
                        
            }
            return res;
        }

        public Dictionary<int, Istruttore[]> mostraDisponibilitaIstruttori(DateTime giorno, string tipo)
        {
            throw new NotImplementedException();
        }
    }
}