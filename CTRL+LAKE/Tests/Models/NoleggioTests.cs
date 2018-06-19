using CTRL_LAKE.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Models
{
    [TestClass()]
    class NoleggioTests
    {
        Noleggio n;
        Cliente z;
        [TestInitialize]
        public void Initialize()
        {
            z = new Cliente("zio", "pero", "zio.pero.1", new DateTime(1964, 02, 06), null, "3476253449");
            n = new Noleggio(005246, z, new DateTime(2018, 06, 15, 12, 0, 0), new DateTime(2018, 06, 15, 13, 0, 0));
        }

        [TestMethod()]
        public void NoleggioTest()
        {
            Assert.AreEqual(n.Id, 005246);
            Assert.AreEqual(n.Cliente.Username, "zio.pero.1");
            Assert.AreEqual(n.Cliente.Email, null);
            Assert.AreEqual(n.Inizio, new DateTime(2018, 06, 15, 12, 0, 0));
            Assert.AreEqual(n.fine, new DateTime(2018, 06, 15, 13, 0, 0));
        }

        [TestMethod()]
        public void addDettaglioTest()
        {
            Assert.AreEqual(n.DettaglioNoleggio.Count, 0);
            Attrezzatura barca = new Attrezzatura("Barca", 5647, 4);
            n.addDettaglio(new DettaglioNoleggio(56478, 4, barca, 54.5));
            Assert.AreEqual(n.DettaglioNoleggio.Count, 1);
            Assert.AreEqual(n.DettaglioNoleggio[0].Attrezzatura.Tipo, "Barca");
        }

        [TestMethod()]
        public void rimuoviDettaglioTest()
        {
            Assert.AreEqual(n.DettaglioNoleggio.Count, 0);
            Attrezzatura barca = new Attrezzatura("Barca", 5647, 4);
            n.addDettaglio(new DettaglioNoleggio(56478, 4, barca, 54.5));
            n.rimuoviDettaglio(new DettaglioNoleggio(56478, 4, barca, 54.5));
            Assert.AreEqual(n.DettaglioNoleggio.Count, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void dateMismatchCreate() //date inizio/fine invertite
        {
            Cliente z = new Cliente("zio", "pero", "zio.pero.1", new DateTime(1964, 02, 06), null, "3476253449");
            Noleggio n = new Noleggio(00001, z, new DateTime(2018, 06, 15, 13, 0, 0), new DateTime(2018, 06, 15, 12, 0, 0));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void wrongCreate() //passaggio di argomenti nulli
        {
            Noleggio n = new Noleggio(00001, null, new DateTime(2018, 06, 15, 12, 0, 0), new DateTime(2018, 06, 15, 13, 0, 0));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void addDuplicate()
        {
            Attrezzatura barca = new Attrezzatura("Barca", 5647, 4);
            n.addDettaglio(new DettaglioNoleggio(56478, 4, barca, 54.5));
            n.addDettaglio(new DettaglioNoleggio(56478, 4, barca, 54.5));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void removeTwice()  //rimozione dello stesso componente 2 volte
        {
            Assert.AreEqual(n.DettaglioNoleggio.Count, 1);
            Attrezzatura barca = new Attrezzatura("Barca", 5647, 4);
            n.addDettaglio(new DettaglioNoleggio(56478, 4, barca, 54.5));
            n.rimuoviDettaglio(new DettaglioNoleggio(56478, 4, barca, 54.5));
            n.rimuoviDettaglio(new DettaglioNoleggio(56478, 4, barca, 54.5));
        }
    }
}
