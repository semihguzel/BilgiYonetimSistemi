using BilgiYonetimSistemi.DATA.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{

  public  class Ogretmen
    {
           [ForeignKey("Kullanici")]
        public string OgretmenID { get; set; }

        public string OgretmenAdi { get; set; }

        public string OgretmenSoyadi { get; set; }

        public string Unvan { get; set; }

        public DateTime BaslangicTarihi { get; set; }

        public DateTime? AyrilisTarihi { get; set; }

        public string PersonelNumarasi { get; set; }
        [DefaultValue("true")]
        public bool IsActive { get; set; }

        public string Sifre { get; set; }

        public virtual List<OgretmenlerDerslerDonemler> OgretmeninDersleri { get; set; } //öğretmen ders ilişkisi kuruldu.

        public virtual List<OgretmenlerBolumler> OgretmeninBolumleri { get; set; } //öğretmen bölüm ilişkisi kuruldu.

        public virtual OgretmenBilgileri OgretmeninBilgisi { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
