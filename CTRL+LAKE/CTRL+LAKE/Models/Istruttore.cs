using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CTRL_LAKE.Models
{
    public class Istruttore
    {
        private string _nome;
        private string _cognome;
        private string _username;
        private DateTime _dataNascita;
        private string _email;
        private string _telefono;
        private string _iban;
        private string _attivita;
        private CalendarioImpegni _impegni;
        private string _orario;

        public virtual string Nome { get => _nome; set => _nome = value; }
        public virtual string Cognome { get => _cognome; set => _cognome = value; }
        public virtual string Username { get => _username; set => _username = value; }
        public virtual DateTime DataNascita { get => _dataNascita; set => _dataNascita = value; }
        public virtual string Email { get => _email; set => _email = value; }
        public virtual string Telefono { get => _telefono; set => _telefono = value; }
        public virtual string Iban { get => _iban; set => _iban = value; }
        public virtual string Attivita { get => _attivita; set => _attivita = value; }
        public virtual string Orario { get => _orario; set => _orario = value; }

        public Istruttore(string nome, string cognome, string username, DateTime dataNascita,
            string email, string telefono, string iban, string attivita, string orario)
        {
            Nome = nome;
            Cognome = cognome;
            Username = username;
            DataNascita = dataNascita;
            Email = email;
            Telefono = telefono;
            Iban = iban;
            Attivita = attivita;
            _impegni = new CalendarioImpegni();
            _orario = orario;
        }

        public Istruttore ()
        {
            _impegni = new CalendarioImpegni();
        }

        public virtual List<Impegno> elencaImpegni()
        {
            return this._impegni.Impegni;
        }

        public virtual bool IsLibero(DateTime inizio, DateTime fine)
        {
            bool result = true;
            Impegno richiesto = null;
            try
            {
                richiesto = new Impegno(inizio, fine);
            }
            catch (Exception e) { throw e; }
            foreach (Impegno i in this.elencaImpegni())
                if (i.Inizio.Day == inizio.Day)
                    if (i.OverlapsWith(richiesto))
                    {
                        result = false;
                        break;
                    }
            return result;
        }

        public virtual void Riserva(DateTime inizio, DateTime fine)
        {
            try
            {
                this._impegni.Aggiungi(inizio, fine);
            }
            catch (Exception e) { throw e; }
        }

        public virtual void Libera(DateTime inizio, DateTime fine)
        {
            try
            {
                this._impegni.Rimuovi(inizio, fine);
            }
            catch (Exception e) { throw e; }
        }

    }
}
