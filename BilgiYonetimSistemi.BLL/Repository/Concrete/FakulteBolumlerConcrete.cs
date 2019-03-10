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
    public class FakulteBolumlerConcrete : IFakulteBolumler
    {
        public IRepository<FakulteBolumler> _fakulteBolumlerRepository;
        public IUnitOfWork _fakulteBolumlerUnitOfWork;
        private DbContext _dbContext;

        public FakulteBolumlerConcrete()
        {
            _dbContext = new Context();
            _fakulteBolumlerUnitOfWork = new EFUnitOfWork(_dbContext);
            _fakulteBolumlerRepository = _fakulteBolumlerUnitOfWork.GetRepository<FakulteBolumler>();
        }

        public FakulteBolumler GetByFacultyDepartment(int fakulteid, Bolum bolum)
        {
            return _fakulteBolumlerRepository.GetEntity().FirstOrDefault(x => x.FakulteID == fakulteid && x.FakulteninBolumu.BolumAdi == bolum.BolumAdi && x.FakulteninBolumu.EgitimDili == bolum.EgitimDili);
        }
    }
}
