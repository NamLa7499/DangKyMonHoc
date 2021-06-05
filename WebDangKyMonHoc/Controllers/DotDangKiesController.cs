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
    public class DotDangKiesController : Controller
    {
        private DangKyMonHocEntities db = new DangKyMonHocEntities();

        // GET: DotDangKies
        public ActionResult Index()
        {
            var dotDangKies = db.DotDangKies.Include(d => d.Khoa);
            return View(dotDangKies.ToList());
        }

        // GET: DotDangKies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DotDangKy dotDangKy = db.DotDangKies.Find(id);
            if (dotDangKy == null)
            {
                return HttpNotFound();
            }
            return View(dotDangKy);
        }

        // GET: DotDangKies/Create
        public ActionResult Create()
        {
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa");
            return View();
        }

        // POST: DotDangKies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HocKyChuongTrinh,MaKhoa,KhoaHoc,NgayBatDau,NgayKetThuc")] DotDangKy dotDangKy)
        {
            if (ModelState.IsValid)
            {
                db.DotDangKies.Add(dotDangKy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", dotDangKy.MaKhoa);
            return View(dotDangKy);
        }

        // GET: DotDangKies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DotDangKy dotDangKy = db.DotDangKies.Find(id);
            if (dotDangKy == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", dotDangKy.MaKhoa);
            return View(dotDangKy);
        }

        // POST: DotDangKies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDotDangKy,HocKyChuongTrinh,MaKhoa,KhoaHoc,NgayBatDau,NgayKetThuc")] DotDangKy dotDangKy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dotDangKy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhoa = new SelectList(db.Khoas, "MaKhoa", "TenKhoa", dotDangKy.MaKhoa);
            return View(dotDangKy);
        }

        // GET: DotDangKies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DotDangKy dotDangKy = db.DotDangKies.Find(id);
            if (dotDangKy == null)
            {
                return HttpNotFound();
            }
            return View(dotDangKy);
        }

        // POST: DotDangKies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DotDangKy dotDangKy = db.DotDangKies.Find(id);
            db.DotDangKies.Remove(dotDangKy);
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
