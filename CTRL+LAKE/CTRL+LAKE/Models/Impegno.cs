using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTRL_LAKE.Models
{
     public class Impegno
    {

        private DateTime _inizio;
        private DateTime _fine;
        private string _id_user;

        public virtual DateTime Inizio { get => _inizio; set => _inizio = value; }
        public virtual DateTime Fine { get => _fine; set => _fine = value; }
        public virtual string Id_user { get => _id_user; set => _id_user = value; }

        public Impegno(DateTime inizio, DateTime fine, string id_user)
        {
            if (inizio.CompareTo(fine) >= 0)
                throw new Exception("Impossibile creare impegno: intervallo non valido");
            if(inizio.TimeOfDay.CompareTo(new TimeSpan(9,0,0))<0
                || fine.TimeOfDay.CompareTo(new TimeSpan(19,0,0))>0)
                throw new Exception("Impossibile creare impegno: orari non possibili");
            if (!inizio.Date.Equals(fine.Date))
                throw new Exception("Impossibile creare impegno: non ammessi inizio e fine in due giorni distinti");
            this.Inizio = inizio;
            this.Fine = fine;
            this._id_user = id_user;
        }

        public virtual bool OverlapsWith(Impegno i2)
        {
            DateTime max_inizio = DateTime.Compare(this.Inizio, i2.Inizio) >= 0 ? this.Inizio : i2.Inizio;
            DateTime min_fine = DateTime.Compare(this.Fine, i2.Fine) <= 0 ? this.Fine : i2.Fine;
            if (DateTime.Compare(max_inizio, min_fine) < 0)
                return true;
            else
                return false;
        }

        public override bool Equals(Object o)
        {
            Impegno i2 = (Impegno)o;
            bool result = ( this.Inizio.CompareTo(i2.Inizio) == 0
                && this.Fine.CompareTo(i2.Fine) == 0 
                && this._id_user.Equals(i2));
            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
