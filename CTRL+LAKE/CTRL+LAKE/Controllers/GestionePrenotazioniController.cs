﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CTRL_LAKE.Controllers.Interfaces;
using CTRL_LAKE.Models;

namespace CTRL_LAKE.Controllers
{
    public class GestionePrenotazioniController : Controller, IGestionePrenotazioniController
    {
        private static HashSet<Attrezzatura> elencoAttrezzatura = new HashSet<Attrezzatura>();
        private static HashSet<Cliente> elencoClienti = new HashSet<Cliente>();
        private static HashSet<Istruttore> elencoIstruttori = new HashSet<Istruttore>();
        private static HashSet<Lezione> elencoLezioni;
        private static HashSet<Noleggio> elencoNoleggi = new HashSet<Noleggio>();
        private static bool initialized = false;

        private static int curr_id;
        

        public HashSet<Lezione> ElencoLezioni { get => elencoLezioni; set => elencoLezioni = value; }
        public HashSet<Attrezzatura> ElencoAttrezzatura { get => elencoAttrezzatura; set => elencoAttrezzatura = value; }

        /*public GestionePrenotazioniController()
        {
            this.ElencoAttrezzatura = getDbAttrezzatura(c);
            this.elencoClienti = getDbClienti(c);
            this.elencoIstruttori = getDbIstruttori(c);
            //this.elencoLezioni = getDbLezioni();
            //this.elencoNoleggi = getDbNoleggi();
            curr_id = 100;
        }*/

        private void init()
        {
            Attrezzatura a = new Attrezzatura("barcaVela", newId(), 5);
            ElencoAttrezzatura.Add(a);
            ElencoAttrezzatura.Add(new Attrezzatura("barcaVela", newId(), 5));
            ElencoAttrezzatura.Add(new Attrezzatura("canoa", newId(), 2));
            Cliente c = new Cliente("Michele", "Campa", "michele.campa.19", new DateTime(1996, 8, 11), "mc@ampa.it", "123456789");
            elencoClienti.Add(c);
            Noleggio nol = new Noleggio(newId(), c, new DateTime(2018, 6, 28, 10, 0, 0), new DateTime(2018, 6, 28, 11, 0, 0));
            nol.AddDettaglio(new DettaglioNoleggio(nol.Id, 4, a, 45, new DateTime(2018, 6, 28, 10, 0, 0), new DateTime(2018, 6, 28, 11, 0, 0)));
            elencoNoleggi.Add(nol);
            initialized = true;
        }

        // generazione degli ID (incrementale)
        public int newId()
        {
            return curr_id++;
        }


        // GET: GestionePrenotazioni
        public ActionResult HomeCliente()
        {
            if (!initialized)
            {
                init();
            }
            var username = Request.QueryString["username"];
            Cliente c = null;
            foreach (Cliente c1 in elencoClienti)
            {
                if (c1.Username.Equals(username))
                {
                    c = c1; break;
                }
            }
            if (c == null)
                return Redirect("/Home/Index");
            ViewData["Message"] = "";
            if (Request.RequestType.Equals("POST"))
            {
                try
                {
                    int daEliminare = Int32.Parse(Request.Form["todelete"]);
                    Noleggio n = null;
                    foreach (Noleggio nol in elencoNoleggi)
                        if (nol.Id == daEliminare)
                        {
                            n = nol; break;
                        }
                    for (int i=n.DettaglioNoleggio.Count-1; i>=0; i--)
                    {
                        // METODO PERSISTENZA DELETE DETTAGLIO
                        n.DettaglioNoleggio[i].Elimina(n.Inizio, n.Fine);
                        n.RimuoviDettaglio(n.DettaglioNoleggio[i]);
                    }
                    elencoNoleggi.Remove(n);
                    ViewData["Message"] = "Prenotazione rimossa!";
                } catch (Exception e) {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    ViewData["Message"] = "Non è stato possibile rimuovere la prenotazione";
                }
            }
                List<Noleggio> noleggi = new List<Noleggio>();
            foreach (Noleggio nol in elencoNoleggi)
            {
                if (nol.Cliente.Equals(c))
                    noleggi.Add(nol);
            }
            ViewData["Cliente"] = c;
            ViewData["Noleggi"] = noleggi;
            return View();
        }


        public HashSet<Attrezzatura> getDbAttrezzatura(DbConnection conn)
        {
            throw new NotImplementedException();
        }

        public HashSet<Cliente> getDbClienti(DbConnection conn)
        {
            throw new NotImplementedException();
        }

        public HashSet<Istruttore> getDbIstruttori(DbConnection conn)
        {
            throw new NotImplementedException();
        }
    }
}