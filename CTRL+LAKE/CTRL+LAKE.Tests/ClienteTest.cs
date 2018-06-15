// <copyright file="ClienteTest.cs">Copyright ©  2018</copyright>
using System;
using CTRL_LAKE.Models;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CTRL_LAKE.Models.Tests
{
    /// <summary>Questa classe contiene unit test con parametri per Cliente</summary>
    [PexClass(typeof(Cliente))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ClienteTest
    {
        /// <summary>Test stub per get_Cognome()</summary>
        [PexMethod]
        public string CognomeGetTest([PexAssumeUnderTest]Cliente target)
        {
            string result = target.Cognome;
            return result;
            // TODO: aggiungere asserzioni a metodo ClienteTest.CognomeGetTest(Cliente)
        }

        /// <summary>Test stub per set_Cognome(String)</summary>
        [PexMethod]
        public void CognomeSetTest([PexAssumeUnderTest]Cliente target, string value)
        {
            target.Cognome = value;
            // TODO: aggiungere asserzioni a metodo ClienteTest.CognomeSetTest(Cliente, String)
        }

        /// <summary>Test stub per .ctor(String, String, DateTime, String, String)</summary>
        [PexMethod]
        public Cliente ConstructorTest(
            string nome,
            string cognome,
            DateTime dataNascita,
            string email,
            string telefono
        )
        {
            Cliente target = new Cliente(nome, cognome, dataNascita, email, telefono);
            return target;
            // TODO: aggiungere asserzioni a metodo ClienteTest.ConstructorTest(String, String, DateTime, String, String)
        }

        /// <summary>Test stub per get_DataNascita()</summary>
        [PexMethod]
        public DateTime DataNascitaGetTest([PexAssumeUnderTest]Cliente target)
        {
            DateTime result = target.DataNascita;
            return result;
            // TODO: aggiungere asserzioni a metodo ClienteTest.DataNascitaGetTest(Cliente)
        }

        /// <summary>Test stub per set_DataNascita(DateTime)</summary>
        [PexMethod]
        public void DataNascitaSetTest([PexAssumeUnderTest]Cliente target, DateTime value)
        {
            target.DataNascita = value;
            // TODO: aggiungere asserzioni a metodo ClienteTest.DataNascitaSetTest(Cliente, DateTime)
        }

        /// <summary>Test stub per get_Email()</summary>
        [PexMethod]
        public string EmailGetTest([PexAssumeUnderTest]Cliente target)
        {
            string result = target.Email;
            return result;
            // TODO: aggiungere asserzioni a metodo ClienteTest.EmailGetTest(Cliente)
        }

        /// <summary>Test stub per set_Email(String)</summary>
        [PexMethod]
        public void EmailSetTest([PexAssumeUnderTest]Cliente target, string value)
        {
            target.Email = value;
            // TODO: aggiungere asserzioni a metodo ClienteTest.EmailSetTest(Cliente, String)
        }

        /// <summary>Test stub per get_Nome()</summary>
        [PexMethod]
        public string NomeGetTest([PexAssumeUnderTest]Cliente target)
        {
            string result = target.Nome;
            return result;
            // TODO: aggiungere asserzioni a metodo ClienteTest.NomeGetTest(Cliente)
        }

        /// <summary>Test stub per set_Nome(String)</summary>
        [PexMethod]
        public void NomeSetTest([PexAssumeUnderTest]Cliente target, string value)
        {
            target.Nome = value;
            // TODO: aggiungere asserzioni a metodo ClienteTest.NomeSetTest(Cliente, String)
        }

        /// <summary>Test stub per get_Telefono()</summary>
        [PexMethod]
        public string TelefonoGetTest([PexAssumeUnderTest]Cliente target)
        {
            string result = target.Telefono;
            return result;
            // TODO: aggiungere asserzioni a metodo ClienteTest.TelefonoGetTest(Cliente)
        }

        /// <summary>Test stub per set_Telefono(String)</summary>
        [PexMethod]
        public void TelefonoSetTest([PexAssumeUnderTest]Cliente target, string value)
        {
            target.Telefono = value;
            // TODO: aggiungere asserzioni a metodo ClienteTest.TelefonoSetTest(Cliente, String)
        }

        /// <summary>Test stub per get_Username()</summary>
        [PexMethod]
        public string UsernameGetTest([PexAssumeUnderTest]Cliente target)
        {
            string result = target.Username;
            return result;
            // TODO: aggiungere asserzioni a metodo ClienteTest.UsernameGetTest(Cliente)
        }

        /// <summary>Test stub per set_Username(String)</summary>
        [PexMethod]
        public void UsernameSetTest([PexAssumeUnderTest]Cliente target, string value)
        {
            target.Username = value;
            // TODO: aggiungere asserzioni a metodo ClienteTest.UsernameSetTest(Cliente, String)
        }
    }
}
