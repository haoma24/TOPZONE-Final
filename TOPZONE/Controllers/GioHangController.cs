using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.Pkcs;
using System.Web;
using System.Web.Mvc;
using TOPZONE.Models;

namespace TOPZONE.Controllers
{
    public class GioHangController : Controller
    {
        private TopzoneEntities de = new TopzoneEntities();
        
        // GET: GioHang
        public ActionResult GioHang()
        {
            return View();
        }
        private int isExisting (int id)
        {
            List<GioHangModel> cart = (List<GioHangModel>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            
                if (cart[i].Item.MaSP == id.ToString())
                    return i;
                return -1;
            
        }
        public ActionResult Delete(string id)
        {
            
            List<GioHangModel> cart = (List<GioHangModel>)Session["cart"];
            for (int i = 0;i<cart.Count;i++)
            {
                if (cart[i].Item.MaSP.Trim() == id)
                {
                cart.RemoveAt(i);
                }
            }

            Session["cart"] = cart; // Update Session["cart"]

            return RedirectToAction("GioHang", "GioHang");
        }
       
        public ActionResult AddToCart(int id)
        {
            if (Session["cart"] == null)
            {
                List<GioHangModel> cart = new List<GioHangModel>();

                cart.Add(new GioHangModel(de.SanPham.Find(id.ToString()), 1)); // Add 1 Product based on id provided

                Session["cart"] = cart; // Update Session["cart"]
            }
            else
            {
                List<GioHangModel> cart = (List<GioHangModel>)Session["cart"];

                for (int i = 0; i < cart.Count; i++)
                {
                    if (cart[i].Item.MaSP.Trim() == id.ToString())
                    {
                        cart[i].Quantity++;
                        cart[i].Price = (double)(cart[i].Item.GiaBan * cart[i].Quantity);
                        goto kt;
                    }
                }
                cart.Add(new GioHangModel(de.SanPham.Find(id.ToString()), 1));
            kt:    Session["cart"] = cart; // Update Session["cart"]
            }

            return RedirectToAction("Index", "Home");
        }
        public ActionResult PlusItem(int id)
        {
                List<GioHangModel> cart = (List<GioHangModel>)Session["cart"];
                for (int i = 0; i < cart.Count; i++)
                {
                    if (cart[i].Item.MaSP.Trim() == id.ToString())
                    {
                        cart[i].Quantity++;
                        cart[i].Price = (double)(cart[i].Item.GiaBan * cart[i].Quantity);
                        goto kt;
                    }
                }
                cart.Add(new GioHangModel(de.SanPham.Find(id.ToString()), 1));
            kt: Session["cart"] = cart; // Update Session["cart"]

            return RedirectToAction("GioHang", "GioHang");
        }

        public ActionResult MinusItem(int id)
        {
            List<GioHangModel> cart = (List<GioHangModel>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Item.MaSP.Trim() == id.ToString())
                {
                    if (cart[i].Quantity==0)
                        goto kt;
                    cart[i].Quantity--;
                    cart[i].Price = (double)(cart[i].Item.GiaBan * cart[i].Quantity);
                    goto kt2;
                }
            }
            cart.Add(new GioHangModel(de.SanPham.Find(id.ToString()), 1));
        kt: Session["cart"] = null; // Update Session["cart"]

        kt2:    return RedirectToAction("GioHang", "GioHang");
        }
    }
}