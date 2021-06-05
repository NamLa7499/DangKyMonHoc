using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDangKyMonHoc.Models;


namespace WebDangKyMonHoc.Models
{
    public class ViewListModel
    {
        DangKyMonHocEntities data = new DangKyMonHocEntities();
        public List<Khoa> listKhoa { get; set; }
        public List<Lop> listLop { get; set; }
        public ViewListModel()
        {
            listKhoa = data.Khoas.ToList();
            listLop = data.Lops.ToList();   

        }
    }
}