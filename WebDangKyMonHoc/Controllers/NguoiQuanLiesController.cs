using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDangKyMonHoc.Models;

namespace WebDangKyMonHoc.Controllers
{
    public class NguoiQuanLiesController : Controller
    {
        private DangKyMonHocEntities db = new DangKyMonHocEntities();

        // GET: NguoiQuanLies
        public ActionResult Index()
        {
            return View(db.NguoiQuanLies.ToList());
        }

        // GET: NguoiQuanLies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiQuanLy nguoiQuanLy = db.NguoiQuanLies.Find(id);
            if (nguoiQuanLy == null)
            {
                return HttpNotFound();
            }
            return View(nguoiQuanLy);
        }

        // GET: NguoiQuanLies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NguoiQuanLies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNQL,Ten,UserName,Password")] NguoiQuanLy nguoiQuanLy)
        {
            if (ModelState.IsValid)
            {
                db.NguoiQuanLies.Add(nguoiQuanLy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nguoiQuanLy);
        }

        // GET: NguoiQuanLies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiQuanLy nguoiQuanLy = db.NguoiQuanLies.Find(id);
            if (nguoiQuanLy == null)
            {
                return HttpNotFound();
            }
            return View(nguoiQuanLy);
        }

        // POST: NguoiQuanLies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNQL,Ten,UserName,Password")] NguoiQuanLy nguoiQuanLy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoiQuanLy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nguoiQuanLy);
        }

        // GET: NguoiQuanLies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiQuanLy nguoiQuanLy = db.NguoiQuanLies.Find(id);
            if (nguoiQuanLy == null)
            {
                return HttpNotFound();
            }
            return View(nguoiQuanLy);
        }

        // POST: NguoiQuanLies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NguoiQuanLy nguoiQuanLy = db.NguoiQuanLies.Find(id);
            db.NguoiQuanLies.Remove(nguoiQuanLy);
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
