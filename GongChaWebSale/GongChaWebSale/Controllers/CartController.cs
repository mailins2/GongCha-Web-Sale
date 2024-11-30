using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GongChaWebSale.Models;
namespace GongChaWebSale.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        mydbcontext db = new mydbcontext();
        public static giohang_sanpham tmp;
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                int UserId = (int)Session["UserID"];
                List<giohang_sanpham> ghsp = db.giohang_Sanphams.Where(t => t.GioHang.MaTK == UserId).ToList();
                List<giohang> gh = db.Giohangs.Where(t => t.MaTK == UserId).ToList();
                ViewBag.gh = gh;
                return View(ghsp);
            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public ActionResult Delete(giohang_sanpham ghsp)
        {
            if (ghsp != null)
            {
                giohang_sanpham ct = db.giohang_Sanphams.FirstOrDefault(t => t.MaGH == ghsp.MaGH && t.MaSP == ghsp.MaSP && t.MaTP == ghsp.MaTP && t.Size == ghsp.Size);

                if (ct != null)
                {
                    db.giohang_Sanphams.Remove(ct);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Cart");
        }
        [HttpPost]

        public ActionResult Edit(giohang_sanpham ghsp)
        {
            if (ghsp != null)
            {
                List<topping> tp = db.Toppings.ToList();
                ViewBag.Toppings = tp;
                giohang_sanpham ct = db.giohang_Sanphams.FirstOrDefault(t => t.MaGH == ghsp.MaGH && t.MaSP == ghsp.MaSP && t.MaTP == ghsp.MaTP && t.Size == ghsp.Size);
                
                tmp = ct;
                if (ct != null)
                {
                    var sizes = db.Banggias.Where(b => b.MaSP == ghsp.MaSP).Select(b => b.Size).ToList();
                    ViewBag.Sizes = sizes;
                    return View(ct);
                }
            }
            return RedirectToAction("Index", "Cart");
        }
     


        [HttpPost]
     
        public ActionResult SaveChanges(giohang_sanpham editedItem)
        {
            if (ModelState.IsValid)
            {
                List<topping> tp = db.Toppings.ToList();
                ViewBag.Toppings = tp;

                // Sử dụng các giá trị khóa chính ban đầu để tìm kiếm bản ghi gốc
                var existingItem = db.giohang_Sanphams.FirstOrDefault(t => t.MaGH == CartController.tmp.MaGH && t.MaSP == CartController.tmp.MaSP && CartController.tmp.Size == t.Size);
                if (existingItem != null)
                {
                    // Cập nhật các thuộc tính không thuộc khóa chính
                    existingItem.SoLuong = editedItem.SoLuong;
                    
                    

                    // Tính giá tiền và cập nhật
                    //var gia = db.Banggias.FirstOrDefault(t => t.MaSP == editedItem.MaSP && t.Size == editedItem.Size);
                 
                    //var km = db.khuyenMais.FirstOrDefault(t => t.MaSP == editedItem.MaSP);

                    //if (km != null && km.NgayKetThuc > DateTime.Now)
                    //{
                    //    existingItem.TongTienSP = editedItem.SoLuong * gia.DonGia - (km.Ptgiam * gia.DonGia / 100);
                    //}
                    //else
                    //{
                    //    existingItem.TongTienSP = (decimal)editedItem.SoLuong * gia.DonGia;
                    //}

                    try
                    {
                        db.SaveChanges();
                        
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                    {
                        foreach (var entry in ex.Entries)
                        {
                            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                entry.Entity.GetType().Name, entry.State);

                            foreach (var ve in entry.GetValidationResult().ValidationErrors)
                            {
                                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                        throw; // Hoặc ghi log ex.InnerException để xem thông tin chi tiết
                    }


                    TempData["Message"] = "Cập nhật sản phẩm thành công.";
                    return RedirectToAction("Index", "Cart");
                }
                else
                {
                    TempData["Message"] = "Không tìm thấy sản phẩm để cập nhật.";
                }
            }

            return View("Edit", "Cart"); // Trả về view chỉnh sửa nếu có lỗi
        }


    }
}