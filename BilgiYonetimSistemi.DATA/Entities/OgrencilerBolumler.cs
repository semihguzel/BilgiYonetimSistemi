using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{
   public class OgrencilerBolumler
    {
        public int OgrencilerBolumlerID { get; set; }

        public int OgrenciID { get; set; }

        public int BolumID { get; set; }

        public virtual Ogrenci BolumunOgrencisi { get; set; }

        public virtual Bolum OgrencininBolumu { get; set; }

    }
}
