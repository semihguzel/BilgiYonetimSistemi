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
    public class BolumConcrete : IBolum
    {
        public IRepository<Bolum> _bolumRepository;
        public IUnitOfWork _bolumUnitOfWork;
        private DbContext _dbContext;

        public BolumConcrete()
        {
            _dbContext = new Context();
            _bolumUnitOfWork = new EFUnitOfWork(_dbContext);
            _bolumRepository = _bolumUnitOfWork.GetRepository<Bolum>();
        }

        public List<Bolum> GetByLanguage(string language)
        {
            return _bolumRepository.GetEntity().Where(x => x.EgitimDili == language.ToLower()).ToList();
        }

        public List<Bolum> GetByName(string name)
        {
            return _bolumRepository.GetEntity().Where(x => x.BolumAdi == name).ToList();
        }

        public Bolum GetByNameLanguage(string name, string language)
        {
            return _bolumRepository.GetEntity().FirstOrDefault(x => x.BolumAdi == name && x.EgitimDili == language);
        }
    }
}
