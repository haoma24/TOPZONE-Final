//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TOPZONE
{
    using System;
    using System.Collections.Generic;
    
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.CTDonDatHang = new HashSet<CTDonDatHang>();
            this.CTPhieuNhap = new HashSet<CTPhieuNhap>();
            this.CTHoaDon = new HashSet<CTHoaDon>();
        }
    
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public double GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public string Hinh { get; set; }
        public string MaLoaiSP { get; set; }
        public string MaNCC { get; set; }
    
        public virtual LoaiSP LoaiSP { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDonDatHang> CTDonDatHang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuNhap> CTPhieuNhap { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDon> CTHoaDon { get; set; }
    }
}