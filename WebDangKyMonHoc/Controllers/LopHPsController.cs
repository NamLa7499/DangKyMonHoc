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
    public class LopHPsController : Controller
    {
        private DangKyMonHocEntities db = new DangKyMonHocEntities();

        // GET: LopHPs
        public ActionResult Index()
        {
            var lopHPs = db.LopHPs.Include(l => l.GiaoVien).Include(l => l.MonHoc);
            return View(lopHPs.ToList());
        }

        // GET: LopHPs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopHP lopHP = db.LopHPs.Find(id);
            if (lopHP == null)
            {
                return HttpNotFound();
            }
            return View(lopHP);
        }

        // GET: LopHPs/Create
        public ActionResult Create()
        {
            ViewBag.MaGV = new SelectList(db.GiaoViens, "MaGV", "TenGV");
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH");
            return View();
        }

        // POST: LopHPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLHP,MaGV,MaMH,MaKhoa,TietHoc,PhongHoc,Thu,SiSoMax,HocKy,NamHoc")] LopHP lopHP)
        {
            if (ModelState.IsValid)
            {
                db.LopHPs.Add(lopHP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaGV = new SelectList(db.GiaoViens, "MaGV", "TenGV", lopHP.MaGV);
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH", lopHP.MaMH);
            return View(lopHP);
        }

        // GET: LopHPs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopHP lopHP = db.LopHPs.Find(id);
            if (lopHP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGV = new SelectList(db.GiaoViens, "MaGV", "TenGV", lopHP.MaGV);
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH", lopHP.MaMH);
            return View(lopHP);
        }

        // POST: LopHPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLHP,MaGV,MaMH,MaKhoa,TietHoc,PhongHoc,Thu,SiSoMax,HocKy,NamHoc")] LopHP lopHP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lopHP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGV = new SelectList(db.GiaoViens, "MaGV", "TenGV", lopHP.MaGV);
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH", lopHP.MaMH);
            return View(lopHP);
        }

        // GET: LopHPs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopHP lopHP = db.LopHPs.Find(id);
            if (lopHP == null)
            {
                return HttpNotFound();
            }
            return View(lopHP);
        }

        // POST: LopHPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LopHP lopHP = db.LopHPs.Find(id);
            db.LopHPs.Remove(lopHP);
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
