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
    public class OgretmenlerBolumlerConcrete : IOgretmenlerBolumler
    {
        public IRepository<OgretmenlerBolumler> _ogretmenlerBolumlerRepository;
        public IUnitOfWork _ogretmenlerBolumlerUnitOfWork;
        private DbContext _dbContext;

        public OgretmenlerBolumlerConcrete()
        {
            _dbContext = new Context();
            _ogretmenlerBolumlerUnitOfWork = new EFUnitOfWork(_dbContext);
            _ogretmenlerBolumlerRepository = _ogretmenlerBolumlerUnitOfWork.GetRepository<OgretmenlerBolumler>();
        }
    }
}
