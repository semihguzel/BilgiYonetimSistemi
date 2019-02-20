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
    public class BolumDerslerConcrete : IBolumDersler
    {
        public IRepository<BolumlerDersler> _bolumDerslerRepository;
        public IUnitOfWork _bolumDerslerUnitOfWork;
        private DbContext _dbContext;

        public BolumDerslerConcrete()
        {
            _dbContext = new Context();
            _bolumDerslerUnitOfWork = new EFUnitOfWork(_dbContext);
            _bolumDerslerRepository = _bolumDerslerUnitOfWork.GetRepository<BolumlerDersler>();
        }
    }
}
