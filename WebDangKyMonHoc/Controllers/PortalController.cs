using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDangKyMonHoc.Models;

namespace WebDangKyMonHoc.Controllers
{
    public class PortalController : Controller
    {
        // GET: Portal
        private DangKyMonHocEntities db = new DangKyMonHocEntities();
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string MaSV, string password)
        {
            if (ModelState.IsValid)
            {
                var data2 = db.NguoiQuanLies.Where(s => s.UserName.Equals(MaSV) && s.Password.Equals(password)).ToList();
                if (data2.Count() > 0)
                {
                    Session["NQL"] = data2.FirstOrDefault().Ten;
                    return RedirectToAction("Index","Home");

                }
            }
            if (ModelState.IsValid)
            {


                var data = db.SinhViens.Where(s => s.MaSV.Equals(MaSV) && s.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["MaSV"] = data.FirstOrDefault().MaSV;
                    Session["TenSV"] = data.FirstOrDefault().TenSV;
                    Session["MaLop"] = data.FirstOrDefault().MaLop;
                    Session["TenLop"] = db.Lops.Find(Session["MaLop"]).TenLop;
                    Session["KhoaHoc"] = db.Lops.Find(Session["MaLop"]).KhoaHoc;
                    return RedirectToAction("Index");
                }



                                        else
                            {
                                ViewBag.error = "Login failed";
                                return RedirectToAction("Login");
                            }
                

            }

            return View();
        }
        public ActionResult DangKyMonHoc(string searchString)
        {
            if(Session["MaSV"]==null)
            { return RedirectToAction("Login"); }

            var dsmonhoc = db.MonHocs.ToList();
            return View(dsmonhoc);

        }
        public ActionResult DangKyLopHocPhan(string maMH)
        {
            var dsLHP = db.LopHPs.Where(s => s.MaMH == maMH);

            return View(dsLHP.ToList());

        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }


    }
}