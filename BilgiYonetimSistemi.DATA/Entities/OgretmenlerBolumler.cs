using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{
   public class OgretmenlerBolumler
    {
        public int OgretmenlerBolumlerID { get; set; }

        public int OgretmenID { get; set; }

        public int BolumID { get; set; }

        public virtual Ogretmen BolumunOgretmeni { get; set; }

        public virtual Bolum OgretmeninBolumu { get; set; }
    }
}
