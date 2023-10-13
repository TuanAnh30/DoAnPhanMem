using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;
using System.Web.Security;

namespace Admin.Controllers
{
    public class UserController : Controller
    {
        DAPMEntities db = new DAPMEntities();
        // GET: User
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(KHACHHANG kh, ADMIN ad)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(kh.HoTenKH))
                    ModelState.AddModelError(String.Empty, "Họ tên không được để trống");
                if (string.IsNullOrEmpty(kh.TenDN))
                    ModelState.AddModelError(String.Empty, "Tên đăng nhập không được để trống");
                if (string.IsNullOrEmpty(kh.Matkhau))
                    ModelState.AddModelError(String.Empty, "Mật khẩu không được để trống");
                if (string.IsNullOrEmpty(kh.Email))
                    ModelState.AddModelError(String.Empty, "Email không được để trống");
                if (string.IsNullOrEmpty(kh.DienThoaiKH))
                    ModelState.AddModelError(String.Empty, "Điện thoại không được để trống");
                var khachhang = db.KHACHHANG.FirstOrDefault(k => k.TenDN == kh.TenDN && k.TenDN == ad.UserAdmin);
                if (khachhang != null)
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập đẫ tồn tại!");
                if (ModelState.IsValid)
                {
                    db.KHACHHANG.Add(kh);
                    db.SaveChanges();
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("DangNhap");
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(KHACHHANG kh, ADMIN ad)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(kh.TenDN))
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập không được để trống");
                if (string.IsNullOrEmpty(kh.Matkhau))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (ModelState.IsValid)
                {
                    var khach = db.KHACHHANG.FirstOrDefault(k => k.TenDN == kh.TenDN && k.Matkhau == kh.Matkhau);
                    var admin = db.ADMIN.FirstOrDefault(s => s.UserAdmin == ad.UserAdmin && s.PassAdmin == ad.PassAdmin);
                    if (khach != null)
                    {
                        ViewBag.ThongBao = "Đăng nhập thành công!";
                        Session["TaiKhoan"] = khach;
                        return RedirectToAction("Index", "Home");
                    }
                    else if (admin != null)
                    {
                        ViewBag.ThongBao = "Đăng nhập thành công!";
                        Session["TaiKhoan"] = admin;
                        return RedirectToAction("Index", "MainAdmin");
                    }
                    else
                        ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng!";
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("DangNhap", "User");
        }
    }
}