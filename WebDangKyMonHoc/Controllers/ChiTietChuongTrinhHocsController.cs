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
    public class ChiTietChuongTrinhHocsController : Controller
    {
        private DangKyMonHocEntities db = new DangKyMonHocEntities();

        // GET: ChiTietChuongTrinhHocs
        public ActionResult Index()
        {
            var chiTietChuongTrinhHocs = db.ChiTietChuongTrinhHocs.Include(c => c.ChuongTrinhHoc).Include(c => c.MonHoc);
            return View(chiTietChuongTrinhHocs.ToList());
        }

        // GET: ChiTietChuongTrinhHocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietChuongTrinhHoc chiTietChuongTrinhHoc = db.ChiTietChuongTrinhHocs.Find(id);
            if (chiTietChuongTrinhHoc == null)
            {
                return HttpNotFound();
            }
            return View(chiTietChuongTrinhHoc);
        }

        // GET: ChiTietChuongTrinhHocs/Create
        public ActionResult Create()
        {
            ViewBag.idChuongTrinh = new SelectList(db.ChuongTrinhHocs, "idChuongTrinh", "MaKhoa");
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH");
            return View();
        }

        // POST: ChiTietChuongTrinhHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idChiTietCTH,idChuongTrinh,MaMH")] ChiTietChuongTrinhHoc chiTietChuongTrinhHoc)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietChuongTrinhHocs.Add(chiTietChuongTrinhHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idChuongTrinh = new SelectList(db.ChuongTrinhHocs, "idChuongTrinh", "MaKhoa", chiTietChuongTrinhHoc.idChuongTrinh);
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH", chiTietChuongTrinhHoc.MaMH);
            return View(chiTietChuongTrinhHoc);
        }

        // GET: ChiTietChuongTrinhHocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietChuongTrinhHoc chiTietChuongTrinhHoc = db.ChiTietChuongTrinhHocs.Find(id);
            if (chiTietChuongTrinhHoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.idChuongTrinh = new SelectList(db.ChuongTrinhHocs, "idChuongTrinh", "MaKhoa", chiTietChuongTrinhHoc.idChuongTrinh);
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH", chiTietChuongTrinhHoc.MaMH);
            return View(chiTietChuongTrinhHoc);
        }

        // POST: ChiTietChuongTrinhHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idChiTietCTH,idChuongTrinh,MaMH")] ChiTietChuongTrinhHoc chiTietChuongTrinhHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietChuongTrinhHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idChuongTrinh = new SelectList(db.ChuongTrinhHocs, "idChuongTrinh", "MaKhoa", chiTietChuongTrinhHoc.idChuongTrinh);
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH", chiTietChuongTrinhHoc.MaMH);
            return View(chiTietChuongTrinhHoc);
        }

        // GET: ChiTietChuongTrinhHocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietChuongTrinhHoc chiTietChuongTrinhHoc = db.ChiTietChuongTrinhHocs.Find(id);
            if (chiTietChuongTrinhHoc == null)
            {
                return HttpNotFound();
            }
            return View(chiTietChuongTrinhHoc);
        }

        // POST: ChiTietChuongTrinhHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietChuongTrinhHoc chiTietChuongTrinhHoc = db.ChiTietChuongTrinhHocs.Find(id);
            db.ChiTietChuongTrinhHocs.Remove(chiTietChuongTrinhHoc);
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
