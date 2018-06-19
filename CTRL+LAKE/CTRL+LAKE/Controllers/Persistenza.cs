using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CTRL_LAKE.Models;
using NHibernate.Criterion;

namespace CTRL_LAKE.Controllers
{
    public class Persistenza
    {
        public static void insert()
        {
            Configuration myCfg = new Configuration();
            myCfg.Configure();
            ISessionFactory factory = myCfg.BuildSessionFactory();
            ISession sess = factory.OpenSession();
            using (sess.BeginTransaction())
            {
                Cliente c = new Cliente("Mic", "Camp", "mic.cam.1", new DateTime(1996, 8, 11), "carnazza@bk.it", "3334445556");
                sess.Persist(c);
                sess.Transaction.Commit();
            }
        }

        public static Cliente readCliente(String username)
        {
            Cliente res=null;
            Configuration myCfg = new Configuration();
            myCfg.Configure();
            ISessionFactory factory = myCfg.BuildSessionFactory();
            ISession sess = factory.OpenSession();
            using (sess.BeginTransaction())
            {
                ICriteria criteria = sess.CreateCriteria<Cliente>();
                criteria.Add(Restrictions.Like("username", username));
                res = criteria.List<Cliente>()[0];
            }
                return res;
        }

        public static void Main()
        {
            insert();
            Cliente c = readCliente("mic.cam.1");
            if (c != null)
                Console.WriteLine("[ " + c.Username + ", " + c.Nome + ", " + c.Cognome + " ]");
        }

    }
}