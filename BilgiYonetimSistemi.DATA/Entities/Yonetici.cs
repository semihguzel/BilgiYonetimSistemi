using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA.Entities
{
    public class Yonetici
    {
        [ForeignKey("Kullanici")]
        public string YoneticiID { get; set; }
        public string TC { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Fotograf { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
