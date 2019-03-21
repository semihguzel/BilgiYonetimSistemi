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
    public class bolumdersdonemlerConcrete : Ibolumdersdonemler
    {
        public IRepository<BolumlerDersler> _bolumdersdonemlerRepository;
        public IUnitOfWork _bolumdersdonemlerUnitOfWork;
        private DbContext _dbContext;

        public bolumdersdonemlerConcrete()
        {
            _dbContext = new Context();
            _bolumdersdonemlerUnitOfWork = new EFUnitOfWork(_dbContext);
            _bolumdersdonemlerRepository = _bolumdersdonemlerUnitOfWork.GetRepository<BolumlerDersler>();
        }
        public BolumlerDersler GetByDepartmentLesson(int bolumId, string ders)
        {
            return _bolumdersdonemlerRepository.GetEntity().FirstOrDefault(x => x.BolumID == bolumId && x.BolumunDersi.DersKodu == ders);
        }

        public List<BolumlerDersler> GetByName(int id)
        {
            return _bolumdersdonemlerRepository.GetEntity().Where(x => x.BolumID == id).ToList();
        }
    }
}
