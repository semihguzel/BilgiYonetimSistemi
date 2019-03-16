using BilgiYonetimSistemi.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.BLL.Repository.Abstract
{
    public interface IDers
    {
        Ders GetByLessons(string code);
    }
}
