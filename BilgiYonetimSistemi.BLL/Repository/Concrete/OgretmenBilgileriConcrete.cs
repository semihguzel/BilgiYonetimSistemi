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
    public class OgretmenBilgileriConcrete : IOgretmenBilgileri
    {
        public IRepository<OgretmenBilgileri> _ogretmenBilgileriRepository;
        public IUnitOfWork _ogretmenBilgileriUnitOfWork;
        private DbContext _dbContext;

        public OgretmenBilgileriConcrete()
        {
            _dbContext = new Context();
            _ogretmenBilgileriUnitOfWork = new EFUnitOfWork(_dbContext);
            _ogretmenBilgileriRepository = _ogretmenBilgileriUnitOfWork.GetRepository<OgretmenBilgileri>();
        }
       
    }
}
