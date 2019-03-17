using BilgiYonetimSistemi.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.BLL.Repository.Abstract
{
    public interface IBolum
    {
        Bolum GetByNameLanguage(string name, string language);
        List<Bolum> GetByName(string name);
        List<Bolum> GetByLanguage(string language);
    }
}
