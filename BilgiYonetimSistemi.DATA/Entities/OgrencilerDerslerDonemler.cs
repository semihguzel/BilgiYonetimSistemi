using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{
   public class OgrencilerDerslerDonemler
    {
        public int OgrencilerDerslerID { get; set; }

        public int OgrenciID { get; set; }

        public int DersID { get; set; }

        public int DonemID{ get; set; }

        public int NotID { get; set; }

        public virtual Ogrenci DersinOgrencisi { get; set; }

        public virtual Ders OgrencininDersi { get; set; }

        public  virtual Donem OgrenciDersinDonemi { get; set; }
    
        public virtual Not OgrenciDersinNotu { get; set; } //bir notun birden çok öğrenci dersi olabilir. bir öğrencidersin bir notu olabilir. 
        
    }
}
