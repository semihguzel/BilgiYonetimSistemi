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
    public class OgrenciConcrete : IOgrenci
    {
        public IRepository<Ogrenci> _ogrenciRepository;
        public IUnitOfWork _ogrenciUnitOfWork;
        private DbContext _dbContext;

        public OgrenciConcrete()
        {
            _dbContext = new Context();
            _ogrenciUnitOfWork = new EFUnitOfWork(_dbContext);
            _ogrenciRepository = _ogrenciUnitOfWork.GetRepository<Ogrenci>();
        }
    }
}
