using Microsoft.VisualStudio.TestTools.UnitTesting;
using CTRL_LAKE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTRL_LAKE.Models.Tests
{
    [TestClass()]
    public class DettaglioExtraTests
    {
        [TestMethod()]
        public void DettaglioExtraTest()
        {
            DettaglioExtra extra = new DettaglioExtra(1001, "Rotto remo canoa", 45);
            Assert.AreEqual(extra.Id, 1001);
            Assert.AreEqual(extra.Descrizione, "Rotto remo canoa");
            Assert.AreEqual(extra.Costo, 45);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void DettaglioExtraTestFail1()
        {
            DettaglioExtra extra = new DettaglioExtra(-5, "Rotto remo canoa", 45);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void DettaglioExtraTestFail2()
        {
            DettaglioExtra extra = new DettaglioExtra(105, "Rotto remo canoa", 0);
        }


    }
}