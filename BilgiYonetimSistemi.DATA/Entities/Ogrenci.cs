﻿using BilgiYonetimSistemi.DATA.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{
    public class Ogrenci
    {
        [ForeignKey("Kullanici")]
        public string OgrenciID { get; set; }

        public string OgrenciAdi { get; set; }

        public string OgrenciSoyadi { get; set; }

        public string OgrenciNumarasi { get; set; }

        public DateTime KayitTarihi { get; set; }

        public DateTime MezuniyetTarihi { get; set; }

        public int FakulteBolumlerID { get; set; }

        public virtual OgrenciBilgileri OgrenciBilgisi { get; set; }

        public virtual List<OgrencilerDerslerDonemler> OgrencininDersleri { get; set; } //öğrenci ders ilişkisi kuruldu.

        public virtual FakulteBolumler OgrencininFakulteBolumu { get; set; } //öğrenci bölüm ilişkisi kuruldu.

        public int OgrenimSekliID { get; set; }

        public virtual OgrenimSekli OgrencininOgrenimSekli { get; set; }

        public int EgitimDuzeyiID { get; set; }

        public virtual EgitimDuzeyi OgrencininEgitimDuzeyi { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
