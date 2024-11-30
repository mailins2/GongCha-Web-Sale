using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GongChaWebSale.Models;
namespace GongChaWebSale.Controllers
{
    public class TranguyenchatController : Controller
    {
        // GET: Tranguyenchat
        public ActionResult Index(int id =7)
        {

            mydbcontext db = new mydbcontext();
            List<banggia> sp = db.Banggias.Where(row => row.SanPham.MaLoaiSP == id && row.Size == "M").ToList();

            ViewBag.Khuyenmai = db.khuyenMais.Where(row => row.Size == "M").ToList();
            return View(sp);
        }
    }
}