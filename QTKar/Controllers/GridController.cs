﻿using System;
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
    public class GridController : Controller
    {
        private KaraokeDBEntities2 db = new KaraokeDBEntities2();

        public PartialViewResult GridChiTietHoaDonPartial(int maHoaDon)
        {
            List<ChiTietHoaDonViewModel> chitietvm = new List<ChiTietHoaDonViewModel>();

            var chitiethoadon=db.ChiTietHoaDons.Where(ct => ct.MaHoaDon == maHoaDon);            
            foreach (var item in chitiethoadon)
            {
                ChiTietHoaDonViewModel ctvm = new ChiTietHoaDonViewModel();
                ctvm.MaHoaDon = item.MaHoaDon;
                ctvm.SanPham = item.SanPham;
                ctvm.SoLuong = item.SoLuong;
                ctvm.ThanhTien = item.ThanhTien;
                chitietvm.Add(ctvm);
            }

            return PartialView(chitietvm);
        }
        public ActionResult EditingPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            ProductService ps = new ProductService(db);
            return Json(ps.Read(ViewBag.mahoadon).ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Create([DataSourceRequest] DataSourceRequest request, ChiTietHoaDonViewModel product)
        {
            ProductService ps = new ProductService(db);
            if (product != null && ModelState.IsValid)
            {
                ps.Create(product);
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Update([DataSourceRequest] DataSourceRequest request, ChiTietHoaDonViewModel product)
        {
            ProductService ps = new ProductService(db);
            if (product != null && ModelState.IsValid)
            {
                ps.Update(product);
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Destroy([DataSourceRequest] DataSourceRequest request, ChiTietHoaDonViewModel product)
        {
            ProductService ps = new ProductService(db);
            if (product != null)
            {
                ps.Destroy(product);
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }
    }
}
