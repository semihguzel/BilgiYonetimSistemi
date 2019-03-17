using RepositoryPattern.BLL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.BLL.Repository.Concrete
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private bool disposed = false;

        public EFUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            //Instance alindigi zaman hangi entity verildi ise o entity icin generic yapilar ayarlanir ve ona gore repository geri dondurulur.
            return new EFRepository<T>(_dbContext);
        }

        public int SaveChanges()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void Dispose()
        {
            //IDisposible'dan kalitilan IUnitOfWork interface'sinden gelen Dispose metodu, islem yapildiktan sonra, olusturulan context'i ram'den siler. Genelde veritabaninda crud islemleri yapildiktan sonra kullanilir.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
