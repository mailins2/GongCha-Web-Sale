using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GongChaWebSale.Models;

namespace GongChaWebSale.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        mydbcontext db = new mydbcontext();
        public ActionResult Index()//Dang nhap
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(string UserName, string PassWord)
        {

            if (ModelState.IsValid)
            {
                var user = db.Taikhoans.FirstOrDefault(t=>t.Email == UserName || t.SDT == UserName);
                if(user!=null)
                {
                    //if(BCrypt.Net.BCrypt.Verify(PassWord,user.MatKhau))
                    if(PassWord==user.MatKhau)
                    {
                        Session["UserName"] = user.TenTK;
                        Session["UserID"] = user.MaTK;
                        TempData["Message"] = "Đăng nhập thành công";
                        if (user.MaLoaiTK==1)
                        {
                            Session["user"] = User;
                          
                            return RedirectToAction("Index", "Home");
                        }
                        if(user.MaLoaiTK==2)
                        {
                            Session["user"] = User;
                       
                            return RedirectToAction("Index", "Admin");
                        }
                    }
                    else
                    {
                        ViewBag.Login = "Đăng nhập không thành công! Vui lòng kiểm tra lại tên đăng nhập hoặc mật khẩu.";

                    }
                }
                else
                {
                    ViewBag.Login = "Tài khoản không tồn tại";
                }
            }

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(taikhoan user, string PasswordAgain)
        {
            if (ModelState.IsValid)
            {
                taikhoan tk = db.Taikhoans.Where(t => t.TenTK == user.TenTK).FirstOrDefault();
                if (tk != null)
                {
                    ModelState.AddModelError("TenTK", "Tài khoản đã tồn tại");
                    return View(user);

                }
                tk = db.Taikhoans.Where(t => t.Email == user.Email).FirstOrDefault();
                if (tk != null)
                {
                    ModelState.AddModelError("Email", "Email đã tồn tại");
                    return View(user);

                }
                if (user.MatKhau != PasswordAgain)
                {
                    ModelState.AddModelError("PasswordAgain", "Mật khẩu và Xác nhận mật khẩu không trùng khớp");
                    return View(user);
                }

                //string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.MatKhau);
                //tk = new taikhoan();
                //tk.TenTK = user.TenTK;
                //tk.Email = user.Email;
                //tk.GioiTinh = user.GioiTinh;
                //tk.SDT = user.SDT;
                //tk.MatKhau = hashedPassword;
                tk = user;
                tk.MaLoaiTK = 2;
                db.Taikhoans.Add(tk);
                db.SaveChanges();
                TempData["Message"] = "Đăng ký thành công";
                return RedirectToAction("Index", "User");

            }

            return View();
        }

        public ActionResult Logout()
        {
            Session["UserName"] = null;
            Session["user"] = null;
            TempData["Message"] = "Đăng xuất thành công";
            return RedirectToAction("Index", "Home");
        }
    }
}