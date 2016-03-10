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
    public class TestSanPhamController : Controller
    {
        private KaraokeDBEntities2 db = new KaraokeDBEntities2();

        public ActionResult TestSanPham()
        {
            return View();
        }

        public ActionResult SanPhams_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<SanPham> sanphams = db.SanPhams;
            DataSourceResult result = sanphams.ToDataSourceResult(request, sanPham => new {
                TenHang = sanPham.TenHang,
                GiaBan = sanPham.GiaBan,
            });

            return Json(result,JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SanPhams_Create([DataSourceRequest]DataSourceRequest request, SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                var entity = new SanPham
                {
                    GiaBan = sanPham.GiaBan,
                };

                db.SanPhams.Add(entity);
                db.SaveChanges();
                sanPham.TenHang = entity.TenHang;
            }

            return Json(new[] { sanPham }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SanPhams_Update([DataSourceRequest]DataSourceRequest request, SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                var entity = new SanPham
                {
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
