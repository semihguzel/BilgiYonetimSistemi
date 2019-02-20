using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{
    public class Bolum
    {
        public int BolumID { get; set; }

        public string BolumAdi { get; set; }

        public string EgitimDili { get; set; }

        public virtual List<BolumlerDersler> BolumDersleri { get; set; } // bölüm ders ilişkisi kuruldu.

        public virtual List<FakulteBolumler> BolumunFakulteleri { get; set; } //bölüm fakülte ilişkisi kuruldu.

        public virtual List<OgrencilerBolumler> BolumunOgrencileri { get; set; } // bölüm ögrenci ilişkisi kuruldu.

        public virtual List<OgretmenlerBolumler> BolumunOgretmenleri { get; set; } //bölüm öğretmen ilişkisi kuruldu.

    }
}
