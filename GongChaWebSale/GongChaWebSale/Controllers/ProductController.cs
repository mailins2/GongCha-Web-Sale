using GongChaWebSale.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GongChaWebSale.Models;
using System.Drawing;
using System.Data.Entity.Infrastructure;
using System.Reflection;
namespace GongChaWebSale.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        mydbcontext db = new mydbcontext();
        public ActionResult Index(string sortOrder, int page = 1, int id = 0, string search = "")
        {
            
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
        int IsConcide(giohang_sanpham ghsp, List<int> dstopping,int MaTK)
        {
            List<giohang_sanpham> ghsplst = db.giohang_Sanphams.Where(row => row.GioHang.MaTK == MaTK).ToList();
            bool flag = false;
            List<int>maghlst = ghsplst.Select(row=>row.MaGH).Distinct().ToList();
            foreach (int item in maghlst)
            {
                foreach (giohang_sanpham giohang_Sanpham in ghsplst.Where(row=>row.MaGH == item).ToList()) 
                {
                    List<giohang_sanpham> lstcungmagh = ghsplst.Where(row => row.MaGH == giohang_Sanpham.MaGH).ToList();
                    List<int> toppinglst = lstcungmagh.Select(row => row.MaTP).ToList();
                    flag = toppinglst.SequenceEqual(dstopping);
                    if (flag)
                    {
                        return giohang_Sanpham.MaGH;
                    }
                }
            }
                return -1;
        }
        public ActionResult AddCart()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCart(giohang_sanpham ghsp, List<int>dstopping,int MaTK)
        {
            int testConcide = IsConcide(ghsp, dstopping, MaTK);//Kiểm tra đơn trùng lặp 
            if (testConcide != -1)
            {
                List<giohang_sanpham>olddata = db.giohang_Sanphams.Where(row=>row.MaGH == testConcide).ToList();
                foreach(giohang_sanpham a in olddata)
                {
                    a.SoLuong = a.SoLuong + ghsp.SoLuong;
                    db.SaveChanges();
                }
            }
            else
            {
                decimal tong = 0;
                List<topping> toppingsList = db.Toppings.ToList();
                for (int i = 0; i < dstopping.Count(); i++)
                {
                    topping currenttopping = toppingsList.FirstOrDefault(row => row.MaTP == dstopping[i]);
                    tong = tong + currenttopping.DonGia;

                }
                banggia giasp = db.Banggias.Where(row => row.MaSP == ghsp.MaSP && row.Size == ghsp.Size).FirstOrDefault();
                decimal dongia = giasp.DonGia;
                tong = tong + (ghsp.SoLuong * dongia);
                //Thêm giỏ hang mới 
                giohang newgh = new giohang();
                newgh.MaTK = MaTK;
                newgh.NgayTao = DateTime.Now;
                newgh.TongTien = tong;
                db.Giohangs.Add(newgh);
                db.SaveChanges();

                for (int i = 0; i < dstopping.Count(); i++)
                {
                    giohang_sanpham temp = new giohang_sanpham()
                    {
                        MaSP = ghsp.MaSP,
                        Size = ghsp.Size,
                        SoLuong = ghsp.SoLuong,
                        MaGH = newgh.MaGH,
                        MaTP = dstopping[i],
                        TongTienSP = tong
                    };
                    db.giohang_Sanphams.Add(temp);
                    db.SaveChanges();
                }
            }
            TempData["CartUpdated"] = true;
            return RedirectToAction("Details", new { id = ghsp.MaSP });
        }
    }
}