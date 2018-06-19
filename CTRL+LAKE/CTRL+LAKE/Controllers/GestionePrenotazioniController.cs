using System;
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
        private HashSet<Attrezzatura> elencoAttrezzatura;
        private HashSet<Cliente> elencoClienti;
        private HashSet<Istruttore> elencoIstruttori;
        private HashSet<Lezione> elencoLezioni;
        private HashSet<Noleggio> elencoNoleggi;

        private static int curr_id;

        DbConnection c;

        public HashSet<Lezione> ElencoLezioni { get => elencoLezioni; set => elencoLezioni = value; }
        public HashSet<Attrezzatura> ElencoAttrezzatura { get => elencoAttrezzatura; set => elencoAttrezzatura = value; }

        public GestionePrenotazioniController()
        {
            this.ElencoAttrezzatura = getDbAttrezzatura(c);
            this.elencoClienti = getDbClienti(c);
            this.elencoIstruttori = getDbIstruttori(c);
            //this.elencoLezioni = getDbLezioni();
            //this.elencoNoleggi = getDbNoleggi();
            curr_id = 100;
        }

        // generazione degli ID (incrementale)
        public int newId()
        {
            return curr_id++;
        }


        // GET: GestionePrenotazioni
        public ActionResult Index()
        {
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