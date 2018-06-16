using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CTRL_LAKE.Models
{
    public class Cliente
    {
        private string _nome;
        private string _cognome;
        private string _username;
        private string _email;
        private DateTime _dataNascita;
        private string _telefono;


        public Cliente(string nome, string cognome, string username, DateTime dataNascita, string email, string telefono)
        {
            if(nome == null || cognome == null || username==null || dataNascita == null || email == null || telefono == null)
            {
                throw new Exception("Impossibile creare cliente: valore di un campo nullo");
            }

            //controllo che il numero di telefono abbia le cifre di un cellulare o fisso (anche vecchio con 9 cifre)
            if(telefono.Length != 10 && telefono.Length != 9)
            {
                throw new Exception("Impossibile creare cliente: formato telefono non valido");
            }

            //controllo (blando) della email
            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new Exception("Impossibile creare cliente: formato email non valido");
            }


            _nome = nome;
            _cognome = cognome;
            _username = username;
            _dataNascita = dataNascita;
            _email = email;
            _telefono = telefono;

        }

        public string Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                _nome = value;
            }
        }

        public string Cognome
        {
            get
            {
                return _cognome;
            }
            set
            {
                _cognome = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public DateTime DataNascita
        {
            get
            {
                return _dataNascita;
            }
            set
            {
                  _dataNascita = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
            }
        }
    }
}