using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA.DTOs
{
    public class OgrenciDersDTO
    {
        public int DersID { get; set; }
        public string DersAdi { get; set; }
        public string DersKodu { get; set; }
        public int DersKredisi { get; set; }
        public short? Vize1 { get; set; }
        public short? Vize2 { get; set; }
        public short? Final { get; set; }
        public short? But { get; set; }
    }
}
