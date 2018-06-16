using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CTRL_LAKE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Models
{
    [TestClass()]
    public class NoleggioTest
    {
        Noleggio n;
        Cliente c;

        [TestInitialize]
        public void Initialize()
        {
            c = new Cliente();
            n = new Noleggio(0006742, Cliente cliente, DateTime inizio, DateTime fine);
           
        }
    
    }
}
