using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using QTKar.Models;

namespace QTKar.Admin
{
    public class SanPhamController : Controller
    {
        private KaraokeDBEntities2 db = new KaraokeDBEntities2();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ToolbarTemplate_Nhoms()
        {

            //var nhoms = new SelectList(db.Nhoms, "MaNhom", "TenNhom");
                        var nhoms = db.Nhoms
            .Select(c => new NhomViewModel
            {
                MaNhom = c.MaNhom,
                TenNhom = c.TenNhom
            })
            .OrderBy(e => e.MaNhom);
            return Json(nhoms, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SanPhams_Read([DataSourceRequest]DataSourceRequest request)
        {
            //ViewData["nhoms"] =
            //        db.Nhoms
            //        .Select(e => new Nhom
            //        {
            //            MaNhom = e.MaNhom,
            //            TenNhom = e.TenNhom
            //        })
            //        .OrderBy(e => e.MaNhom);
            ViewData["MaNhom"] = new SelectList(db.Nhoms, "MaNhom", "TenNhom");
            IQueryable<SanPham> sanphams = db.SanPhams;
            DataSourceResult result = sanphams.ToDataSourceResult(request, sanPham => new
            {
                MaHang = sanPham.MaHang,
                MaNhom = sanPham.MaNhom,
                TenHang = sanPham.TenHang,
                GiaBan = sanPham.GiaBan,
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SanPhams_Create([DataSourceRequest]DataSourceRequest request, SanPham sanPham)
        {


            if (ModelState.IsValid)
            {
                var entity = new SanPham
                {
                    MaHang = sanPham.MaHang,
                    MaNhom = sanPham.MaNhom,
                    TenHang = sanPham.TenHang,
                    GiaBan = sanPham.GiaBan,
                };

                db.SanPhams.Add(entity);
                db.SaveChanges();
                sanPham.MaHang = entity.MaHang;
            }
            ViewBag.MaNhom = new SelectList(db.Nhoms, "MaNhom", "TenNhom", sanPham.MaNhom);
            return Json(new[] { sanPham }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SanPhams_Update([DataSourceRequest]DataSourceRequest request, SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                var entity = new SanPham
                {
                    MaHang = sanPham.MaHang,
                    MaNhom = sanPham.MaNhom,
                    TenHang = sanPham.TenHang,
                    GiaBan = sanPham.GiaBan,
                };

                db.SanPhams.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { sanPham }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SanPhams_Destroy([DataSourceRequest]DataSourceRequest request, SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                var entity = new SanPham
                {
                    MaHang = sanPham.MaHang,
                    MaNhom = sanPham.MaNhom,
                    TenHang = sanPham.TenHang,
                    GiaBan = sanPham.GiaBan,
                };

                db.SanPhams.Attach(entity);
                db.SanPhams.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { sanPham }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
