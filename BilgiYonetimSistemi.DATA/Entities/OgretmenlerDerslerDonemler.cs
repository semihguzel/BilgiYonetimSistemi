using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{
   public class OgretmenlerDerslerDonemler
    {
        public int OgretmenlerDerslerID { get; set; }

        public int OgretmenID { get; set; }

        public int DersID { get; set; }

        public int DonemID { get; set; }

        public virtual Ogretmen DersinOgretmeni { get; set; }

        public virtual Ders OgretmeninDersi { get; set; }

        public virtual Donem OgretmenDersinDonemi { get; set; }

    }
}
