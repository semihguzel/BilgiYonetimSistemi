using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{
    class OgrenciBilgi
    {
        public int OgrenciID { get; set; }

        public string Adres { get; set; }

        public string Telefon { get; set; }

        public string TcNo { get; set; }

        public string Mail { get; set; }

        public string Fotograf { get; set; }

        public string Sifre { get; set; }

        public virtual Ogrenci BilgininOgrencisi { get; set; }
    }
}
