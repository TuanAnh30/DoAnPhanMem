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
    public class CHUDEsController : Controller
    {
        private DAPMEntities db = new DAPMEntities();

        // GET: CHUDEs
        public ActionResult Index()
        {
            return View(db.CHUDE.ToList());
        }

        // GET: CHUDEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUDE cHUDE = db.CHUDE.Find(id);
            if (cHUDE == null)
            {
                return HttpNotFound();
            }
            return View(cHUDE);
        }

        // GET: CHUDEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CHUDEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCD,TenCD")] CHUDE cHUDE)
        {
            if (ModelState.IsValid)
            {
                db.CHUDE.Add(cHUDE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cHUDE);
        }

        // GET: CHUDEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUDE cHUDE = db.CHUDE.Find(id);
            if (cHUDE == null)
            {
                return HttpNotFound();
            }
            return View(cHUDE);
        }

        // POST: CHUDEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCD,TenCD")] CHUDE cHUDE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHUDE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cHUDE);
        }

        // GET: CHUDEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUDE cHUDE = db.CHUDE.Find(id);
            if (cHUDE == null)
            {
                return HttpNotFound();
            }
            return View(cHUDE);
        }

        // POST: CHUDEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHUDE cHUDE = db.CHUDE.Find(id);
            db.CHUDE.Remove(cHUDE);
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
