using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA.Entities
{
    public class Yonetici
    {
        public int YoneticiID { get; set; }
        public string TC { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }

        public string UserID { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
