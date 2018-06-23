using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CTRL_LAKE.Models
{
    public class DettaglioNoleggio : IDettaglioPagamento
    {
        private int _id;
        private int _utilizzatori;
        private double _costo;
        private Attrezzatura _attrezzatura;

        public int Id { get => _id; set => _id = value; }
        public int Utilizzatori { get => _utilizzatori; set => _utilizzatori = value; }
        public double Costo { get => _costo; set => _costo = value; }
        public Attrezzatura Attrezzatura { get => _attrezzatura; set => _attrezzatura = value; }

        public DettaglioNoleggio(int id, int utilizzatori, Attrezzatura attrezzatura, double costo, DateTime inizio, DateTime fine)
        {

            if (attrezzatura == null)
                throw new Exception("Impossibile creare dettaglio noleggio: campo attrezzatura nullo");
            if (costo <= 0)
                throw new Exception("Impossibile creare dettaglio noleggio: costo non valido");

            _id = id;
            _attrezzatura = attrezzatura;
            try
            {
                _attrezzatura.Riserva(inizio, fine, utilizzatori);
            } catch (Exception e)
            {
                throw e;
            }
            _utilizzatori = utilizzatori;
            _costo = costo;

        }


        public DettaglioNoleggio() {
        }


        public double CalcolaCosto()
        {
            return _costo;
        }

        public int GetId()
        {
            return _id;
        }


        public string ToString()
        {
            string result;
            result = "ID " + _id + ": " + _attrezzatura + ", " + _utilizzatori + " persone, " + this._costo + "€";
            return result;
        }

        public void Elimina(DateTime inizio, DateTime fine)
        {
            try
            {
                _attrezzatura.Libera(inizio, fine);
            } catch (Exception e)
            {
                throw e;
            }
        }
        
    }
}