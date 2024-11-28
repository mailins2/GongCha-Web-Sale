using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using GongChaWebSale.Models;
namespace GongChaWebSale.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        mydbcontext db = new mydbcontext();
        public ActionResult Index()
        {
            List<KhuyenMai> khuyenmai = db.khuyenMais.Where(row => row.Size == "M" && row.NgayKetThuc > DateTime.Now).ToList();

            return View(khuyenmai);
        }

    }
}