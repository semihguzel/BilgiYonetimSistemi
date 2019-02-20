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
    public class OgrencilerDerslerConcrete : IOgrencilerDersler
    {
        public IRepository<OgrencilerDersler> _ogrencilerDerslerRepository;
        public IUnitOfWork _ogrencilerDerslerUnitOfWork;
        private DbContext _dbContext;

        public OgrencilerDerslerConcrete()
        {
            _dbContext = new Context();
            _ogrencilerDerslerUnitOfWork = new EFUnitOfWork(_dbContext);
            _ogrencilerDerslerRepository = _ogrencilerDerslerUnitOfWork.GetRepository<OgrencilerDersler>();
        }
    }
}
