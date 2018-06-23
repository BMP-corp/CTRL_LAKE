using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CTRL_LAKE.Models
{
    public class Credenziali
    {

        private string _username;
        private string _password;
        private string _ruolo;

        public virtual string Username { get => _username; set => _username = value; }
        public virtual string Password { get => _password; set => _password = value; }
        public virtual string Ruolo { get => _ruolo; set => _ruolo = value; }

        public Credenziali()
        {

        }

        public Credenziali(string username, string password, string ruolo)
        {
            _username = username;
            _password = password;
            _ruolo = ruolo;

        }
    }
}