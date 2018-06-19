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

        public DateTime Inizio { get => _inizio; set => _inizio = value; }
        public DateTime Fine { get => _fine; set => _fine = value; }

        public Impegno(DateTime inizio, DateTime fine)
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
        }

        public bool OverlapsWith(Impegno i2)
        {
            DateTime max_inizio = DateTime.Compare(this.Inizio, i2.Inizio) >= 0 ? this.Inizio : i2.Inizio;
            DateTime min_fine = DateTime.Compare(this.Fine, i2.Fine) <= 0 ? this.Fine : i2.Fine;
            if (DateTime.Compare(max_inizio, min_fine) < 0)
                return true;
            else
                return false;
        }

        public bool Equals(Impegno i2)
        {
            bool result = ( this.Inizio.CompareTo(i2.Inizio) == 0
                && this.Fine.CompareTo(i2.Fine) == 0 );
            return result;
        }
    }
}
