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
    public class ChuongTrinhHocsController : Controller
    {
        private DangKyMonHocEntities db = new DangKyMonHocEntities();

        // GET: ChuongTrinhHocs
        public ActionResult Index()
        {
            var chuongTrinhHocs = db.ChuongTrinhHocs.Include(c => c.Khoa);
            return View(chuongTrinhHocs.ToList());
        }

        // GET: ChuongTrinhHocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuongTrinhHoc chuongTrinhHoc = db.ChuongTrinhHocs.Find(id);
            if (chuongTrinhHoc == null)
            {
                return HttpNotFound();
            }
            return View(chuongTrinhHoc);
        }

        // GET: ChuongTrinhHocs/Create
        public ActionResult Create()
        {
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa");
            return View();
        }

        // POST: ChuongTrinhHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idChuongTrinh,MaKhoa,HocKyChuongTrinh")] ChuongTrinhHoc chuongTrinhHoc)
        {
            if (ModelState.IsValid)
            {
                db.ChuongTrinhHocs.Add(chuongTrinhHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", chuongTrinhHoc.MaKhoa);
            return View(chuongTrinhHoc);
        }

        // GET: ChuongTrinhHocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuongTrinhHoc chuongTrinhHoc = db.ChuongTrinhHocs.Find(id);
            if (chuongTrinhHoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", chuongTrinhHoc.MaKhoa);
            return View(chuongTrinhHoc);
        }

        // POST: ChuongTrinhHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idChuongTrinh,MaKhoa,HocKyChuongTrinh")] ChuongTrinhHoc chuongTrinhHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chuongTrinhHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", chuongTrinhHoc.MaKhoa);
            return View(chuongTrinhHoc);
        }

        // GET: ChuongTrinhHocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuongTrinhHoc chuongTrinhHoc = db.ChuongTrinhHocs.Find(id);
            if (chuongTrinhHoc == null)
            {
                return HttpNotFound();
            }
            return View(chuongTrinhHoc);
        }

        // POST: ChuongTrinhHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChuongTrinhHoc chuongTrinhHoc = db.ChuongTrinhHocs.Find(id);
            db.ChuongTrinhHocs.Remove(chuongTrinhHoc);
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
