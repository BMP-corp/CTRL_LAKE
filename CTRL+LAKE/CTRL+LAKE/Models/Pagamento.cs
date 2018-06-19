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


        public Pagamento(int id, double pagato)
        {
            if ( id < 0 || pagato < 0 )
                throw new Exception("Creazione Pagamento non riuscita, dati non validi");

            this._id = id;
            this._pagato = pagato;
            this._dataOra = DateTime.Now;
            this._dettagli = new List<IDettaglioPagamento>();
            this._totale = CalcolaTotale();
        }

        public Pagamento () {
            this._dataOra = DateTime.Now;
            this._dettagli = new List<IDettaglioPagamento>();
            this._totale = CalcolaTotale();
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

        public DateTime DataOra
        {
            get { return _dataOra; }
            set { _dataOra = value; }
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
        public void AddDettaglio(IDettaglioPagamento dettaglio)
        {
           bool exists = false;
            foreach (IDettaglioPagamento d in _dettagli)
                if (d.GetId() == dettaglio.GetId())
                {
                    exists = true;
                    break;
                }
            if (!exists)
            {
                _dettagli.Add(dettaglio);
                _totale = CalcolaTotale();
            }
            else throw new Exception("Dettaglio già esistente");
        }

        public bool IsPagato()
        {
            if (this._pagato == this._totale)
                return true;
            else return false;
        }

 
        public void Paga() //se non c'è importo si assume che paghi tutto
        {
            this._pagato = this._totale;
            _dataOra = DateTime.Now;
        }

        public double CalcolaTotale()
        {
            double totale = 0;
            foreach(IDettaglioPagamento d in this._dettagli)
                totale += d.CalcolaCosto();
            return totale;
        }
 
    }
}//END