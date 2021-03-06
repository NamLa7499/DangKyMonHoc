//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebDangKyMonHoc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;

    public partial class ChuongTrinhHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChuongTrinhHoc()
        {
            this.ChiTietChuongTrinhHocs = new HashSet<ChiTietChuongTrinhHoc>();
        }

        [DisplayName("id Chương Trình")]
        public int idChuongTrinh { get; set; }
        [DisplayName("Mã Khoa")]
        public string MaKhoa { get; set; }
        [DisplayName("Học Kỳ Chương Trình")]
        [Range(1, 8)]
        public int HocKyChuongTrinh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietChuongTrinhHoc> ChiTietChuongTrinhHocs { get; set; }
        public virtual Khoa Khoa { get; set; }
    }
}
