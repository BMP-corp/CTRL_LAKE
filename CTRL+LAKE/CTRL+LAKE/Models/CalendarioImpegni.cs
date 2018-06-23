using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Web;

namespace CTRL_LAKE.Models
{
    public class CalendarioImpegni
    {
        private List<Impegno> _impegni;
        private string _id_user;

        public CalendarioImpegni(string id_user)
        {
            _id_user = id_user;
            Impegni = new List<Impegno>();
        }


        public string Id_user { get => _id_user; set => _id_user = value; }
        public List<Impegno> Impegni { get => _impegni; set => _impegni = value; }

        public Impegno GetImpegno (DateTime inizio, DateTime fine)
        {
            Impegno res = null, i2 = null;
            try
            {
                i2 = new Impegno(inizio, fine, Id_user);
            } catch (Exception e) { throw e; }

            
            foreach (Impegno i in this.Impegni)
                if (i.Equals(i2))
                {
                    res = i; break;
                }
            return res;
        }

        public void Aggiungi(DateTime inizio, DateTime fine)
        {
            Impegno imp = null;
            try
            {
                imp = new Impegno(inizio, fine, Id_user);
            } catch (Exception e) { throw e; }
            bool overlaps = false;
            foreach (Impegno i in this.Impegni)
                if (i.OverlapsWith(imp))
                {
                    overlaps = true; break;
                }
            if (!overlaps)
                this.Impegni.Add(imp);
            else
                throw new Exception("L'impegno richiesto si sovrappone con uno già esistente!");
        }

        public void Rimuovi(DateTime inizio, DateTime fine)
        {
            Impegno imp = null;
            imp = this.GetImpegno(inizio, fine);
            if (!this.Impegni.Remove(imp))
                throw new Exception("Impegno non presente in lista!");
        }

        public int ProssimiImpegni()    // restituisce il numero degli impegni ancora da svolgere
        {
            int result = 0;
            foreach (Impegno i in this.Impegni)
                if (DateTime.Now.CompareTo(i.Inizio) <= 0)
                    result++;
            return result;
        }

    }

}
