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
    public class OgrenciBilgileriConcrete : IOgrenciBilgileri
    {
        public IRepository<OgrenciBilgileri> _ogrenciBilgileriRepository;
        public IUnitOfWork _ogrenciBilgileriUnitOfWork;
        private DbContext _dbContext;

        public OgrenciBilgileriConcrete()
        {
            _dbContext = new Context();
            _ogrenciBilgileriUnitOfWork = new EFUnitOfWork(_dbContext);
            _ogrenciBilgileriRepository = _ogrenciBilgileriUnitOfWork.GetRepository<OgrenciBilgileri>();
        }
    }
}
