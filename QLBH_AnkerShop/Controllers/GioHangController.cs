using QLBH_AnkerShop.App_Start;
using DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using DATA.Entity;

namespace QLBH_AnkerShop.Controllers
{
    public class GioHangController : Controller
    {
		// GET: GioHang
		KhachHang user = SessionConfig.GetUser();
		[RoleUser]
		public ActionResult Index()
        {
            mapGioHang map = new mapGioHang();
            var GioHang = map.GetGioHang(user.Id);
            ViewBag.dsSP = map.GetSanPhamGioHang(GioHang.Id);
			return View(GioHang);
        }

		[RoleUser]
		[HttpPost]
		public ActionResult ThemVaoGioHang(string idSP, int SoLuong)
		{
			mapGioHang map = new mapGioHang();
			map.ThemVaoGioHang(map.GetGioHang(user.Id).Id, idSP, SoLuong);
			return RedirectToAction("Index");
		}

		[RoleUser]
		[HttpPost]
		public ActionResult XoaSanPham(string idSP)
		{
			mapGioHang map = new mapGioHang();
			if(map.XoaSanPham(map.GetGioHang(user.Id).Id, idSP))
			{
				return RedirectToAction("Index");

			}
			return RedirectToAction("index", "home");

		}
	}
}