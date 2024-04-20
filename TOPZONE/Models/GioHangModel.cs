using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOPZONE.Models
{
    public class GioHangModel
    {

        public GioHangModel(SanPham sanPham, int sl)
        {
            Item = sanPham;
            Quantity = sl;
            Price = Item.GiaBan * Quantity;
            ProductNum = sanPham.MaSP.Count();
        }

        public int Quantity { get; set; }
        public int ProductNum { get; set; }

        public double Price {  get; set; }


        public virtual SanPham Item { get; set; }
    }
}