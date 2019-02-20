using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{
    public class Ders
    {
        public int DersID { get; set; }

        public string DersAdi { get; set; }

        public int DersKredisi { get; set; }

        public string DersKodu { get; set; }

        public virtual List<BolumlerDersler> DersinBolumleri { get; set; } // ders bölüm ilişkisi kuruldu.

        public virtual List<OgrencilerDerslerDonemler> DersinOgrencileri { get; set; } //ders öğrenci ilişkisi kuruldu.

        public virtual List<OgretmenlerDerslerDonemler> DersinOgretmenleri { get; set; } //ders öğretmen ilişkisi kuruldu.

    }
}
