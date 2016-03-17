using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QTKar.Models;
using System.Net;

namespace QTKar.Controllers
{

    public class PhongController : Controller
    {

        // GET: Phong


        KaraokeDBEntities2 db = new KaraokeDBEntities2();


      
        public PartialViewResult PhongPartial()
        {
            return PartialView(db.Phongs.ToList());
        }
        // GET: Phong/Details/5
       
        public ActionResult ChiTietPhong(int? Maphong)
        {
            if (Maphong == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Where(x => x.DaThanhToan == 0 & x.MaPhong == Maphong).Single();
            if (hoaDon == null)
            {
                //return HttpNotFound();
            }
            return View(hoaDon);
        }
        public ActionResult MoPhong(int Maphong)
        {
            db.Phongs.Where(x => x.MaPhong == Maphong).Single().TinhTrang = "open";
            db.SaveChanges();
            //ViewBag.MaKhach = new SelectList(db.Khaches, "MaKhach", "TenKhach");
            //ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV");
            HoaDon hoaDon = new HoaDon();
            hoaDon.MaPhong = Maphong;
            hoaDon.DaThanhToan = 0;
            hoaDon.GioVao = DateTime.Now;
            hoaDon.MaKhach = 1;
            hoaDon.MaNV = 1;
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
            }
            return RedirectToAction("ChiTietPhong", Maphong);
                         

        }

        // GET: Phong/Delete/5
        public ActionResult HuyPhong(int Maphong)
        {
            db.Phongs.Where(x => x.MaPhong == Maphong).Single().TinhTrang = "close";
            db.SaveChanges();
            HoaDon hd = db.HoaDons.Where(x => x.MaPhong == Maphong && x.DaThanhToan == 0).Single();
            db.HoaDons.Remove(hd);
            db.SaveChanges();
            return RedirectToAction("Index","Index");
        }

        // POST: Phong/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //// GET: Phong/Create
        //public ActionResult Create(int Maphong)
        //{
        //    db.Phongs.Where(x => x.MaPhong == Maphong).Single().TinhTrang = "open";
        //    db.SaveChanges();
        //    return RedirectToAction("Detail", "Phong", Maphong);
        //}

        //// POST: Phong/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Phong/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Phong/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
