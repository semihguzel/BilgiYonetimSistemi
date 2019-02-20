using BilgiYonetimSistemi.BLL.Repository.Abstract;
using BilgiYonetimSistemi.DAL;
using BilgiYonetimSistemi.DATA;
using RepositoryPattern.BLL.Repository.Abstract;
using RepositoryPattern.BLL.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.BLL.Repository.Concrete
{
    public class SinavConcrete : ISinav
    {
        public IRepository<Sinav> _sinavRepository;
        public IUnitOfWork _sinavUnitOfWork;
        private DbContext _dbContext;

        public SinavConcrete()
        {
            _dbContext = new Context();
            _sinavUnitOfWork = new EFUnitOfWork(_dbContext);
            _sinavRepository = _sinavUnitOfWork.GetRepository<Sinav>();
        }
    }
}
