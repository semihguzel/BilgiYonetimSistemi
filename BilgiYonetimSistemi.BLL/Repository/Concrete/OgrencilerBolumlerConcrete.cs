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
    public class OgrencilerBolumlerConcrete : IOgrencilerBolumler
    {
        public IRepository<OgrencilerBolumler> _ogrencilerBolumlerRepository;
        public IUnitOfWork _ogrencilerBolumlerUnitOfWork;
        private DbContext _dbContext;

        public OgrencilerBolumlerConcrete()
        {
            _dbContext = new Context();
            _ogrencilerBolumlerUnitOfWork = new EFUnitOfWork(_dbContext);
            _ogrencilerBolumlerRepository = _ogrencilerBolumlerUnitOfWork.GetRepository<OgrencilerBolumler>();
        }
    }
}
