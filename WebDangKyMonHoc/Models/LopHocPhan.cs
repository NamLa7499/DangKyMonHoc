using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebDangKyMonHoc.Models
{
    public class LopHocPhan
    {
        [DisplayName("Mã Lớp Học Phần")]
        public int MaLHP { get; set; }
        [DisplayName("Tên Giáo Viên")]
        public string TenGV { get; set; }
        [DisplayName("Tên Môn Học")]
        public string TenMH { get; set; }
        [DisplayName("Tiết Học")]
        public string TietHoc { get; set; }
        [DisplayName("Phòng Học")]
        public string PhongHoc { get; set; }
        [DisplayName("Thứ")]
        public string Thu { get; set; }
        [DisplayName("Sô Lượng Còn")]
        public int SoLuongConLai { get; set; }
        public int TrangThai { get; set; }
    }
}