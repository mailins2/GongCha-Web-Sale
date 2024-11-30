using GongChaWebSale.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GongChaWebSale.Models;
using System.Drawing;
namespace GongChaWebSale.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string sortOrder, int page = 1, int id = 0, string search = "")
        {
            mydbcontext db = new mydbcontext();
            List<banggia> sp = db.Banggias.Where(row => row.Size == "M" && row.SanPham.TenSP.Contains(search)).ToList();
            ViewBag.search = search;

            ViewBag.Khuyenmai = db.khuyenMais.Where(row => row.Size == "M").ToList();

            //sort
            switch (sortOrder)
            {
                case "Masp":
                    {
                        sp = sp.OrderBy(row => row.MaSP).ToList();
                        break;
                    }
                case "giacaothap":
                    {
                        sp = sp.OrderByDescending(p => p.DonGia).ToList();
                        break;
                    }
                default:
                    sp = sp.OrderBy(row => row.MaSP).ToList();
                    break;
            }


            //page
            int pagesize = 9;
            ViewBag.Page = page;
            ViewBag.TotalPage = (int)Math.Ceiling(sp.Count() / (double)pagesize);
            int pageSkip = (page - 1) * pagesize;
            sp = sp.Skip(pageSkip).Take(pagesize).ToList();
            return View(sp);
        }
        public ActionResult Details(int id = 2)
        {
            mydbcontext db = new mydbcontext();
            List<banggia> sp = db.Banggias.Where(row => row.MaSP == id).ToList();
            ViewBag.Topping = db.Toppings.ToList();

            ViewBag.Khuyenmai = db.khuyenMais.Where(row => row.Size == "M").ToList();
            return View(sp);
        }
    }
}