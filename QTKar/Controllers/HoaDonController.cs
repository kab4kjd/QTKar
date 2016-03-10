using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace QTKar.Controllers
{
    public class HoaDonController : Controller
    {
        // GET: HoaDon
        public PartialViewResult HoaDonParital()
        {
            return PartialView();
            
        }
    }
}