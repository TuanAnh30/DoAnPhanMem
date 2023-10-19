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
    public class TACGIAsController : Controller
    {
        private DAPMEntities db = new DAPMEntities();

        // GET: TACGIAs
        public ActionResult Index()
        {
            return View(db.TACGIA.ToList());
        }

        // GET: TACGIAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TACGIA tACGIA = db.TACGIA.Find(id);
            if (tACGIA == null)
            {
                return HttpNotFound();
            }
            return View(tACGIA);
        }

        // GET: TACGIAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TACGIAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTG,TenTG,DiachiTG,DienthoaiTG")] TACGIA tACGIA)
        {
            if (ModelState.IsValid)
            {
                db.TACGIA.Add(tACGIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tACGIA);
        }

        // GET: TACGIAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TACGIA tACGIA = db.TACGIA.Find(id);
            if (tACGIA == null)
            {
                return HttpNotFound();
            }
            return View(tACGIA);
        }

        // POST: TACGIAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTG,TenTG,DiachiTG,DienthoaiTG")] TACGIA tACGIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tACGIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tACGIA);
        }

        // GET: TACGIAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TACGIA tACGIA = db.TACGIA.Find(id);
            if (tACGIA == null)
            {
                return HttpNotFound();
            }
            return View(tACGIA);
        }

        // POST: TACGIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TACGIA tACGIA = db.TACGIA.Find(id);
            db.TACGIA.Remove(tACGIA);
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
