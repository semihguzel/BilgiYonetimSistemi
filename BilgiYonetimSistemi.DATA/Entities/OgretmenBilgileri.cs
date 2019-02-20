using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{
  public  class OgretmenBilgileri
    {
        public int OgretmenID { get; set; }

        public string TCNo { get; set; }

        public string OgretmenMail { get; set; }

        public string Fotograf { get; set; }

        public virtual Ogretmen BilgininOgretmeni { get; set; }

    }
}
