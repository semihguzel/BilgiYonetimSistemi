using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgiYonetimSistemi.DATA;


namespace BilgiYonetimSistemi.DATA
{
   public class Donem
    {
        public int DonemID { get; set; }

        public DateTime DonemYili { get; set; }

        public virtual List<OgrencilerDerslerDonemler> DoneminOgrencilerDersleri { get; set; }

        public virtual List<OgretmenlerDerslerDonemler> DoneminOgretmenlerDersleri { get; set; }
    }
}
