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
     
        public SanPham SanPham { get; set; }


               
        public Nullable<int> SoLuong { get; set; }
        public Nullable<int> ThanhTien { get; set; }

        //public virtual Phong Phong { get; set; }
        //public virtual Khach Khach { get; set; }
        //public virtual NhanVien NhanVien { get; set; }      
        //public virtual HoaDon HoaDon { get; set; }
        //public virtual SanPham SanPham { get; set; }
    }
}