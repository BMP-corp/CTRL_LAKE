using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTRL_LAKE.Models
{
    public class Attrezzatura
    {
        private string _tipo;
        private int _idAttrezzatura;
        private int _posti;
        private CalendarioImpegni _impegni;

        public virtual string Tipo { get => _tipo; set => _tipo = value; }
        public virtual int IdAttrezzatura { get => _idAttrezzatura; set => _idAttrezzatura = value; }
        public virtual int Posti { get => _posti; set => _posti = value; }

        public Attrezzatura(string tipo, int idAttrezzatura, int posti)
        {
            Tipo = tipo;
            IdAttrezzatura = idAttrezzatura;
            Posti = posti;
            _impegni = new CalendarioImpegni(""+_idAttrezzatura);
        }

        public Attrezzatura() {
        }

        
        
        public virtual bool isCancellabile()
        {
            return (this._impegni.ProssimiImpegni() == 0);
        }

        public virtual List<Impegno> elencaImpegni()
        {
            return this._impegni.Impegni;
        }

        public virtual bool IsLibero (DateTime inizio, DateTime fine)
        {
            bool result = true;
            Impegno richiesto = null;
            try
            {
                richiesto = new Impegno(inizio, fine, ""+_idAttrezzatura);
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
        
        public virtual void Riserva (DateTime inizio, DateTime fine, int persone)
        {
            if (persone > this.Posti || persone<1)
            {
                throw new Exception("Impossibile riservare questo oggetto per " + persone + "persone");
            }
                try
                {
                    this._impegni.Aggiungi(inizio, fine);
                } catch (Exception e) { throw e; }
        }

        public virtual void Libera(DateTime inizio, DateTime fine)
        {
            try
            {
                this._impegni.Rimuovi(inizio, fine);
            } catch (Exception e) { throw e; }
        }

    }
}
