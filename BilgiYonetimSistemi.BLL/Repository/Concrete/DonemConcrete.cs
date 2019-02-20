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
    public class DonemConcrete : IDonem
    {
        public IRepository<Donem> _donemRepository;
        public IUnitOfWork _donemUnitOfWork;
        private DbContext _dbContext;

        public DonemConcrete()
        {
            _dbContext = new Context();
            _donemUnitOfWork = new EFUnitOfWork(_dbContext);
            _donemRepository = _donemUnitOfWork.GetRepository<Donem>();
        }
    }
}
