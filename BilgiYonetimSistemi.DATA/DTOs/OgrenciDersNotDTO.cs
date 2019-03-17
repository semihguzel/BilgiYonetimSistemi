using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA.DTOs
{
    public class OgrenciDersNotDTO
    {
        public int OgrenciDerslerDonemlerID { get; set; }
        private short? aldigiNot;

        public short? AldigiNot
        {
            get
            {
                if (aldigiNot == null)
                {
                    return 0;
                }
                else
                {
                    return aldigiNot;
                }
            }
            set { aldigiNot = value; }
        }

        public string OgrenciAdi { get; set; }
        public string OgrenciSoyadi { get; set; }
        public string OgrenciNo { get; set; }
        public int SinavID { get; set; }
    }
}
