using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using CTRL_LAKE.Models;
using System.Collections.Generic;

namespace CTRL_LAKE.Models.Tests
{
    [TestClass()]
    public class AttrezzaturaTests
    {
        Attrezzatura a;
        //CalendarioImpegni c;
        //Impegno i1, i2, i3;
        [TestInitialize]
        public void Initialize()
        {
            a = new Attrezzatura("barcaVela", 101, 5);
            //c = new CalendarioImpegni();
            //c.Aggiungi(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));  // 15/06 9-11
            //c.Aggiungi(new DateTime(2018, 06, 15, 12, 0, 0), new DateTime(2018, 06, 15, 13, 0, 0)); // 15/06 12-13
            //c.Aggiungi(new DateTime(2018, 06, 16, 9, 0, 0), new DateTime(2018, 06, 16, 11, 0, 0));  // 16/06 9-11
        }

        [TestMethod()]
        public void AttrezzaturaTest()
        {
            Assert.AreEqual(a.Tipo, "barcaVela");
            Assert.AreEqual(a.IdAttrezzatura, 101);
            Assert.AreEqual(a.Posti, 5);
        }

        [TestMethod()]
        public void isCancellabileTest()
        {
            Assert.AreEqual(a.isCancellabile(), true);
        }

        [TestMethod()]
        public void elencaImpegniTest()
        {
            Assert.AreEqual(a.elencaImpegni().Count, 0);
            a.Riserva(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0), 2);
            Assert.AreEqual(a.elencaImpegni().Count, 1);
        }

        [TestMethod()]
        public void IsLiberoTest()
        {
            Assert.AreEqual(a.IsLibero(new DateTime(2018, 08, 15, 9, 0, 0), new DateTime(2018, 08, 15, 11, 0, 0)), true);
            a.Riserva(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0), 2);
            Assert.AreEqual(a.IsLibero(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 12, 0, 0)), false);
        }

        [TestMethod()]
        public void RiservaTest()
        {
            a.Riserva(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0), 2);
            a.Riserva(new DateTime(2018, 06, 15, 13, 0, 0), new DateTime(2018, 06, 15, 14, 0, 0), 2);
            a.Riserva(new DateTime(2018, 06, 16, 9, 0, 0), new DateTime(2018, 06, 16, 11, 0, 0), 2);
            a.Riserva(new DateTime(2018, 07, 15, 9, 0, 0), new DateTime(2018, 07, 15, 11, 0, 0), 2);
            a.Riserva(new DateTime(2018, 07, 15, 11, 0, 0), new DateTime(2018, 07, 15, 12, 0, 0), 2);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void RiservaTestFail1()              // fallimento per numero posti richiesti troppo elevato
        {
            a.Riserva(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0), 8);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void RiservaTestFail2()              // fallimento per sovrapposizione impegni
        {
            a.Riserva(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0), 2);
            a.Riserva(new DateTime(2018, 06, 15, 10, 0, 0), new DateTime(2018, 06, 15, 12, 0, 0), 1);
        }

        [TestMethod()]
        public void LiberaTest()
        {
            a.Riserva(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0), 2);
            a.Libera(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void LiberaTestFail1()
        {
            a.Riserva(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0), 2);
            a.Libera(new DateTime(2018, 06, 16, 9, 0, 0), new DateTime(2018, 06, 16, 11, 0, 0));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void LiberaTestFail2()
        {
            a.Riserva(new DateTime(2018, 06, 15, 10, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0), 2);
            a.Libera(new DateTime(2018, 06, 16, 9, 0, 0), new DateTime(2018, 06, 16, 11, 0, 0));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void LiberaTestFail3()
        {
            a.Riserva(new DateTime(2018, 06, 15, 10, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0), 2);
            a.Libera(new DateTime(2018, 06, 16, 9, 0, 0), new DateTime(2018, 06, 16, 13, 0, 0));
        }
    }
}