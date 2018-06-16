using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CTRL_LAKE.Models
{
    public class Noleggio
    {
        private int _id { get; set; }
        private Cliente _cliente { get; set; }
        private DateTime _inizio { get; set; }
        private DateTime _fine { get; set; }
        private List<DettaglioNoleggio> _elencoDettagli { get; }
        
        public Noleggio(int id, Cliente cliente, DateTime inizio, DateTime fine)
        {
            if ((id < 0) || (cliente == null) || (inizio == null) || (fine == null))
                throw new Exception("Creazione Noleggio fallita, uno o più campi inseriti sono nulli");
            if (!dateVerified(inizio,fine))
                throw new Exception("Creazione Noleggio fallita, mismatch nelle date inserite");
                this._id = id;
                this._cliente = cliente;
                this._inizio = inizio;
                this._fine = fine;
                this._elencoDettagli = new List<DettaglioNoleggio>();
           
        }

        private Boolean dateVerified(DateTime inizio, DateTime fine)
        {
            if (inizio.CompareTo(fine) >= 0)
                return false;
            else if (inizio.TimeOfDay.CompareTo(new TimeSpan(9, 0, 0)) <= 0 || fine.TimeOfDay.CompareTo(new TimeSpan(19, 0, 0)) <= 0)
                return false;
            else if (!inizio.Date.Equals(fine.Date))
                return false;
            else return true;
        }

        /****GET/SET****/
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        public DateTime Inizio
        {
            get { return _inizio; }
            set { _inizio = value; }
        }

        public DateTime fine
        {
            get { return _fine; }
            set { _fine = value; }
        }

        public List<DettaglioNoleggio> DettaglioNoleggio
        {
            get { return _elencoDettagli; }
            //il set va fatto?
            
        }

        /****BUSINESS****/
        public void addDettaglio(DettaglioNoleggio dettaglio)
        {
            bool overlaps = false;
            if (dettaglio != null)
            {
                foreach (DettaglioNoleggio dt in this._elencoDettagli)
                    if (dt.OverlapsWith(dettaglio))
                    {
                        overlaps = true;
                        break;
                    }
                if (!overlaps)
                    this._elencoDettagli.Add(dettaglio);
                else throw new Exception("Dettaglio già inserito");
            }
                

        }

        public void rimuoviDettaglio(DettaglioNoleggio dettaglio)
        {
            if (!this._elencoDettagli.Remove(dettaglio))
                throw new Exception("Dettaglio non presente nella lista");
        }

    }//NOLEGGIO
}//END