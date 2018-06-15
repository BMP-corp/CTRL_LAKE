using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CTRL_LAKE.Models
{
    public class DettaglioExtra : IDettaglioPagamento
    {

        private int _id;
        private string _descrizione;
        private double _costo;

        public DettaglioExtra(int id, string descrizione, double costo)
        {
            _id = id;
            _descrizione = descrizione;
            _costo = costo;
       
        }
        public double CalcolaCosto()
        {
            return _costo;
        }

        public string toString()
        {
            string result;
            result = _id + _descrizione + _costo;
            return result;

        }

        public int getId()
        {
            return _id;
        }
    }
}