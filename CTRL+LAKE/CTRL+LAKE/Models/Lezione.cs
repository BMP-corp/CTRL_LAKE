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
        private double _costo;

        public Lezione(int id, Istruttore istruttore, DateTime inizio, DateTime fine, int partecipanti, Cliente cliente, double costo)
        {

            if (inizio.CompareTo(fine) >= 0)
                throw new Exception("Impossibile creare lezione: intervallo non valido");
            if (inizio.TimeOfDay.CompareTo(new TimeSpan(9, 0, 0)) < 0
                || fine.TimeOfDay.CompareTo(new TimeSpan(19, 0, 0)) > 0)
                throw new Exception("Impossibile creare lezione: orari non possibili");
            if (!inizio.Date.Equals(fine.Date))
                throw new Exception("Impossibile creare lezione: non ammessi inizio e fine in due giorni distinti");
            if (partecipanti <= 0 || partecipanti > 5)
                throw new Exception("Impossibile creare lezione: numero partecipanti non valido");
            if (costo <= 0)
                throw new Exception("Impossibile creare lezione: costo non valido");
            
            _id = id;
            _istruttore = istruttore;
            _inizio = inizio;
            _fine = fine;
            _partecipanti = partecipanti;
            _cliente = cliente;
            _costo = costo;

        }

        public int Id
        {
            get
            {
                return _id;
            }
            set{_id = value;}
        }

        public Istruttore Istruttore
        {
            get
            {
                return _istruttore;
            }
            set{ _istruttore = value;}
        }

        public DateTime Inizio
        {
            get
            {
                return _inizio;
            }
            set{_inizio = value;}
        }

<<<<<<< HEAD
        public DateTime Fine
        {
            get
            {
=======
        public int Id
        {
            get
            {
                return _id;
            }
            set{ _id = value; }
        }

        public Istruttore Istruttore
        {
            get
            {
                return _istruttore;
            }
            set
            {
                try
                {
                    if (_istruttore!=null)
                        _istruttore.Libera(_inizio, _fine);
                    _istruttore = value;
                    _istruttore.Riserva(_inizio, _fine);
                } catch (Exception e) { throw e; }
            }
        }

        public DateTime Inizio
        {
            get
            {
                return _inizio;
            }
            set{_inizio = value;}
        }

        public DateTime Fine
        {
            get
            {
>>>>>>> parent of 59f9349... corretto model, aggiunto test
                return _fine;
            }
            set{ _fine = value;}
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

        //Calcola costo si potrebbe eliminare in quanto equivalente al get 
        public double CalcolaCosto()
        {
           return _costo;
        }

        public int getId()
        {
            return _id;
        }

<<<<<<< HEAD
         public int Costo
=======
         public double Costo
>>>>>>> parent of 59f9349... corretto model, aggiunto test
        {
            get
            {
                return _costo;
            }
            set{_costo = value;}
        }

        public string toString()
        {
            string result;
            result = "ID: " + _id + " ISTRUTTORE: " + _istruttore + " CLIENTE: " + _cliente;
            return result;
        }
    }
}