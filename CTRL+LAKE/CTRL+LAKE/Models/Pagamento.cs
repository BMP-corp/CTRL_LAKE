using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CTRL_LAKE.Models
{
    public class Pagamento
    {
        private DateTime _dataOra { get; set; }
        private int _id { get; set; }
        private double _totale { get; set; }
        private double _pagato { get; set; }
        private List<IDettaglioPagamento> _dettagli { get; set; }


        public Pagamento(int id, DateTime now, double totale, double pagato)
        {
            if ((id == null) || (pagato == null) || (totale == null) || (now == null))
                throw new Exception("Creazione Pagamento non riuscita, dati non validi");

            this._id = id;
            this._pagato = pagato;
            this._totale = totale;
            this._dataOra = now;
            this._dettagli = new List<IDettaglioPagamento>();
        }

        /*****GET/SET******/
        public double Totale 
        {
            get { return _totale; }
            set { _totale = value; }
        }

        public double Pagato
        {
            get { return _pagato; }
            set { _pagato = value; }
        }

        public DateTime Now
        {
            get { return _now; }
            set { _now = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public List<IDettaglioPagamento> Dettagli
        {
            get { return _dettagli; }
            set { _dettagli = value; }
        }

        /*****BUSINESS******/
        public void addDettaglio(IDettaglioPagamento dettaglio)
        {
           Boolean exists = false;
            foreach (IDettaglioPagamento d in _dettagli)
                if (d.getId == dettaglio.getId)
                    exists = true;
                if (!exists)
                    _dettagli.Add(dettaglio);
                else throw new Exception("Dettaglio già esistente");
        }

        public Boolean isPagato()
        {
            if (this._pagato == this._totale)
                return true;
            else return false;
        }

 
        public void paga() //se non c'è importo si assume che paghi tutto
        {
            this._pagato = this._totale;
        }

        public double calcolaTotale()
        {
            double totale = 0.0;
            foreach(IDettaglioPagamento d in this._dettagli)
                totale += d.CalcolaCosto();
            return totale;
        }
 
    }
}//END