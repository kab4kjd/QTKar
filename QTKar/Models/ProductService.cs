using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QTKar.Models;
using System.Data.Entity;

namespace QTKar.Controllers
{
    public class ProductService : IDisposable
    {
        private KaraokeDBEntities2 entities;

        public ProductService(KaraokeDBEntities2 entities)
        {
            this.entities = entities;
        }

        public IEnumerable<ChiTietHoaDonViewModel> Read(int maHoaDon)
        {
            return entities.ChiTietHoaDons.Select(hoadon => new ChiTietHoaDonViewModel
            {
                //ProductID = hoadon.ProductID,
                //ProductName = hoadon.ProductName,
                //UnitPrice = hoadon.UnitPrice.HasValue ? hoadon.UnitPrice.Value : default(decimal),
                //UnitsInStock = hoadon.UnitsInStock.HasValue ? hoadon.UnitsInStock.Value : default(short),
                //QuantityPerUnit = hoadon.QuantityPerUnit,
                //Discontinued = hoadon.Discontinued,
                //UnitsOnOrder = hoadon.UnitsOnOrder.HasValue ? (int)hoadon.UnitsOnOrder.Value : default(int),
                //CategoryID = hoadon.CategoryID,
                //Category = new CategoryViewModel()
                //{
                //    CategoryID = hoadon.Category.CategoryID,
                //    CategoryName = hoadon.Category.CategoryName
                //},
                //LastSupply = DateTime.Today
                MaChiTietHoaDon=hoadon.MaChiTietHoaDon,
                MaHoaDon=maHoaDon,
                SanPham = entities.SanPhams.Where(sp => sp.MaHang == hoadon.MaHang).Single(),
                SoLuong=hoadon.SoLuong,
                ThanhTien=hoadon.ThanhTien

            }).Where(ct=>ct.MaHoaDon==maHoaDon);
        }

        public void Create(ChiTietHoaDonViewModel ct)
        {
            var entity = new ChiTietHoaDon();

            entity.MaHoaDon = ct.MaHoaDon;
            entity.SoLuong = ct.SoLuong;
            entity.ThanhTien = ct.ThanhTien;
            entity.MaHang = ct.SanPham.MaHang;            

            //if (entity.CategoryID == null)
            //{
            //    entity.CategoryID = 1;
            //}

            //if (ct.Category != null)
            //{
            //    entity.CategoryID = ct.Category.CategoryID;
            //}

            entities.ChiTietHoaDons.Add(entity);
            entities.SaveChanges();           
        }

        public void Update(ChiTietHoaDonViewModel ct)
        {
            var entity = new ChiTietHoaDon();

            entity.MaHoaDon = ct.MaHoaDon;
            entity.SoLuong = ct.SoLuong;
            entity.ThanhTien = ct.ThanhTien;
            entity.MaHang = ct.SanPham.MaHang;
            

            entities.ChiTietHoaDons.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(ChiTietHoaDonViewModel ct)
        {
            var entity = new ChiTietHoaDon();

            entity.MaChiTietHoaDon = ct.MaChiTietHoaDon;

            entities.ChiTietHoaDons.Attach(entity);

            entities.ChiTietHoaDons.Remove(entity);

            //var orderDetails = entities.Order_Details.Where(pd => pd.ProductID == entity.ProductID);

            //foreach (var orderDetail in orderDetails)
            //{
            //    entities.Order_Details.Remove(orderDetail);
            //}

            entities.SaveChanges();
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
    }