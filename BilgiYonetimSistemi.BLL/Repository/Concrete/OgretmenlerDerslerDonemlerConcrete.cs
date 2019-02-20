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
    public class OgretmenlerDerslerDonemlerConcrete : IOgretmenlerDerslerDonemler
    {
        public IRepository<OgretmenlerDerslerDonemler> _ogretmenlerDerslerDonemlerRepository;
        public IUnitOfWork _ogretmenlerDerslerDonemlerUnitOfWork;
        private DbContext _dbContext;

        public OgretmenlerDerslerDonemlerConcrete()
        {
            _dbContext = new Context();
            _ogretmenlerDerslerDonemlerUnitOfWork = new EFUnitOfWork(_dbContext);
            _ogretmenlerDerslerDonemlerRepository = _ogretmenlerDerslerDonemlerUnitOfWork.GetRepository<OgretmenlerDerslerDonemler>();
        }
    }
}
