﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{
   public class OgrencilerDerslerDonemler
    {
        public int OgrenciDerslerDonemler { get; set; }

        public string OgrenciID { get; set; }

        public int DersID { get; set; }

        public int DonemID{ get; set; }
        [DefaultValue(false)]
        public bool NotGirildiMi { get; set; }

        public virtual Ogrenci DersinOgrencisi { get; set; }

        public virtual Ders OgrencininDersi { get; set; }

        public  virtual Donem OgrenciDersinDonemi { get; set; }

        public virtual List<Not> OgrenciDerslerDonemlerinNotlari { get; set; }
    }
}
