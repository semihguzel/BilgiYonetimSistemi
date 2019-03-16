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
    public class DersConcrete : IDers
    {
        public IRepository<Ders> _dersRepository;
        public IUnitOfWork _derslerUnitOfWork;
        private DbContext _dbContext;

        public DersConcrete()
        {
            _dbContext = new Context();
            _derslerUnitOfWork = new EFUnitOfWork(_dbContext);
            _dersRepository = _derslerUnitOfWork.GetRepository<Ders>();
        }
        public Ders GetByLessons(string code)
        {
            return _dersRepository.GetEntity().FirstOrDefault(x => x.DersKodu == code);
        }
    }
}
