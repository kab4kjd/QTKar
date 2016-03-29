using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QTKar.Models
{
    public class ChiTietHoaDonViewModel
    {
        public int MaChiTietHoaDon { get; set; }
        public int MaHoaDon { get; set; }
        public SanPham sanpham { get; set; }

        //public string TenHang { get; set; }
        //public int GiaHang{ get; set; }
                      
        public int SoLuong { get; set; }
        public int ThanhTien { get; set; }

        //public virtual Phong Phong { get; set; }
        //public virtual Khach Khach { get; set; }
        //public virtual NhanVien NhanVien { get; set; }      
        //public virtual HoaDon HoaDon { get; set; }
        //public virtual SanPham SanPham { get; set; }
    }
}