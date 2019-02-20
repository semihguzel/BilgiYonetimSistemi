using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{
   public class OgrencilerDersler
    {
        public int OgrencilerDerslerID { get; set; }

        public int OgrenciID { get; set; }

        public int DersID { get; set; }

        public virtual Ogrenci DersinOgrencisi { get; set; }

        public virtual Ders OgrencininDersi { get; set; }

    }
}
