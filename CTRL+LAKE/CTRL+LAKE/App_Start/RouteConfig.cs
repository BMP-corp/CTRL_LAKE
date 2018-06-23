using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CTRL_LAKE.Models;
using NHibernate.Criterion;
using CTRL_LAKE.Controllers;

namespace CTRL_LAKE
{
    public class RouteConfig
    {

        private static GestionePrenotazioniController gpc = new GestionePrenotazioniController();
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            System.Diagnostics.Debug.WriteLine("SCRIVO QUI");
            //insert();
            //Cliente c = readCliente("mic.cam.1");
            //if (c != null)
            //    System.Diagnostics.Debug.WriteLine("[ " + c.Username + ", " + c.Nome + ", " + c.Cognome + " ]");
            //System.Diagnostics.Debug.WriteLine("");

            

            //bool result = aggiornaAttrezzatura("barcaVela", 1);
            //if (result)
            //{
            //    System.Diagnostics.Debug.WriteLine("attrezzatura aggiornata correttamente!");
            //}

            System.Diagnostics.Debug.WriteLine("SCRIVO QUI 2");
            //List<Attrezzatura> elencoAttrezzature = GetListaAttrezzature();
            //DeleteAttrezzatura(101);
            //List<DettaglioNoleggio> elencoDettagli = GetListaNoleggi();
            //List<Cliente> elencoClienti = GetListaClienti();
            //InsertCliente();

            //System.Diagnostics.Debug.WriteLine(elencoDettagli[0].Inizio.ToString());
            //Credenziali cred1 = new Credenziali("dario.bolo.1", "dariobolo1", "istruttore");
            //Credenziali cred2 = new Credenziali("giulia.bolo.1", "giuliabolo1", "cliente");

            //InsertCredenziali(cred1);
            //InsertCredenziali(cred2);
            //DeleteDettaglioNoleggio(201, 1);
            //string pass1 = GetPasswordByUsername(cred1.Username);
            //string pass2 = GetPasswordByUsername(cred2.Username);
            //List<Cliente> elencoClienti = GetListaClienti();
            List<Noleggio> listaNoleggio = GetListaNoleggi();

            
            System.Diagnostics.Debug.WriteLine("SCRIVO QUI 2");


        }

        public static ISession OpenConnection()
        {
            Configuration myCfg = new Configuration();
            myCfg.Configure();
            ISessionFactory factory = myCfg.BuildSessionFactory();
            ISession sess = factory.OpenSession();
            return sess;
        }
        //ok
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

        public static void InsertAttrezzatura(Attrezzatura attrezzatura)
        {
            ISession session = OpenConnection();
            using (session.BeginTransaction())
            {
                try
                {
                    session.Save(attrezzatura);
                    session.Transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
            }

        }

        public static void DeleteAttrezzatura(int id)
        {
            ISession session = OpenConnection();
            using (session.BeginTransaction())
            {

                try
                {
                    Attrezzatura attrezzatura = (Attrezzatura)session.CreateCriteria<Attrezzatura>()
                        .Add(Restrictions.Eq("IdAttrezzatura", id)).UniqueResult();
                    session.Delete(attrezzatura);
                    session.Transaction.Commit();

                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
            }

        }

        public static bool AggiornaAttrezzatura(string attrezzatura, int quantita) //Attrezzatura o string tipo?
        {                                                                    //per ora metto tipo
            bool result = false;
            if (quantita > 0)
            {
                while (quantita > 0)
                {
                    Attrezzatura a = new Attrezzatura(attrezzatura, 103, AttrPosti(attrezzatura));
                    InsertAttrezzatura(a);// METODO PERSISTENZA
                    //gpc.ElencoAttrezzatura.Add(a);
                    quantita--;
                }
            }
            //else
            //{
            //    foreach (Attrezzatura a in gpc.ElencoAttrezzatura)
            //    {
            //        while (quantita < 0)
            //        {
            //            if (a.Tipo == attrezzatura && a.isCancellabile())
            //            {
            //                //DeleteAttrezzatura(a.IdAttrezzatura); // METODO PERSISTENZA
            //                //gpc.ElencoAttrezzatura.Remove(a);
            //                break;
            //            }
            //            quantita++;
            //        }
            //    }
            //}
            result = (quantita == 0);
            return result;
        }

        private static int AttrPosti(string tipoAttr)
        {
            int result = 1;
            switch (tipoAttr)
            {
                case ("barcaVela"): result = 5; break;
                case ("canoa"): result = 2; break;
                default: result = 1; break;
            }
            return result;
        }

        //ok
        public static void InsertCredenziali(Credenziali credenziali)
        {
            ISession session = OpenConnection();
            using (session.BeginTransaction())
            {
                try
                {
                    session.Save(credenziali);
                    session.Transaction.Commit();
                }
                catch(Exception e)
                {
                    Console.Write(e.Message);
                }
            }
        }
        //ok
        public static string GetPasswordByUsername(string username)
        {
            string password = null;
            Credenziali temp = null;
            ISession sess = OpenConnection();

            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Credenziali>();
                try
                {
                    temp = criteria.Add(Expression.Like("Username", username)).List<Credenziali>()[0];
                    password = temp.Password;
                }
                catch(Exception e)
                {
                    Console.Write(e.Message);
                }

            }
            return password;
        }

        public static void InsertDettaglioNoleggio(DettaglioNoleggio dt)
        {
            try
            {

                ISession sess = OpenConnection();
                using (sess.BeginTransaction())
                {
                    sess.Persist(dt);
                    sess.Transaction.Commit();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        
        public static void DeleteDettaglioNoleggio(int idAttrezzatura, int id)
        {
            ISession session = OpenConnection();
            using (session.BeginTransaction())
            {

                try
                {
                    DettaglioNoleggio dettaglioNoleggio = (DettaglioNoleggio)session.CreateCriteria<DettaglioNoleggio>()
                        .Add(Restrictions.Eq("IdAttrezzatura", idAttrezzatura)).Add(Restrictions.Eq("Id", id)).UniqueResult();
                    session.Delete(dettaglioNoleggio);
                    session.Transaction.Commit();

                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
            }

        }

        public static List<DettaglioNoleggio> GetListaDettagliNoleggio()
        {
            List<DettaglioNoleggio> res = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<DettaglioNoleggio>();
                try
                {
                    res = (List<DettaglioNoleggio>)criteria.List<DettaglioNoleggio>();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }

        

        public static void InsertCliente(Cliente c)
        {
            try
            {
               
                ISession sess = OpenConnection();
                using (sess.BeginTransaction())
                {
                    //Cliente c = new Cliente("Mic", "Camp", "mic.cam.1", new DateTime(1996, 8, 11), "carnazza@bk.it", "3334445556");
                    sess.Persist(c);
                    sess.Transaction.Commit();
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void InsertIstruttore(Istruttore i)
        {
            try
            {

                ISession sess = OpenConnection();
                using (sess.BeginTransaction())
                {
                   
                    //Istruttore i = new Istruttore("Francesco", "Mazzucchelli", "francesco.mazzu.1", new DateTime(1996, 5, 4), "francesco.mazzu@gmail.com", "3344456789", "QWERT45", "vela", "pomeriggio");
                    sess.Persist(i);
                    sess.Transaction.Commit();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static Cliente GetClienteById(String username)
        {
            Cliente res = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Cliente>();
                criteria.Add(Expression.Like("Username", username));
                try
                {
                    res = criteria.List<Cliente>()[0];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }

        public static Istruttore GetIstruttoreById(String username)
        {
            Istruttore res = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Istruttore>();
                criteria.Add(Expression.Like("Username", username));
                try
                {
                    res = criteria.List<Istruttore>()[0];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }

        public static List<Cliente> GetListaClienti()
        {
            List<Cliente> res = new List<Cliente>();
            Cliente cliente = null;
            List<Credenziali> temp = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteriaClienti = sess.CreateCriteria<Cliente>();
                ICriteria criteriaCredenziali = sess.CreateCriteria<Credenziali>();


                try
                {
                    //leggo dal database tutti gli username dei clienti 
                    temp = (List<Credenziali>)criteriaCredenziali.Add(Expression.Like("Ruolo", "cliente")).List<Credenziali>();

                    foreach(Credenziali cred in temp)
                    {
                        //per ogni username cerco il cliente corrispondente nella tabella utenti
                        cliente = criteriaClienti.Add(Expression.Like("Username", cred.Username)).List<Cliente>()[0];
                        //aggiungo il cliente alla lista clienti
                        res.Add(cliente);
                    }
                    
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }

        public static List<Istruttore> GetListaIstruttori()
        {
            List<Istruttore> res = new List<Istruttore>();
            Istruttore Istruttore = null;
            List<Credenziali> temp = null;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteriaClienti = sess.CreateCriteria<Istruttore>();
                ICriteria criteriaCredenziali = sess.CreateCriteria<Credenziali>();


                try
                {
                    //leggo dal database tutti gli username dei clienti 
                    temp = (List<Credenziali>)criteriaCredenziali.Add(Expression.Like("Ruolo", "istruttore")).List<Credenziali>();

                    foreach (Credenziali cred in temp)
                    {
                        //per ogni username cerco il Istruttore corrispondente nella tabella utenti
                        Istruttore = criteriaClienti.Add(Expression.Like("Username", cred.Username)).List<Istruttore>()[0];
                        //aggiungo il Istruttore alla lista clienti
                        res.Add(Istruttore);
                    }

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
            List<Noleggio> res = new List<Noleggio>();
            List<DettaglioNoleggio> temp;
            bool aggiunto = false;
            ISession sess = OpenConnection();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<DettaglioNoleggio>();
                try
                {
                    temp = GetListaDettagliNoleggio();
                    foreach (DettaglioNoleggio dt in temp)
                    {
                        
                        foreach (Noleggio n in res)
                        {
                            if(n.Id == dt.Id)
                            {
                                n.ElencoDettagli.Add(dt);
                                aggiunto = true;
                            }

                        }
                        if (!aggiunto)
                        {
                            //Cliente c = GetClienteById(dt.Username);
                            //Noleggio n = new Noleggio(dt.Id, c, dt.Inizio, dt.Fine);
                            //n.ElencoDettagli.Add(dt);
                            //res.Add(n);
                            foreach (Cliente c in gpc.ElencoClienti)
                            {
                                if (c.Username.Equals(dt.Username))
                                {
                                    Noleggio n = new Noleggio(dt.Id, c, dt.Inizio, dt.Fine);
                                    n.ElencoDettagli.Add(dt);
                                    res.Add(n);

                                }
                            }

                        }
                        aggiunto = false;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }

        public static void InsertNoleggio(Noleggio n)
        {
            try
            {
                    foreach(DettaglioNoleggio dn in n.ElencoDettagli)
                    {
                    InsertDettaglioNoleggio(dn);
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void DeleteNoleggio(Noleggio n)
        {
          
                foreach(DettaglioNoleggio dn in n.ElencoDettagli)
                {
                    try
                    {
                        DeleteDettaglioNoleggio(dn.IdAttrezzatura, dn.Id);

                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message);
                    }
                }
                
         }

        }




    }
}
