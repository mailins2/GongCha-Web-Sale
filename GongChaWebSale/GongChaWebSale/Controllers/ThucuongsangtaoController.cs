using GongChaWebSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GongChaWebSale.Models;
namespace GongChaWebSale.Controllers
{
    public class ThucuongsangtaoController : Controller
    {
        // GET: Thucuongsangtao
        public ActionResult Index(int id = 8)
        {
            mydbcontext db = new mydbcontext();
            List<banggia> sp = db.Banggias.Where(row => row.SanPham.MaLoaiSP == id && row.Size == "M").ToList();

            ViewBag.Khuyenmai = db.khuyenMais.Where(row => row.Size == "M").ToList();
            return View(sp);
        }
    }
}