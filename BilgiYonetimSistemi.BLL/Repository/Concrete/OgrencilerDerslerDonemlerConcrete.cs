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
    public class OgrencilerDerslerDonemlerConcrete : IOgrencilerDerslerDonemler
    {
        public IRepository<OgrencilerDerslerDonemler> _ogrencilerDerslerDonemlerRepository;
        public IUnitOfWork _ogrencilerDerslerDonemlerUnitOfWork;
        private DbContext _dbContext;

        public OgrencilerDerslerDonemlerConcrete()
        {
            _dbContext = new Context();
            _ogrencilerDerslerDonemlerUnitOfWork = new EFUnitOfWork(_dbContext);
            _ogrencilerDerslerDonemlerRepository = _ogrencilerDerslerDonemlerUnitOfWork.GetRepository<OgrencilerDerslerDonemler>();
        }
    }
}
