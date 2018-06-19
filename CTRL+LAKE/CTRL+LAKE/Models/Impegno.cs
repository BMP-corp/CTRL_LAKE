using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCtrlLake
{
     public class Impegno
    {

        private DateTime _inizio { get; set; }
        private DateTime _fine { get; set; }

        public Impegno(DateTime inizio, DateTime fine)
        {
            if (inizio.CompareTo(fine) >= 0)
                throw new Exception("Impossibile creare impegno: intervallo non valido");
            if(inizio.TimeOfDay.CompareTo(new TimeSpan(9,0,0))<0
                || fine.TimeOfDay.CompareTo(new TimeSpan(19,0,0))>0)
                throw new Exception("Impossibile creare impegno: orari non possibili");
            if (!inizio.Date.Equals(fine.Date))
                throw new Exception("Impossibile creare impegno: non ammessi inizio e fine in due giorni distinti");
            this._inizio = inizio;
            this._fine = fine;
        }

        public DateTime Inizio
        {
            get { return this._inizio; }
            //set { this._inizio = value; }
        }
        public DateTime Fine
        {
            get { return this._fine; }
            //set { this._fine = value; }
        }

        public bool OverlapsWith(Impegno i2)
        {
            DateTime max_inizio = DateTime.Compare(this._inizio, i2._inizio) >= 0 ? this._inizio : i2._inizio;
            DateTime min_fine = DateTime.Compare(this._fine, i2._fine) <= 0 ? this._fine : i2._fine;
            if (DateTime.Compare(max_inizio, min_fine) < 0)
                return true;
            else
                return false;
        }

        public bool Equals(Impegno i2)
        {
            bool result = ( this._inizio.CompareTo(i2._inizio) == 0
                && this._fine.CompareTo(i2._fine) == 0 );
            return result;
        }
    }
}
