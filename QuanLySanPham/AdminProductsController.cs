using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Admin.Models;

namespace Admin.Controllers
{
    public class AdminProductsController : Controller
    {
        private DAPMEntities db = new DAPMEntities();

        // GET: AdminProducts
        public ActionResult Index()
        {
            var sACH = db.SACH.Include(s => s.CHUDE).Include(s => s.NHAXUATBAN);
            return View(sACH.ToList());
        }

        // GET: AdminProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACH.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // GET: AdminProducts/Create
        public ActionResult Create()
        {
            ViewBag.MaCD = new SelectList(db.CHUDE, "MaCD", "TenCD");
            ViewBag.MaNXB = new SelectList(db.NHAXUATBAN, "MaNXB", "TenNXB");
            return View();
        }

        // POST: AdminProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Masach,Tensach,Donvitinh,Dongia,Mota,Hinhanh,MaCD,MaNXB,Ngaycapnhat,Soluongban,Solanxem")] SACH sACH)
        {
            if (ModelState.IsValid)
            {
                db.SACH.Add(sACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCD = new SelectList(db.CHUDE, "MaCD", "TenCD", sACH.MaCD);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBAN, "MaNXB", "TenNXB", sACH.MaNXB);
            return View(sACH);
        }

        // GET: AdminProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACH.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCD = new SelectList(db.CHUDE, "MaCD", "TenCD", sACH.MaCD);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBAN, "MaNXB", "TenNXB", sACH.MaNXB);
            return View(sACH);
        }

        // POST: AdminProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Masach,Tensach,Donvitinh,Dongia,Mota,Hinhanh,MaCD,MaNXB,Ngaycapnhat,Soluongban,Solanxem")] SACH sACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCD = new SelectList(db.CHUDE, "MaCD", "TenCD", sACH.MaCD);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBAN, "MaNXB", "TenNXB", sACH.MaNXB);
            return View(sACH);
        }

        // GET: AdminProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACH.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // POST: AdminProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SACH sACH = db.SACH.Find(id);
            db.SACH.Remove(sACH);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
