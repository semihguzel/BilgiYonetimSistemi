using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{
   public class FakulteBolumler
    {
        public int FakulteBolumlerID { get; set; }

        public int FakulteID { get; set; }

        public int BolumID { get; set; }

        public virtual Fakulte BolumunFakultesi { get; set; }

        public virtual Bolum FakulteninBolumu { get; set; }

        public virtual List<Ogrenci> Ogrenciler { get; set; }
    }
}
