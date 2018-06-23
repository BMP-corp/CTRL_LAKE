using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CTRL_LAKE.Controllers.Interfaces;
using CTRL_LAKE.Models;
using NHibernate;
using NHibernate.Cfg;

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
        public HashSet<Cliente> ElencoClienti { get => elencoClienti; set => elencoClienti = value; }

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
            Attrezzatura a = new Attrezzatura("barcaVela", NewId(), 5);
            ElencoAttrezzatura.Add(a);
            ElencoAttrezzatura.Add(new Attrezzatura("barcaVela", NewId(), 5));
            ElencoAttrezzatura.Add(new Attrezzatura("canoa", NewId(), 2));
            Cliente c = new Cliente("Michele", "Campa", "michele.campa.19", new DateTime(1996, 8, 11), "mc@ampa.it", "123456789");
            ElencoClienti.Add(c);
            Noleggio nol = new Noleggio(NewId(), c, new DateTime(2018, 6, 28, 10, 0, 0), new DateTime(2018, 6, 28, 11, 0, 0));
            nol.AddDettaglio(new DettaglioNoleggio(nol.Id, 4, a, 45, new DateTime(2018, 6, 28, 10, 0, 0), new DateTime(2018, 6, 28, 11, 0, 0), "michele.campa.19"));
            elencoNoleggi.Add(nol);
            initialized = true;
        }

        public int NewId() { return curr_id++; }

        // generazione degli ID (incrementale)
       

        public static ISession OpenConnection()
        {
            Configuration myCfg = new Configuration();
            myCfg.Configure();
            ISessionFactory factory = myCfg.BuildSessionFactory();
            ISession sess = factory.OpenSession();
            return sess;
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
            foreach (Cliente c1 in ElencoClienti)
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
                    foreach (Noleggio nol in ElencoNoleggi)
                        if (nol.Id == daEliminare)
                        {
                            n = nol; break;
                        }
                    for (int i=n.ElencoDettagli.Count-1; i>=0; i--)
                    {
                        // METODO PERSISTENZA DELETE DETTAGLIO
                        n.ElencoDettagli[i].Elimina(n.Inizio, n.Fine);
                        n.RimuoviDettaglio(n.ElencoDettagli[i]);
                    }
                    ElencoNoleggi.Remove(n);
                    ViewData["Message"] = "Prenotazione rimossa!";
                } catch (Exception e) {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    ViewData["Message"] = "Non è stato possibile rimuovere la prenotazione";
                }
            }
                List<Noleggio> noleggi = new List<Noleggio>();
            foreach (Noleggio nol in ElencoNoleggi)
            {
                if (nol.Cliente.Equals(c))
                    noleggi.Add(nol);
            }
            ViewData["Cliente"] = c;
            ViewData["Noleggi"] = noleggi;
            return View();
        }


        public static List<Cliente> GetListaClienti()
        {
            List<Cliente> res = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Cliente>();
                try
                {
                    res = (List<Cliente>)criteria.List<Cliente>();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }

        public static List<Attrezzatura> GetListaAttrezzature()
        {
            List<Attrezzatura> res = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Attrezzatura>();
                try
                {
                    res = (List<Attrezzatura>)criteria.List<Attrezzatura>();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }

        public static List<Istruttore> GetListaIstruttori()
        {
            List<Istruttore> res = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Istruttore>();
                try
                {
                    res = (List<Istruttore>)criteria.List<Istruttore>();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }

        public static List<Noleggio> GetListaNoleggi()
        {
            List<Noleggio> res = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Noleggio>();
                try
                {
                    res = (List<Noleggio>)criteria.List<Noleggio>();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }

        public static List<Lezione> GetListaLezioni()
        {
            List<Lezione> res = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Lezione>();
                try
                {
                    res = (List<Lezione>)criteria.List<Lezione>();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }



        public Noleggio NoloById(int id)
        {
            foreach (Noleggio n in elencoNoleggi)
            {
                if (n.Id == id)
                    return n;
            }
            return null;
        }
    }
}