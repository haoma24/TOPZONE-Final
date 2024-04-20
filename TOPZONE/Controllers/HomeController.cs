using System;
using System.Collections.Generic;
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
            string MaDH = "DH" + DateTime.Now.ToString("yyMMmmss");
            ViewBag.MaDH = MaDH;
            ViewBag.TenKH = form["TenKH"];
            ViewBag.SDT = form["SDT"];
            ViewBag.HTTT = form["rbtnHTTT"];
            ViewBag.DiaChi = form["txtSoNha"] + ", " + form["ddlP"] + ", " + form["ddlQ"] + ", " + form["ddlTP"];
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