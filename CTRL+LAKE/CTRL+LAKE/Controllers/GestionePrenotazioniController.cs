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
        private static int id = 100;
        private List<Attrezzatura> elencoAttrezzatura;
        private List<Cliente> elencoClienti;
        private List<Noleggio> elencoNoleggi;
        private List<Lezione> elencoLezioni;
        private List<Istruttore> elencoIstruttori;

        public List<Attrezzatura> ElencoAttrezzatura { get => elencoAttrezzatura; set => elencoAttrezzatura = value; }
        public List<Noleggio> ElencoNoleggi { get => elencoNoleggi; set => elencoNoleggi = value; }
        public List<Cliente> ElencoClienti { get => elencoClienti; set => elencoClienti = value; }
        public List<Lezione> ElencoLezioni { get => elencoLezioni; set => elencoLezioni = value; }
        public List<Istruttore> ElencoIstruttori { get => elencoIstruttori; set => elencoIstruttori = value; }

        public GestionePrenotazioniController()
        {
            ElencoClienti = GetListaClienti();
            ElencoIstruttori = GetListaIstruttori();
            ElencoAttrezzatura = GetListaAttrezzature();
            ElencoLezioni = GetListaLezioni();
            ElencoNoleggi = GetListaNoleggi();
        }

        public int NewId() { return id; }

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
        public ActionResult Index()
        {
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