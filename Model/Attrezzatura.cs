using System;
using System.Collections.Generic;

namespace ModelCtrlLake
{
    public class Attrezzatura
    {
        private string _tipo;
        private int _idAttrezzatura;
        private int _posti;
        private CalendarioImpegni _impegni;

        public Attrezzatura(string tipo, int idAttrezzatura, int posti)
        {
            _tipo = tipo;
            _idAttrezzatura = idAttrezzatura;
            _posti = posti;
            _impegni = new CalendarioImpegni();
        }

        public Attrezzatura() { _impegni = new CalendarioImpegni(); }

        public string Tipo
        {
            get { return _tipo; }
            //set { _tipo = value; }
        }

        public int IdAttrezzatura
        {
            get { return _idAttrezzatura; }
            //set { _idAttrezzatura = value; }
        }

        public int Posti
        {
            get { return _posti;}
            //set { _posti = value; }
        }
        
        public bool isCancellabile()
        {
            return (this._impegni.ProssimiImpegni() == 0);
        }

        public List<Impegno> elencaImpegni()
        {
            return this._impegni.Impegni;
        }

        public bool IsLibero (DateTime inizio, DateTime fine)
        {
            bool result = true;
            Impegno richiesto = null;
            try
            {
                richiesto = new Impegno(inizio, fine);
            } catch (Exception e) { throw e; }
            foreach (Impegno i in this.elencaImpegni())
                if (i.Inizio.Day == inizio.Day)
                    if (i.OverlapsWith(richiesto))
                    {
                        result = false;
                        break;
                    }
            return result;
        }
        
        public void Riserva (DateTime inizio, DateTime fine, int persone)
        {
            if (persone > this._posti || persone<1)
            {
                throw new Exception("Impossibile riservare questo oggetto per " + persone + "persone");
            }
                try
                {
                    this._impegni.Aggiungi(inizio, fine);
                } catch (Exception e) { throw e; }
        }

        public void Libera(DateTime inizio, DateTime fine)
        {
            try
            {
                this._impegni.Rimuovi(inizio, fine);
            } catch (Exception e) { throw e; }
        }

    }
}
