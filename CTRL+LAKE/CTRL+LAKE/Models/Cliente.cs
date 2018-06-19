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


        public virtual string Nome { get => _nome; set => _nome = value; }
        public virtual string Cognome { get => _cognome; set => _cognome = value; }
        public virtual string Username { get => _username; set => _username = value; }
        public virtual string Email { get => _email; set => _email = value; }
        public virtual DateTime DataNascita { get => _dataNascita; set => _dataNascita = value; }
        public virtual string Telefono { get => _telefono; set => _telefono = value; }

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

            foreach (char c in telefono)
                if (!Char.IsDigit(c))
                    throw new Exception("Impossibile creare cliente: formato telefono non valido");

            //controllo (blando) della email
            if ( (!email.Contains("@") || !email.Contains("."))
                || email.LastIndexOf('.')<email.LastIndexOf('@') )
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

        public Cliente() {
        }
    }
}