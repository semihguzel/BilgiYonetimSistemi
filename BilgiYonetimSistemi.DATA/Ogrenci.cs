using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{
    public class Ogrenci
    {
        public int ID { get; set; }

        public string Adi { get; set; }

        public string Soyadi { get; set; }

        public string  OgrenciNumarasi { get; set; }

        public DateTime KayitTarihi { get; set; }

        public DateTime MezuniyetTarihi { get; set; }

        public int OgrenimID { get; set; }

        public int EgitimDuzeyiID { get; set; }

        public int BolumID { get; set; }

        public virtual OgrenciBilgi OgrencininBilgisi { get; set; }  
    }
}
