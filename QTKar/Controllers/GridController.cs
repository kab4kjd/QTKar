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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChiTietHoaDons_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<ChiTietHoaDon> chitiethoadons = db.ChiTietHoaDons;
            DataSourceResult result = chitiethoadons.ToDataSourceResult(request, chiTietHoaDon => new {
                MaHoaDon = chiTietHoaDon.MaHoaDon,
                SoLuong = chiTietHoaDon.SoLuong,
                ThanhTien = chiTietHoaDon.ThanhTien,
            });

            return Json(result);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
