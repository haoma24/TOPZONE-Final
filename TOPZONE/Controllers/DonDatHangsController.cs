using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TOPZONE;

namespace TOPZONE.Controllers
{
    public class DonDatHangsController : Controller
    {
        private TopzoneEntities db = new TopzoneEntities();

        // GET: DonDatHangs
        public ActionResult Index()
        {
            var donDatHang = db.DonDatHang.Include(d => d.KhachHang);
            return View(donDatHang.ToList());
        }

        // GET: DonDatHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHang donDatHang = db.DonDatHang.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }
            return View(donDatHang);
        }

        // GET: DonDatHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH");
            return View();
        }

        // POST: DonDatHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,MaKH,NgayDH,TriGia,TenNguoiNhan,DiaChiNhan,SDTNguoiNhan,HTTT,TrinhTrang")] DonDatHang donDatHang)
        {
            string MaDH = DateTime.Now.ToString("yyMMddhhm");
            string NgayDH = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime dt = DateTime.ParseExact(NgayDH, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            donDatHang.MaDH = MaDH;
            donDatHang.NgayDH = dt;
            if (ModelState.IsValid)
            {
                db.DonDatHang.Add(donDatHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH", donDatHang.MaKH);
            return View(donDatHang);
        }

        // GET: DonDatHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHang donDatHang = db.DonDatHang.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH", donDatHang.MaKH);
            return View(donDatHang);
        }

        // POST: DonDatHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDH,MaKH,NgayDH,TriGia,TenNguoiNhan,DiaChiNhan,SDTNguoiNhan,HTTT,TrinhTrang")] DonDatHang donDatHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donDatHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH", donDatHang.MaKH);
            return View(donDatHang);
        }

        // GET: DonDatHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHang donDatHang = db.DonDatHang.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }
            return View(donDatHang);
        }

        // POST: DonDatHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DonDatHang donDatHang = db.DonDatHang.Find(id);
            db.DonDatHang.Remove(donDatHang);
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
