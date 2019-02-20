using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{
    public class BolumlerDersler
    {
        public int BolumlerDerslerID { get; set; }

        public int BolumID { get; set; }

        public int DersID { get; set; }

        public virtual Bolum DersinBolumu { get; set; }

        public virtual Ders BolumunDersi { get; set; }



    }
}
