using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TOPZONE.Models
{
    public class DonHangModel
    {
        [Required]
        public string MaDH { get; set; }
        public int SL { get; set; }
        public IEnumerable<DonDatHang> DH { get; set; }
        public IEnumerable<CTDonDatHang> CTDH { get; set; }
        public List<SanPham> SanPham {get; set;}
        public List<string> TenSP { get; set; }

    }
}