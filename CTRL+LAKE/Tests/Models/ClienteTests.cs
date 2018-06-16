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
    public class ClienteTests
    {
        Cliente cli = null;
        String nome = "Andre";
        String cognome = "Moce";
        String username = "and.moc.6";
        DateTime birth = new DateTime(1996, 9, 8);
        String email = null;
        String telefono = null;
        

        [TestMethod()]
        public void ClienteTest()
        {
            email = "and.moc@mail.it";
            telefono = "3332221110";
            cli = new Cliente(nome, cognome, username, birth, email, telefono);
            Assert.AreNotEqual(cli, null);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void ClienteTestFail1()
        {
            email = "andmocmail.it";
            telefono = "3332221110";
            cli = new Cliente(nome, cognome, username, birth, email, telefono);
            Assert.AreNotEqual(cli, null);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void ClienteTestFail2()
        {
            email = "andmoc@mail.it";
            telefono = "3332210";
            cli = new Cliente(nome, cognome, username, birth, email, telefono);
            Assert.AreNotEqual(cli, null);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void ClienteTestFail3()
        {
            telefono = "3332221110";
            cli = new Cliente(nome, cognome, username, birth, email, telefono);
            Assert.AreNotEqual(cli, null);
        }
    }
}