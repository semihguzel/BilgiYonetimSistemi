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
    public class FakulteConcrete : IFakulte
    {
        public IRepository<Fakulte> _fakulteRepository;
        public IUnitOfWork _fakulteUnitOfWork;
        private DbContext _dbContext;

        public FakulteConcrete()
        {
            _dbContext = new Context();
            _fakulteUnitOfWork = new EFUnitOfWork(_dbContext);
            _fakulteRepository = _fakulteUnitOfWork.GetRepository<Fakulte>();
        }

        public Fakulte GetByName(string name)
        {
            return _fakulteRepository.GetEntity().FirstOrDefault(x => x.FakulteAdi == name);
        }
    }
}
