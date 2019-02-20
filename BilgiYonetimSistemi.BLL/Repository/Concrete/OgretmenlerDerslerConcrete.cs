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
    public class OgretmenlerDerslerConcrete : IOgretmenlerDersler
    {
        public IRepository<OgretmenlerDersler> _ogretmenlerDerslerRepository;
        public IUnitOfWork _ogretmenlerDerslerUnitOfWork;
        private DbContext _dbContext;

        public OgretmenlerDerslerConcrete()
        {
            _dbContext = new Context();
            _ogretmenlerDerslerUnitOfWork = new EFUnitOfWork(_dbContext);
            _ogretmenlerDerslerRepository = _ogretmenlerDerslerUnitOfWork.GetRepository<OgretmenlerDersler>();
        }
    }
}
