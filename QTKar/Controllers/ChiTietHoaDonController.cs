﻿﻿using System;
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

namespace QTKar.Controllers
{
    public class ChiTietHoaDonController : Controller
    {
        private KaraokeDBEntities2 db = new KaraokeDBEntities2();

        public ActionResult GridChiTietHoaDon()
        {
            return View();
        }

        //public PartialViewResult GridChiTietHoaDonPartial(int maHoaDon)
        //{
        //    //List<ChiTietHoaDon> chitiethoadons= db.ChiTietHoaDons.Where(ct => ct.MaHoaDon == maHoaDon).ToList();
        //    //return PartialView(chitiethoadons);

        //  IQueryable<ChiTietHoaDon> chitiethoadons = db.ChiTietHoaDons.Where(ct => ct.MaHoaDon == maHoaDon);
        //    return PartialView(chitiethoadons);

        //}
        public ActionResult ChiTietHoaDons_Read([DataSourceRequest]DataSourceRequest request,int maHoaDon)
        {
            IQueryable<ChiTietHoaDon> chitiethoadons = db.ChiTietHoaDons.Where(ct => ct.MaHoaDon == maHoaDon);
            DataSourceResult result = chitiethoadons.ToDataSourceResult(request, chiTietHoaDon => new
            {
                MaChiTietHoaDon = chiTietHoaDon.MaChiTietHoaDon,
                MaHoaDon=maHoaDon,
                MaHang = chiTietHoaDon.MaHang,
                TenHang = chiTietHoaDon.SanPham.TenHang,
                GiaHang = chiTietHoaDon.SanPham.GiaBan,
                //sanpham =chiTietHoaDon
                SoLuong = chiTietHoaDon.SoLuong,
                ThanhTien = chiTietHoaDon.ThanhTien,
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ChiTietHoaDons_Create([DataSourceRequest]DataSourceRequest request, ChiTietHoaDonViewModel chiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                var entity = new ChiTietHoaDon
                {
                    MaChiTietHoaDon =chiTietHoaDon.MaChiTietHoaDon,
                    MaHoaDon=chiTietHoaDon.MaHoaDon,
                    MaHang =chiTietHoaDon.sanpham.MaHang,
                    SoLuong = chiTietHoaDon.SoLuong,
                    ThanhTien = chiTietHoaDon.sanpham.GiaBan*chiTietHoaDon.SoLuong,
                };

                db.ChiTietHoaDons.Add(entity);
                db.SaveChanges();
                chiTietHoaDon.MaChiTietHoaDon = entity.MaChiTietHoaDon;
            }

            return Json(new[] { chiTietHoaDon }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ChiTietHoaDons_Update([DataSourceRequest]DataSourceRequest request, ChiTietHoaDon chiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                var entity = new ChiTietHoaDon
                {
                    MaChiTietHoaDon = chiTietHoaDon.MaChiTietHoaDon,
                    MaHoaDon = chiTietHoaDon.MaHoaDon,
                    MaHang = chiTietHoaDon.MaHang,                   
                    SoLuong = chiTietHoaDon.SoLuong,
                    ThanhTien = chiTietHoaDon.SanPham.GiaBan*chiTietHoaDon.SoLuong,
                };

                db.ChiTietHoaDons.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { chiTietHoaDon }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ChiTietHoaDons_Destroy([DataSourceRequest]DataSourceRequest request, ChiTietHoaDon chiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                var entity = new ChiTietHoaDon
                {
                    MaChiTietHoaDon = chiTietHoaDon.MaChiTietHoaDon,
                    MaHoaDon = chiTietHoaDon.MaHoaDon,
                    MaHang = chiTietHoaDon.MaHang,                    
                    SoLuong = chiTietHoaDon.SoLuong,
                    //ThanhTien = chiTietHoaDon.ThanhTien,
                };

                db.ChiTietHoaDons.Attach(entity);
                db.ChiTietHoaDons.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { chiTietHoaDon }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
