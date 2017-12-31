using MvcPortal.Admin.Class;
using MvcPortal.Admin.CustomFilter;
using MvcPortal.Core.Infrastracture;
using MvcPortal.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPortal.Admin.Controllers
{
    public class KategoriController : Controller
    {
        #region Kategori

        IKategoriRepository _kategoriRepository;
        public KategoriController(IKategoriRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
        }
        
        #endregion

        public ActionResult Index()
        {
            return View(_kategoriRepository.GetAll());
        }

        #region Kategori Ekle
        //Get Create
        [HttpGet]
        public ActionResult Create()
        {
            UstKategoriList();
            return View();
           
        }

        [HttpPost]//Create Post
        public JsonResult Create(Kategori kategori)
        {
            try
            {
                _kategoriRepository.Insert(kategori);
                _kategoriRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Kategori Ekleme İşlemi Başarılı" });
            }
            catch (Exception ex)
            {
                //Loglama Yaptırılabilir
                return Json(new ResultJson { Success = false, Message = "Kategori Eklerken Hata Oluştu"});
            }

        }
        #region ÜstKategori Listeleme

        public void UstKategoriList()
        {
            var UstKategori = _kategoriRepository.GetMany(x => x.ParentID == 0).ToList();
            ViewBag.Kategori = UstKategori;
        }

        #endregion


        #endregion

        #region Kategori Düzenle
        [HttpGet]
        [LoginFilter]
        public ActionResult Edit(int id)
        {
            Kategori kat = _kategoriRepository.GetById(id);
            if (kat==null)
            {
                throw new Exception("Kategori Bulunamadı");
            }
            UstKategoriList();
            return View(kat);
        }

        [HttpPost]
        [LoginFilter]
        public JsonResult Edit(Kategori kategori)
        {
            if (ModelState.IsValid)
            {

                Kategori guncellenecek = _kategoriRepository.GetById(kategori.ID);
                guncellenecek.KategoriAdi = kategori.KategoriAdi;
                guncellenecek.Aktifmi = kategori.Aktifmi;
                guncellenecek.ParentID = kategori.ParentID;
                guncellenecek.URL = kategori.URL;
           
                _kategoriRepository.Save();

                return Json(new ResultJson { Success = true, Message = "Düzenleme İşlemi Başarılı" });
            }

            return Json(new ResultJson { Success = false, Message = "İşlem Başarısız" });
        }

        #endregion

        #region Kategori Sil
        [LoginFilter]
        public JsonResult Delete(int id)
        {
            Kategori kat = _kategoriRepository.GetById(id);
            if (kat==null)
            {
                return Json(new ResultJson { Success = false, Message = "Kategori Bulunamadı" });
            }
            _kategoriRepository.Delete(id);
            _kategoriRepository.Save();
            return Json(new ResultJson { Success = true, Message = "Kategori Silme İşlemi Başarılı" });
        }

        #endregion


    }
}