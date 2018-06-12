using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCtrlLake
{
    public class CalendarioImpegni
    {
        private List<Impegno> _impegni { get; }

        public CalendarioImpegni()
        {
            this._impegni = new List<Impegno>();
        }

        public List<Impegno> GetImpegni ()
        {
            return this._impegni;
        }

        public Impegno getImpegno (DateTime inizio, DateTime fine)
        {
            Impegno res = null, i2=new Impegno(inizio, fine);
            
            foreach (Impegno i in this._impegni)
                if (i.Equals(i2))
                {
                    res = i; break;
                }
            return res;
        }

        public void Aggiungi(DateTime inizio, DateTime fine)
        {
            Impegno imp = null;
            try { imp = new Impegno(inizio, fine); }
            catch (Exception e) { throw e; }
            bool overlaps = false;
            foreach (Impegno i in this._impegni)
                if (i.OverlapsWith(imp))
                {
                    overlaps = true; break;
                }
            if (!overlaps)
                this._impegni.Add(imp);
            else
                throw new Exception("L'impegno richiesto si sovrappone con uno già esistente!");
        }

        public void Rimuovi(DateTime inizio, DateTime fine)
        {
            Impegno imp = null;
            imp = this.getImpegno(inizio, fine);
            if (!this._impegni.Remove(imp))
                throw new Exception("Impegno non presente in lista!");
        }


    }

}
