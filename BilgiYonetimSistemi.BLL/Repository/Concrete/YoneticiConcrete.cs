using BilgiYonetimSistemi.BLL.Repository.Abstract;
using BilgiYonetimSistemi.DAL;
using BilgiYonetimSistemi.DATA.Entities;
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
    public class YoneticiConcrete : IYonetici
    {
        public IRepository<Yonetici> _yoneticiRepository;
        public IUnitOfWork _yoneticiUnitOfWork;
        private DbContext _dbContext;

        public YoneticiConcrete()
        {
            _dbContext = new Context();
            _yoneticiUnitOfWork = new EFUnitOfWork(_dbContext);
            _yoneticiRepository = _yoneticiUnitOfWork.GetRepository<Yonetici>();
        }
    }
}
