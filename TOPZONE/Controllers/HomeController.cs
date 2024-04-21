using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOPZONE.Models;

namespace TOPZONE.Controllers
{
    public class HomeController : Controller
    {
        private TopzoneEntities db = new TopzoneEntities();
        public ActionResult Index()
        {
            var sanPham = db.SanPham.OrderBy(x => x.MaLoaiSP);

            return View(sanPham.ToList());
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DonDatHang(FormCollection form)
        {
            string MaDH = form["MaDH"];
            DonHangModel model = new DonHangModel();
            model.DH = db.DonDatHang.Where(x => x.MaDH == MaDH.TrimEnd());
            model.CTDH = db.CTDonDatHang.Where(x => x.MaDH == MaDH.TrimEnd());
            List<string> MaSP = db.CTDonDatHang.Where(x => x.MaDH == MaDH.TrimEnd()).Select(x => x.MaSP).ToList();
            List<SanPham> dsSanPham = new List<SanPham>();
            for (int i = 0; i < MaSP.Count; i++)
            {
                var ID = MaSP[i].TrimEnd();
                SanPham SP = db.SanPham.Where(x => x.MaSP == ID).FirstOrDefault();
                dsSanPham.Add(SP);
                model.SanPham = dsSanPham;

            }
            return View(model);
        }
        public ActionResult TraVeDonDatHang()
        {
            return View();
        }
        public ActionResult TraCuuDonDatHang()
        {
            return View();
        }
        public ActionResult KiemTraUser(FormCollection form)
        {
            string TK = form["TenTK"];
            string MK = form["MK"];
            string ID = db.TaiKhoan.Where(x => x.TenDN == TK).Select(x => x.TenDN).FirstOrDefault();
            string Pass = db.TaiKhoan.Where(x => x.MatKhau == TK).Select(x => x.MatKhau).FirstOrDefault();
            if (ID != null || Pass != null)
                return RedirectToAction("Dashboard", "Home");
            ViewBag.msg = "Sai tài khoản hoặc mật khẩu";
            return View("DangNhap");

        }
        public ActionResult Dashboard()
        {
            var DonDatHang = db.DonDatHang.OrderBy(x => x.MaDH);
            return View(DonDatHang.ToList());
        }
        public ActionResult DatHang(FormCollection form)
        {
            List<GioHangModel> gioHangModels = (List<GioHangModel>)Session["cart"];
            DonDatHang dh = new DonDatHang();
            KhachHang kh = new KhachHang();
            CTDonDatHang ctdh = new CTDonDatHang();
            string MaDH = DateTime.Now.ToString("yyMMddms");
            string MaKH = DateTime.Now.ToString("yyMMddms");
            string NgayDH = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime NgayDHdt = DateTime.ParseExact(NgayDH, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string TenKH = form["TenKH"];
            string SDT = form["SDT"];
            string HTTT = form["rbtnHTTT"];
            string DiaChi = form["txtSoNha"] + ", " + form["ddlP"] + ", " + form["ddlQ"] + ", " + form["ddlTP"];
            if (SDT == db.KhachHang.Where(x => x.SDT==SDT).Select(x => x.SDT).FirstOrDefault())
            {
                dh.MaDH = MaDH;
                dh.TenNguoiNhan = TenKH;
                dh.TriGia = null;
                dh.DiaChiNhan = DiaChi;
                dh.SDTNguoiNhan = SDT;
                dh.HTTT = HTTT;
                dh.NgayDH = NgayDHdt;
                dh.TrinhTrang = "Đang xử lý";
                string _MaKH = db.KhachHang.Where(x => x.SDT == SDT).Select(x => x.MaKH).First();
                dh.MaKH = _MaKH;
                db.DonDatHang.Add(dh);
                db.SaveChanges();
                foreach(var item in gioHangModels)
                {
                    ctdh.MaSP = item.Item.MaSP;
                    ctdh.MaDH = MaDH;
                }
                


            }
            else
            {
                kh.SDT = SDT;
                kh.TenKH = TenKH;
                kh.Email = null;
                kh.MaKH = MaKH;
                db.KhachHang.Add(kh);
                db.SaveChanges();
                dh.MaDH = MaDH;
                dh.TenNguoiNhan = TenKH;
                dh.TriGia = null;
                dh.DiaChiNhan = DiaChi;
                dh.SDTNguoiNhan = SDT;
                dh.HTTT = HTTT;
                dh.NgayDH = NgayDHdt;
                dh.TrinhTrang = "Đang xử lý";
                dh.MaKH = MaKH;
                db.DonDatHang.Add(dh);
                db.SaveChanges();
            }
            ViewBag.SDT = SDT;
            ViewBag.MaDH = MaDH;
            return View();
        }
        public ActionResult iPhone()
        {
            var SanPhamIP = db.SanPham.Where(x => x.MaLoaiSP == "1");
            return View(SanPhamIP.ToList());
        }
        public ActionResult iPad()
        {
            var SanPhamIP = db.SanPham.Where(x => x.MaLoaiSP == "3");
            return View(SanPhamIP.ToList());
        }
        public ActionResult Mac()
        {
            var SanPhamIP = db.SanPham.Where(x => x.MaLoaiSP == "2");
            return View(SanPhamIP.ToList());
        }
        public ActionResult Watch()
        {
            var SanPhamIP = db.SanPham.Where(x => x.MaLoaiSP == "4");
            return View(SanPhamIP.ToList());
        }
    }
}