using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.Mvc;
using GongChaWebSale.Models;

namespace GongChaWebSale.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        mydbcontext db = new mydbcontext();

        public ActionResult Index(int page = 0, int order = -1, string size = null, string loaisp = null)
        {
            List<banggia> sps = db.Banggias.ToList();
            ViewBag.loaisp = db.Loaisps.Select(row => row.TenLoaiSP).ToList();
            ViewBag.size = db.Banggias.GroupBy(row => row.Size).Select(row => row.Key).ToList();
            if (!string.IsNullOrEmpty(size))
            {
                sps = sps.Where(row => row.Size == size).ToList();
            }
            if (!string.IsNullOrEmpty(loaisp))
            {
                sps = sps.Where(row => row.SanPham.LoaiSanPham.TenLoaiSP == loaisp).ToList();
            }
            if (order == 0)
            {
                sps = sps.OrderBy(row => row.DonGia).ToList();
            }
            else if (order == 1)
            {
                sps = sps.OrderByDescending(row => row.DonGia).ToList();
            }

            int spperpage = 9;
            ViewBag.sttstart = (page * spperpage) + 1;
            ViewBag.totalpage = Math.Ceiling(sps.Count() / (double)spperpage);
            ViewBag.page = page;
            sps = sps.Skip(page * spperpage).Take(spperpage).ToList();
            return View(sps);
        }

        public ActionResult Adjust(int masp, string size)
        {
            banggia sp = db.Banggias.Where(row => row.MaSP == masp && row.Size == size).FirstOrDefault();
            ViewBag.loaisp = db.Loaisps.Select(row => row.TenLoaiSP).ToList();
            return View(sp);
        }
        [HttpPost]
        public ActionResult Adjust(banggia sp, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                banggia spcu = db.Banggias.Where(row => row.MaSP == sp.MaSP && row.Size == sp.Size).FirstOrDefault();
                spcu.SanPham.TenSP = sp.SanPham.TenSP;
                spcu.DonGia = sp.DonGia;
                spcu.SanPham.MoTa = sp.SanPham.MoTa;
                spcu.SanPham.MaLoaiSP = db.Loaisps.Where(row => row.TenLoaiSP == sp.SanPham.LoaiSanPham.TenLoaiSP).Select(row => row.MaLoaiSP).FirstOrDefault();
                if (imageFile != null && imageFile.ContentLength > 0)
                {

                    if (imageFile.ContentLength > 2000000)
                    {
                        ModelState.AddModelError("Image", "Kích thước file không được lớn hơn 2MB.");
                        return View();
                    }

                    var allowedExtensions = new[] { ".jpg", ".png" };
                    var fileExtension = Path.GetExtension(imageFile.FileName).ToLower();
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        ModelState.AddModelError("Image", "Chỉ chấp nhận file ảnh PNG hoặc JPG");
                        return View();
                    }
                    var fileName = sp.SanPham.TenSP.ToString() + fileExtension;
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    imageFile.SaveAs(path);

                    spcu.SanPham.Hinh = "~/Images/" + fileName;


                    return RedirectToAction("Index");
                }
                db.SaveChanges();
            }
            return Redirect("Index");
        }
        public ActionResult delete(int masp, string size)
        {
            banggia sp = db.Banggias.Where(row => row.MaSP == masp && row.Size == size).FirstOrDefault();
            if (sp != null)
            {
                db.Banggias.Remove(sp);
                var count = db.Banggias.Where(row => row.MaSP == masp).Count();
                if (count == 1)
                {
                    sanpham sanpham = db.Sanphams.Where(row => row.MaSP == masp).FirstOrDefault();
                    db.Sanphams.Remove(sanpham);
                }
                db.SaveChanges();

            }

            return Redirect("Index");
        }
        public ActionResult Create()
        {
            ViewBag.loaisp = db.Loaisps.Select(row => row.TenLoaiSP).ToList();

            return View();
        }
        [HttpPost]
        public ActionResult Create(banggia sp, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.ContentLength > 0)
                {

                    if (imageFile.ContentLength > 2000000)
                    {
                        ModelState.AddModelError("Image", "Kích thước file không được lớn hơn 2MB.");
                        return View();
                    }

                    var allowedExtensions = new[] { ".jpg", ".png" };
                    var fileExtension = Path.GetExtension(imageFile.FileName).ToLower();
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        ModelState.AddModelError("Image", "Chỉ chấp nhận file ảnh PNG hoặc JPG");
                        return View();
                    }
                    var fileName = sp.SanPham.TenSP.ToString() + fileExtension;
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    imageFile.SaveAs(path);

                    sp.SanPham.Hinh = "~/Images/" + fileName;
                    db.Banggias.Add(sp);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                db.Banggias.Add(sp);
                db.SaveChanges();
            }
            return Redirect("Index");
        }
        public ActionResult Qldonhang()
        {
            return View();
        }
    }
}