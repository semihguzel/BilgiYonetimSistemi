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
    public class OgretmenConcrete : IOgretmen
    {
        public IRepository<Ogretmen> _ogretmenRepository;
        public IUnitOfWork _ogretmenUnitOfWork;
        private DbContext _dbContext;

        public OgretmenConcrete()
        {
            _dbContext = new Context();
            _ogretmenUnitOfWork = new EFUnitOfWork(_dbContext);
            _ogretmenRepository = _ogretmenUnitOfWork.GetRepository<Ogretmen>();
        }
    }
}
