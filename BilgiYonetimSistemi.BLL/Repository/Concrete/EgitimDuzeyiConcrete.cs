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
    public class EgitimDuzeyiConcrete : IEgitimDuzeyi
    {
        public IRepository<EgitimDuzeyi> _egitimDuzeyiRepository;
        public IUnitOfWork _egitimDuzeyiUnitOfWork;
        private DbContext _dbContext;

        public EgitimDuzeyiConcrete()
        {
            _dbContext = new Context();
            _egitimDuzeyiUnitOfWork = new EFUnitOfWork(_dbContext);
            _egitimDuzeyiRepository = _egitimDuzeyiUnitOfWork.GetRepository<EgitimDuzeyi>();
        }
    }
}
