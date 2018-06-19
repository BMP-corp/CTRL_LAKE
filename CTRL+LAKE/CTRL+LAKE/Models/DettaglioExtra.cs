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

        public int Id { get => _id; set => _id = value; }
        public string Descrizione { get => _descrizione; set => _descrizione = value; }
        public double Costo { get => _costo; set => _costo = value; }

        public DettaglioExtra(int id, string descrizione, double costo)
        {
            if (id < 0 || costo <= 0)
                throw new Exception("Impossibile creare il dettaglio: id o costo negativo");
            _id = id;
            _descrizione = descrizione;
            _costo = costo;
       
        }
        public double CalcolaCosto()
        {
            return _costo;
        }

        public string ToString()
        {
            string result = "Id " + _id + ": " + _descrizione + ", " + _costo + "€";
            return result;

        }

        public int GetId()
        {
            return _id;
        }
    }
}