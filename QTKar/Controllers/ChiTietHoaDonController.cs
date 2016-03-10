using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QTKar.Models;

namespace QTKar.Controllers
{
    public class ChiTietHoaDonController : Controller
    {
        // GET: PhongSession
        
        KaraokeDBEntities2 db = new KaraokeDBEntities2();
        
     public List<ChiTietHoaDon> Chitiethoadons(int Mahoadon)
        {
            return db.ChiTietHoaDons.Where(p => p.MaHoaDon == Mahoadon).ToList();
        }


    }
}