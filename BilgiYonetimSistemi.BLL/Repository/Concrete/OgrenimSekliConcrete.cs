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
    public class OgrenimSekliConcrete : IOgrenimSekli
    {
        public IRepository<OgrenimSekli> _ogrenimSekliRepository;
        public IUnitOfWork _ogrenimSekliUnitOfWork;
        private DbContext _dbContext;

        public OgrenimSekliConcrete()
        {
            _dbContext = new Context();
            _ogrenimSekliUnitOfWork = new EFUnitOfWork(_dbContext);
            _ogrenimSekliRepository = _ogrenimSekliUnitOfWork.GetRepository<OgrenimSekli>();
        }
    }
}
