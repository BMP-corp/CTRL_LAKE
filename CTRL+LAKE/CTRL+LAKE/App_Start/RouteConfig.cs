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

namespace CTRL_LAKE
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            System.Diagnostics.Debug.WriteLine("SCRIVO QUI");
            insert();
            Cliente c = readCliente("mic.cam.1");
            if (c != null)
                System.Diagnostics.Debug.WriteLine("[ " + c.Username + ", " + c.Nome + ", " + c.Cognome + " ]");
            System.Diagnostics.Debug.WriteLine("");

        }



        public static void insert()
        {
            try
            {
                var myCfg = new Configuration();
                var cfgPath = HttpContext.Current.Server.MapPath(@"~\Models\hibernate.cfg.xml");
                myCfg.Configure(cfgPath);
                var clienteCfgFile = HttpContext.Current.Server.MapPath(@"~\Mappings\Cliente.hbm.xml");
                //myCfg.AddFile(clienteCfgFile);
                ISessionFactory factory = myCfg.BuildSessionFactory();
                ISession sess = factory.OpenSession();
                using (sess.BeginTransaction())
                {
                    Cliente c = new Cliente("Mic", "Camp", "mic.cam.1", new DateTime(1996, 8, 11), "carnazza@bk.it", "3334445556");
                    sess.Persist(c);
                    sess.Transaction.Commit();
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static Cliente readCliente(String username)
        {
            Cliente res = null;
            Configuration myCfg = new Configuration();
            myCfg.Configure();
            ISessionFactory factory = myCfg.BuildSessionFactory();
            ISession sess = factory.OpenSession();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Cliente>();
                criteria.Add(Expression.Like("Username", username));
                try
                {
                    res = criteria.List<Cliente>()[0];
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }

       
    }
}
