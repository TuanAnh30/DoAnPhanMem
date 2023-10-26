using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;

namespace Admin.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: ThongKe
        public DAPMEntities db = new DAPMEntities();
        public ActionResult Index()
        {
            BestSeller();
            ViewBag.SoKH = SoKhachHang();
            ViewBag.SoDH = SoDonHang();
            ViewBag.SoDHT = SoDonHangThang();
            ViewBag.TongDoanhThu = ThongKeDoanhThu();
            ViewBag.DoanhThuThang = ThongKeDoanhThuThang();

            return View();
        }
        public int SoKhachHang()
        {
            int kh = db.KHACHHANG.Count();
            return kh;
        }
        public int SoDonHang()
        {
            int dh = db.DONDATHANG.Count();
            return dh;
        }
        public decimal SoDonHangThang()
        {
            var dh = db.DONDATHANG.Where(n => n.NgayDH.Value.Month == DateTime.Now.Month);
            decimal rs = dh.Count();
            return rs;
        }

        public decimal ThongKeDoanhThu()
        {
            // Thong ke theo tat ca doanh thu 
            decimal tongdoanhthu = (decimal)db.CTDATHANG.Sum(n => n.Thanhtien).Value;
            return tongdoanhthu;
        }
        public decimal ThongKeDoanhThuThang()
        {

            // Thong ke theo ngay, thang doanh thu 
            var listDH = db.DONDATHANG.Where(n => n.NgayDH.Value.Month == DateTime.Now.Month && n.NgayDH.Value.Year == DateTime.Now.Year);
            decimal tongtien = 0;
            //duyet danh sach da loc, tinh tong tien 
            foreach (var item in listDH)
            {
                tongtien += (decimal)item.CTDATHANG.Sum(n => n.Thanhtien).Value;
            }
            return tongtien;
        }
        public ActionResult BestSeller()
        {
            List<CTDATHANG> orderDetail = db.CTDATHANG.ToList();
            List<SACH> proList = db.SACH.ToList();

            var query = from od in orderDetail
                        join p in proList on od.MaSach equals p.Masach into tbl
                        group od by new
                        {
                            idPro = od.MaSach,
                            namePro = od.SACH.Tensach,
                            imagePro = od.SACH.Hinhanh,
                            price = od.SACH.Dongia
                        }
                        into gr
                        orderby gr.Sum(s => s.SoLuong) descending
                        select new ViewModel
                        {
                            IDpro = gr.Key.idPro,
                            NamePro = gr.Key.namePro,
                            ImgPro = gr.Key.imagePro,
                            pricePro = (decimal)gr.Key.price,
                            sum_Quantity = gr.Sum(s => s.SoLuong)
                        };
            return View(query.Take(1).ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                    db.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}