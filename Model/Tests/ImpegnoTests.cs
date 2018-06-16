using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelCtrlLake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCtrlLake.Tests
{
    [TestClass()]
    public class ImpegnoTests
    {
        [TestMethod()]
        public void ImpegnoTest()
        {
            Impegno imp = new Impegno(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));
            Assert.IsNotNull(imp);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void ImpegnoTestFail1()
        {
            Impegno imp = new Impegno(new DateTime(2018, 06, 15, 12, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void ImpegnoTestFail2()
        {
            Impegno imp = new Impegno(new DateTime(2018, 06, 15, 8, 0, 0), new DateTime(2018, 06, 15, 10, 0, 0));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void ImpegnoTestFail3()
        {
            Impegno imp = new Impegno(new DateTime(2018, 06, 15, 18, 0, 0), new DateTime(2018, 06, 15, 20, 0, 0));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void ImpegnoTestFail4()
        {
            Impegno imp = new Impegno(new DateTime(2018, 06, 15, 10, 0, 0), new DateTime(2018, 06, 16, 11, 0, 0));
        }

        [TestMethod()]
        public void OverlapsWithTest()
        {
            Impegno i1 = new Impegno(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));
            Impegno i2 = new Impegno(new DateTime(2018, 06, 15, 11, 0, 0), new DateTime(2018, 06, 15, 12, 0, 0));
            bool overlaps = i1.OverlapsWith(i2);
            Assert.AreEqual(false, overlaps);
            Impegno i3 = new Impegno(new DateTime(2018, 06, 15, 10, 0, 0), new DateTime(2018, 06, 15, 12, 0, 0));
            overlaps = i1.OverlapsWith(i3);
            Assert.AreEqual(true, overlaps);
            overlaps = i2.OverlapsWith(i3);
            Assert.AreEqual(true, overlaps);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Impegno i1 = new Impegno(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));
            Impegno i2 = new Impegno(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 10, 0, 0));
            Impegno i3 = new Impegno(new DateTime(2018, 06, 15, 10, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));
            Assert.AreNotEqual(i1, i2);
            Assert.AreNotEqual(i1, i3);
            Assert.AreNotEqual(i3, i2);
        }
    }
}