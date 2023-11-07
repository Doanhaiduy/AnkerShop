using QLBH_AnkerShop.App_Start;
using DATA;
using DATA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_AnkerShop.Controllers
{

	public class ThanhToanController : Controller
    {
		KhachHang user = SessionConfig.GetUser();
		// GET: ThanhToan

		[RoleUser]
		public ActionResult Buoc1(string GhiChuDonHang)
        {
            mapKhachHang map = new mapKhachHang();
			mapGioHang mapGH = new mapGioHang();
            var kh = map.GetChiTiet(user.Id);
			ViewBag.dsSP = mapGH.GetSanPhamGioHang(mapGH.GetGioHang(kh.Id).Id);
			ViewBag.Tong = mapGH.GetGioHang(user.Id).TongTien;
			ViewBag.GhiChuDonHang = GhiChuDonHang;
			return View(kh);
        }

		[RoleUser]
		[HttpPost]
		public ActionResult Buoc1(DonHang model)
		{

			return RedirectToAction("Buoc2", model);
		}

		[RoleUser]
		public ActionResult Buoc2()
		{
			mapKhachHang map = new mapKhachHang();
			mapGioHang mapGH = new mapGioHang();
			mapDonHang mapDH = new mapDonHang();
			var kh = map.GetChiTiet(user.Id);
			ViewBag.PT = mapDH.GetPhuongThuc();
			ViewBag.dsSP = mapGH.GetSanPhamGioHang(mapGH.GetGioHang(kh.Id).Id);
			ViewBag.Tong = mapGH.GetGioHang(user.Id).TongTien;
			return View();
		}

		[RoleUser]
		[HttpPost]
		public ActionResult Buoc2(string idPT, DonHang model)
		{
			mapKhachHang map = new mapKhachHang();
			mapGioHang mapGH = new mapGioHang();
			mapDonHang mapDH = new mapDonHang();
			mapDH.ThemDonHang(user.Id, mapGH.GetGioHang(user.Id).Id,idPT,model.DienThoai, model.Ten, model.GhiChuDonHang, model.DiaChi);
			return RedirectToAction("ThanhToanThanhCong");
		}

		[RoleUser]
		public ActionResult ThanhToanThanhCong()
		{
			return View();
		}
	}
}