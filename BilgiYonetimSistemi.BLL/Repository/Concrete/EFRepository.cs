using RepositoryPattern.BLL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.BLL.Repository.Concrete
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        //Instance alindigi zaman yollanan Context bilgisine gore (Category, Product gibi entity'ler) repository olusturulur. Her entityde kullanilan yapilar bu class icerisinde generic olarak tanimlanir, hangi class yollanirsa tanimlanan yapilar o class icin yapilmasi belirlenen isleri yapar. Bu sayede her entity icerisinde ayni kod satirlarinin yazilmasi onlenmis olur. Ote yandan test islemlerinde de bir hata bulundugunda sadece bu class icerisinde yapilacak degisiklik, bu yapilari kullanan tum kod satirlarinda da degisikligi saglar.
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public EFRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            //Burada DbContext genel bir sinif oldugu icin Set<>() metodunda '<>' icerisine yazilan kisim butun metodlarin hangi entity icin calisacagini belirler.
            _dbSet = _dbContext.Set<T>();
        }


        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            _dbSet.Remove(GetById(id));
        }               

        public IQueryable<T> GetEntity()
        {
            return _dbSet;
        }

        public ICollection<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(string id)
        {
            return _dbSet.Find(id);
        }

        public T GetById(int? id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
