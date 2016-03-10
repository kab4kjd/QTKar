using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QTKar.Models;
namespace QTKar.Controllers
{
    public class ProductService : IDisposable
    {
        private KaraokeDBEntities2 entities;

        public ProductService(KaraokeDBEntities2 entities)
        {
            this.entities = entities;
        }

        public IEnumerable<ChiTietHoaDonViewModel> Read()
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
                
                SanPham = hoadon.SanPham.TenHang,
                SoLuong=hoadon.SoLuong,

            });
        }

        public void Create(ProductViewModel product)
        {
            var entity = new Product();

            entity.ProductName = product.ProductName;
            entity.UnitPrice = product.UnitPrice;
            entity.UnitsInStock = (short)product.UnitsInStock;
            entity.Discontinued = product.Discontinued;
            entity.CategoryID = product.CategoryID;

            if (entity.CategoryID == null)
            {
                entity.CategoryID = 1;
            }

            if (product.Category != null)
            {
                entity.CategoryID = product.Category.CategoryID;
            }

            entities.Products.Add(entity);
            entities.SaveChanges();

            product.ProductID = entity.ProductID;
        }

        public void Update(ProductViewModel product)
        {
            var entity = new Product();

            entity.ProductID = product.ProductID;
            entity.ProductName = product.ProductName;
            entity.UnitPrice = product.UnitPrice;
            entity.UnitsInStock = (short)product.UnitsInStock;
            entity.Discontinued = product.Discontinued;
            entity.CategoryID = product.CategoryID;

            if (product.Category != null)
            {
                entity.CategoryID = product.Category.CategoryID;
            }

            entities.Products.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(ProductViewModel product)
        {
            var entity = new Product();

            entity.ProductID = product.ProductID;

            entities.Products.Attach(entity);

            entities.Products.Remove(entity);

            var orderDetails = entities.Order_Details.Where(pd => pd.ProductID == entity.ProductID);

            foreach (var orderDetail in orderDetails)
            {
                entities.Order_Details.Remove(orderDetail);
            }

            entities.SaveChanges();
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
    }