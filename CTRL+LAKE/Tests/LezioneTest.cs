using Microsoft.VisualStudio.TestTools.UnitTesting;
using CTRL_LAKE.Models;
using System;
using System.Linq;


namespace CTRL_LAKE.Tests
{
    [TestClass()]
    public class LezioneTests
    {
        Lezione l;
        Cliente cli;
        Istruttore istr;

        [TestInitialize]
        public void Initialize()
        {
            cli = new Cliente("Mich", "Camp", new DateTime(1996, 8, 8), "miccam@mail.it", "3334567778");
            istr = new Istruttore("Fra", "Mazzu", "fra.maz.1", new DateTime(1996, 4, 1), "framaz@mail.it", "3334445556", "fakeIban", "barcaVela");
        }

        [TestMethod()]
        public void LezioneTest()
        {
            l = new Lezione(100, istr, new DateTime(2018, 07, 15, 9, 0, 0), new DateTime(2018, 07, 15, 11, 0, 0),
                2, cli);
            l.Costo = 45.99;
            Assert.AreEqual(l.Cliente.Nome, "Mich");
            Assert.AreEqual(l.Istruttore.Cognome, "Mazzu");
            Assert.AreEqual(l.Id, 100);
            Assert.AreEqual(l.Inizio, new DateTime(2018, 07, 15, 9, 0, 0));
            Assert.AreEqual(l.Fine, new DateTime(2018, 07, 15, 11, 0, 0));
            Assert.AreEqual(l.Partecipanti, 2);
            Assert.AreEqual(l.Costo, 45.99);
            Assert.AreEqual(l.Istruttore.IsLibero(new DateTime(2018, 07, 15, 9, 0, 0), new DateTime(2018, 07, 15, 11, 0, 0)), false);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void LezioneTestFail1()
        {
            l = new Lezione(100, istr, new DateTime(2018, 07, 15, 9, 0, 0), new DateTime(2018, 07, 15, 11, 0, 0),
                7, cli);
            l.Costo = 85.99;
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void LezioneTestFail2()
        {
            l = new Lezione(100, istr, new DateTime(2018, 07, 15, 9, 0, 0), new DateTime(2018, 07, 15, 9, 0, 0),
                2, cli);
            l.Costo = 45.99;
        }
    }
}
