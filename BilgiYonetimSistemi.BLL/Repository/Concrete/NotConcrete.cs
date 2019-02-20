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
    public class NotConcrete : INot
    {
        public IRepository<Not> _notRepository;
        public IUnitOfWork _notUnitOfWork;
        private DbContext _dbContext;

        public NotConcrete()
        {
            _dbContext = new Context();
            _notUnitOfWork = new EFUnitOfWork(_dbContext);
            _notRepository = _notUnitOfWork.GetRepository<Not>();
        }
    }
}
