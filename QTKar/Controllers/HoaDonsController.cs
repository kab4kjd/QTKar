using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QTKar.Models;

namespace QTKar.Controllers
{
    public class HoaDonsController : Controller
    {
        private KaraokeDBEntities2 db = new KaraokeDBEntities2();
        public ActionResult TaoHoaDon(int Maphong)
        {
            db.Phongs.Where(x => x.MaPhong == Maphong).Single().TinhTrang = "open";
            db.SaveChanges();
            ViewBag.MaPhong = Maphong;
            return View("Index");
        }

        // GET: HoaDons
        public ActionResult Index()
        {
            //var hoaDons = db.HoaDons.Include(h => h.ChiTietHoaDon).Include(h => h.Khach).Include(h => h.NhanVien).Include(h => h.Phong);
            //return View(hoaDons.ToList());
            return View();
        }

        // GET: HoaDons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: HoaDons/Create
        public ActionResult Create()
        {
            ViewBag.MaHoaDon = new SelectList(db.ChiTietHoaDons, "MaHoaDon", "MaHoaDon");
            ViewBag.MaKhach = new SelectList(db.Khaches, "MaKhach", "TenKhach");
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV");
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong");
            return View();
        }

        // POST: HoaDons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHoaDon,MaNV,MaPhong,MaKhach,GioVao,Tong")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHoaDon = new SelectList(db.ChiTietHoaDons, "MaHoaDon", "MaHoaDon", hoaDon.MaHoaDon);
            ViewBag.MaKhach = new SelectList(db.Khaches, "MaKhach", "TenKhach", hoaDon.MaKhach);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", hoaDon.MaNV);
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong", hoaDon.MaPhong);
            return View(hoaDon);
        }

        // GET: HoaDons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHoaDon = new SelectList(db.ChiTietHoaDons, "MaHoaDon", "MaHoaDon", hoaDon.MaHoaDon);
            ViewBag.MaKhach = new SelectList(db.Khaches, "MaKhach", "TenKhach", hoaDon.MaKhach);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", hoaDon.MaNV);
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong", hoaDon.MaPhong);
            return View(hoaDon);
        }

        // POST: HoaDons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoaDon,MaNV,MaPhong,MaKhach,GioVao,Tong")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHoaDon = new SelectList(db.ChiTietHoaDons, "MaHoaDon", "MaHoaDon", hoaDon.MaHoaDon);
            ViewBag.MaKhach = new SelectList(db.Khaches, "MaKhach", "TenKhach", hoaDon.MaKhach);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", hoaDon.MaNV);
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong", hoaDon.MaPhong);
            return View(hoaDon);
        }

        // GET: HoaDons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
