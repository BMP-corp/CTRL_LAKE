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

        public DettaglioNoleggio(int id, int utilizzatori, Attrezzatura attrezzatura, double costo)
        {

            if (attrezzatura == null)
                throw new Exception("Impossibile creare dettaglio noleggio: campo attrezzatura nullo");
            if (utilizzatori <= 0 || utilizzatori > 5)
                throw new Exception("Impossibile creare dettaglio noleggio: numero utilizzatori non valido");
            if (costo <= 0)
                throw new Exception("Impossibile creare dettaglio noleggio: costo non valido");
            
            _id = id;
            _utilizzatori = utilizzatori;
            _attrezzatura = attrezzatura;
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


        public Attrezzatura Attrezzatura
        {
            get
            {
                return _attrezzatura;
            }
            set
            {
                _attrezzatura = value;
            }
        }


        public int Utilizzatori
        {
            get
            {
                return _utilizzatori;
            }
            set
            {
                _utilizzatori = value;
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

         public int Costo
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
            result = "ID: " + _id + " ATTREZZATURA: " + _attrezzatura + " UTILIZZATORI: " + _utilizzatori;
            return result;
        }
    }
}