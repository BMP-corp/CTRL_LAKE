using Microsoft.VisualStudio.TestTools.UnitTesting;
using CTRL_LAKE.Models;
using System;
using System.Linq;


namespace CTRL_LAKE.Tests
{
    [TestClass()]
    public class IstruttoreTests
    {
        Istruttore i;

        [TestInitialize]
        public void Initialize()
        {
            i = new Istruttore("Fra", "Mazzu", "fra.maz.1", new DateTime(1996,4,1), "framaz@mail.it", "3334445556", "fakeIban", "barcaVela");
            //c = new CalendarioImpegni();
            //c.Aggiungi(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));  // 15/06 9-11
            //c.Aggiungi(new DateTime(2018, 06, 15, 12, 0, 0), new DateTime(2018, 06, 15, 13, 0, 0)); // 15/06 12-13
            //c.Aggiungi(new DateTime(2018, 06, 16, 9, 0, 0), new DateTime(2018, 06, 16, 11, 0, 0));  // 16/06 9-11
        }
        [TestMethod()]
        public void IstruttoreTest()
        {
            Assert.AreEqual(i.Nome, "Fra");
            Assert.AreEqual(i.Cognome, "Mazzu");
            Assert.AreEqual(i.Username, "fra.maz.1");
            Assert.AreEqual(i.DataNascita, new DateTime(1996,4,1));
            Assert.AreEqual(i.Email, "framaz@mail.it");
            Assert.AreEqual(i.Telefono, "3334445556");
            Assert.AreEqual(i.Iban, "fakeIban");
            Assert.AreEqual(i.Attivita, "barcaVela");
        }

        

        [TestMethod()]
        public void elencaImpegniTest()
        {
            Assert.AreEqual(i.elencaImpegni().Count, 0);
            i.Riserva(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));
            Assert.AreEqual(i.elencaImpegni().Count, 1);
        }

        [TestMethod()]
        public void IsLiberoTest()
        {
            Assert.AreEqual(i.IsLibero(new DateTime(2018, 08, 15, 9, 0, 0), new DateTime(2018, 08, 15, 11, 0, 0)), true);
            i.Riserva(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));
            Assert.AreEqual(i.IsLibero(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 12, 0, 0)), false);
        }

        [TestMethod()]
        public void RiservaTest()
        {
            i.Riserva(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));
            i.Riserva(new DateTime(2018, 06, 15, 13, 0, 0), new DateTime(2018, 06, 15, 14, 0, 0));
            i.Riserva(new DateTime(2018, 06, 16, 9, 0, 0), new DateTime(2018, 06, 16, 11, 0, 0));
            i.Riserva(new DateTime(2018, 07, 15, 9, 0, 0), new DateTime(2018, 07, 15, 11, 0, 0));
            i.Riserva(new DateTime(2018, 07, 15, 11, 0, 0), new DateTime(2018, 07, 15, 12, 0, 0));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void RiservaTestFail2()              // fallimento per sovrapposizione impegni
        {
            i.Riserva(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));
            i.Riserva(new DateTime(2018, 06, 15, 10, 0, 0), new DateTime(2018, 06, 15, 12, 0, 0));
        }

        [TestMethod()]
        public void LiberaTest()
        {
            i.Riserva(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));
            i.Libera(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void LiberaTestFail1()
        {
            i.Riserva(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));
            i.Libera(new DateTime(2018, 06, 16, 9, 0, 0), new DateTime(2018, 06, 16, 11, 0, 0));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void LiberaTestFail2()
        {
            i.Riserva(new DateTime(2018, 06, 15, 10, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));
            i.Libera(new DateTime(2018, 06, 16, 9, 0, 0), new DateTime(2018, 06, 16, 11, 0, 0));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void LiberaTestFail3()
        {
            i.Riserva(new DateTime(2018, 06, 15, 10, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));
            i.Libera(new DateTime(2018, 06, 16, 9, 0, 0), new DateTime(2018, 06, 16, 13, 0, 0));
        }
    }
}