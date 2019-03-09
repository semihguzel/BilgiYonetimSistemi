using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.BLL.Repository.Abstract
{
    public interface IRepository<T> where T : class
    {
        //Generic olarak kullanılacak olan metodlar, soyut bir biçimde ve generic yapıda tanımlanır.
        IQueryable<T> GetEntity();
        ICollection<T> GetAll();
        T GetById(string id);
        T GetById(int? id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);

    }
}
