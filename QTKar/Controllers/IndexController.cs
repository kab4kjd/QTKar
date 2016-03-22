using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QTKar.Models;
using Kendo.Mvc.Extensions;

namespace QTKar.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        KaraokeDBEntities2 db = new KaraokeDBEntities2();
        public ActionResult Index()
        {
            return View();
        }     

    }
}