using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.BLL.Repository.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        //Bu kisimda hangi entity istenirse onun metodlari kullanilabilir haline getirilmis sekilde geri dondurur.
        IRepository<T> GetRepository<T>() where T : class;

        int SaveChanges();
    }
}
