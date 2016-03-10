using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QTKar.Models;

namespace QTKar.Models
{
    public class HoaDonViewModel
    {
        KaraokeDBEntities2 db = new KaraokeDBEntities2();
        public int MaHoaDon { get; set; }
        public string TenPhong { get; set; }
        public string TenKhach { get; set; }
        public string TenNV { get; set; }

        public System.DateTime GioVao { get; set; }

        public List<ChiTietHoaDonViewModel> Chitiets { get; set; }
        //public Nullable<int> SoLuong { get; set; }
        //public Nullable<int> DonGia { get; }
        //public Nullable<int> ThanhTien { get { return SoLuong * DonGia; } }


        
        public int Tong { get; set; }

        //public PhongSession (string tenHang)
        //{
        //    TenHang = tenHang;
        //    SanPham sp = db.SanPhams.Single(n => n.TenHang == TenHang);

        //}

    }
}