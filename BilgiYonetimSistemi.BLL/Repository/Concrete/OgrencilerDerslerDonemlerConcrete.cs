using BilgiYonetimSistemi.BLL.Repository.Abstract;
using BilgiYonetimSistemi.DAL;
using BilgiYonetimSistemi.DATA;
using BilgiYonetimSistemi.DATA.DTOs;
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
    public class OgrencilerDerslerDonemlerConcrete : IOgrencilerDerslerDonemler
    {
        public IRepository<OgrencilerDerslerDonemler> _ogrencilerDerslerDonemlerRepository;
        public IUnitOfWork _ogrencilerDerslerDonemlerUnitOfWork;
        private DbContext _dbContext;

        public OgrencilerDerslerDonemlerConcrete()
        {
            _dbContext = new Context();
            _ogrencilerDerslerDonemlerUnitOfWork = new EFUnitOfWork(_dbContext);
            _ogrencilerDerslerDonemlerRepository = _ogrencilerDerslerDonemlerUnitOfWork.GetRepository<OgrencilerDerslerDonemler>();
        }

        public IEnumerable<OgrenciDTO> DersOgrencileri(int id)
        {
            return _ogrencilerDerslerDonemlerRepository.GetEntity().Where(x => x.DersID == id).Select(x => new OgrenciDTO { OgrenciAdi = x.DersinOgrencisi.OgrenciAdi, OgrenciSoyadi = x.DersinOgrencisi.OgrenciSoyadi, OgrenciID = x.OgrenciID, Notlar = x.OgrenciDerslerDonemlerinNotlari }).ToList();
        }

        public IEnumerable<OgrenciDersNotDTO> OgrenciDersVize1(int id)
        {
            var temp = _ogrencilerDerslerDonemlerRepository.GetEntity().Where(x => x.DersID == id).Select(x => new OgrenciDersNotDTO
            {
                OgrenciAdi = x.DersinOgrencisi.OgrenciAdi,
                OgrenciSoyadi = x.DersinOgrencisi.OgrenciSoyadi,
                OgrenciDerslerDonemlerID = x.OgrenciDerslerDonemler,
                OgrenciNo = x.DersinOgrencisi.OgrenciNumarasi,
                AldigiNot = x.OgrenciDerslerDonemlerinNotlari.FirstOrDefault(y => y.NotunSinavi.SinavTipi == "Vize-1").Puan
            }).ToList();
            return temp;
        }

        public IEnumerable<OgrenciDersNotDTO> OgrenciDersVize2(int id)
        {
            var temp = _ogrencilerDerslerDonemlerRepository.GetEntity().Where(x => x.DersID == id).Select(x => new OgrenciDersNotDTO
            {
                OgrenciAdi = x.DersinOgrencisi.OgrenciAdi,
                OgrenciSoyadi = x.DersinOgrencisi.OgrenciSoyadi,
                OgrenciDerslerDonemlerID = x.OgrenciDerslerDonemler,
                OgrenciNo = x.DersinOgrencisi.OgrenciNumarasi,
                AldigiNot = x.OgrenciDerslerDonemlerinNotlari.FirstOrDefault(y => y.NotunSinavi.SinavTipi == "Vize-2").Puan
            }).ToList();
            return temp;
        }

        public IEnumerable<OgrenciDersNotDTO> OgrenciDersFinal(int id)
        {
            var temp = _ogrencilerDerslerDonemlerRepository.GetEntity().Where(x => x.DersID == id).Select(x => new OgrenciDersNotDTO
            {
                OgrenciAdi = x.DersinOgrencisi.OgrenciAdi,
                OgrenciSoyadi = x.DersinOgrencisi.OgrenciSoyadi,
                OgrenciDerslerDonemlerID = x.OgrenciDerslerDonemler,
                OgrenciNo = x.DersinOgrencisi.OgrenciNumarasi,
                AldigiNot = x.OgrenciDerslerDonemlerinNotlari.FirstOrDefault(y => y.NotunSinavi.SinavTipi == "Final").Puan
            }).ToList();
            return temp;
        }
    }
}
