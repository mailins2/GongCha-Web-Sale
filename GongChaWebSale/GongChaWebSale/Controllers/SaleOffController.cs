using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GongChaWebSale.Models;

namespace GongChaWebSale.Controllers
{
    public class SaleOffController : Controller
    {
        // GET: SaleOff
        mydbcontext db = new mydbcontext();
        public ActionResult Index(string makm)
        {
            List<KhuyenMai> khuyenmai = db.khuyenMais.Where(row => row.Size == "M" && row.NgayKetThuc > DateTime.Now).ToList();
            ViewBag.makm = makm;
            return View(khuyenmai);
        }
    }
}