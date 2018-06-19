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

        public int Id { get => _id; set => _id = value; }
        public Istruttore Istruttore { get => _istruttore; set => _istruttore = value; }
        public DateTime Inizio { get => _inizio; set => _inizio = value; }
        public DateTime Fine { get => _fine; set => _fine = value; }
        public int Partecipanti { get => _partecipanti; set => _partecipanti = value; }
        public Cliente Cliente { get => _cliente; set => _cliente = value; }
        public double Costo { get => _costo; set => _costo = value; }

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
            try
            {
                _istruttore.Riserva(inizio, fine);
            }
            catch (Exception e) { throw e; }
            _inizio = inizio;
            _fine = fine;
            _partecipanti = partecipanti;
            _cliente = cliente;
            _costo = costo;
        }

        public Lezione(int id, Istruttore istruttore, DateTime inizio, DateTime fine, int partecipanti, Cliente cliente)
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

            _id = id;
            _istruttore = istruttore;
            try
            {
                _istruttore.Riserva(inizio, fine);
            } catch (Exception e) { throw e; }
            _inizio = inizio;
            _fine = fine;
            _partecipanti = partecipanti;
            _cliente = cliente;
        }
        
        public int GetId()
        {
            return _id;
        }

        //Calcola costo si potrebbe eliminare in quanto equivalente al get 
        //CalcolaCosto è richesta dall' interfaccia, non si può togliere. Il get si.
        public double CalcolaCosto()
        {
           return _costo;
        }

        public string ToString()
        {
            string result;
            result = "ID: " + _id + " ISTRUTTORE: " + _istruttore + " CLIENTE: " + _cliente;
            return result;
        }
    }
}