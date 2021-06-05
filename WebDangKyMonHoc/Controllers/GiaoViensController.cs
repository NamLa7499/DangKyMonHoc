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
    public class GiaoViensController : Controller
    {
        private DangKyMonHocEntities db = new DangKyMonHocEntities();

        // GET: GiaoViens
        public ActionResult Index()
        {
            var giaoViens = db.GiaoViens.Include(g => g.Khoa);
            return View(giaoViens.ToList());
        }

        // GET: GiaoViens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaoVien giaoVien = db.GiaoViens.Find(id);
            if (giaoVien == null)
            {
                return HttpNotFound();
            }
            return View(giaoVien);
        }

        // GET: GiaoViens/Create
        public ActionResult Create()
        {
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa");
            return View();
        }

        // POST: GiaoViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGV,TenGV,MaKhoa,NgaySinh,GioiTinh,Email,DiaChi,SDT")] GiaoVien giaoVien)
        {
            if (ModelState.IsValid)
            {
                db.GiaoViens.Add(giaoVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", giaoVien.MaKhoa);
            return View(giaoVien);
        }

        // GET: GiaoViens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaoVien giaoVien = db.GiaoViens.Find(id);
            if (giaoVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", giaoVien.MaKhoa);
            return View(giaoVien);
        }

        // POST: GiaoViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGV,TenGV,MaKhoa,NgaySinh,GioiTinh,Email,DiaChi,SDT")] GiaoVien giaoVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giaoVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", giaoVien.MaKhoa);
            return View(giaoVien);
        }

        // GET: GiaoViens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaoVien giaoVien = db.GiaoViens.Find(id);
            if (giaoVien == null)
            {
                return HttpNotFound();
            }
            return View(giaoVien);
        }

        // POST: GiaoViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GiaoVien giaoVien = db.GiaoViens.Find(id);
            db.GiaoViens.Remove(giaoVien);
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
