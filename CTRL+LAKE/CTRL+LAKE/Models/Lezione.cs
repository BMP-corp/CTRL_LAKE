using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CTRL_LAKE.Models
{
    public class Lezione : IDettaglioPagamento
    {
        private int _id;
        private Istruttore _istruttore;
        private DateTime _inizio;
        private DateTime _fine;
        private int _partecipanti;
        private Cliente _cliente;

        public Lezione(int id, Istruttore istruttore, DateTime inizio, DateTime fine, int partecipanti, Cliente cliente)
        {

            if (inizio.CompareTo(fine) >= 0)
                throw new Exception("Impossibile creare impegno: intervallo non valido");
            if (inizio.TimeOfDay.CompareTo(new TimeSpan(9, 0, 0)) < 0
                || fine.TimeOfDay.CompareTo(new TimeSpan(19, 0, 0)) > 0)
                throw new Exception("Impossibile creare lezione: orari non possibili");
            if (!inizio.Date.Equals(fine.Date))
                throw new Exception("Impossibile creare lezione: non ammessi inizio e fine in due giorni distinti");
            if (partecipanti <= 0 || partecipanti > 5)
                throw new Exception("Impossibile creare lezione: numero partecipanti non valido");
            
            _id = id;
            _istruttore = istruttore;
            _inizio = inizio;
            _fine = fine;
            _partecipanti = partecipanti;
            _cliente = cliente;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public Istruttore Istruttore
        {
            get
            {
                return _istruttore;
            }
            set
            {
                _istruttore = value;
            }
        }

        public DateTime Inizio
        {
            get
            {
                return _inizio;
            }
            set
            {
                _inizio = value;
            }
        }

        public DateTime Fine
        {
            get
            {
                return _fine;
            }
            set
            {
                _fine = value;
            }
        }

        public Cliente Cliente
        {
            get
            {
                return _cliente;
            }
            set
            {
                _cliente = value;
            }
        }


        public int Partecipanti
        {
            get
            {
                return _partecipanti;
            }
            set
            {
                _partecipanti = value;
            }
        }

        public double CalcolaCosto()
        {
            throw new NotImplementedException();
        }

        public int getId()
        {
            return _id;
        }

        public string toString()
        {
            string result;
            result = "ID: " + _id + " ISTRUTTORE: " + _istruttore + " CLIENTE: " + _cliente;
            return result;
        }
    }
}