using DATA;
using QLBH_AnkerShop.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_AnkerShop.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
		// GET: Admin/DonHang
		[RoleAdmin]
		public ActionResult DanhSach(string selected)
        {
			mapDonHang map = new mapDonHang();
			var ds = map.DanhSach();
			ViewBag.Selected = selected;
			if (!string.IsNullOrEmpty(selected))
			{
				
				ds = ds.Where(x => x.TrangThai == selected).ToList();
				ViewBag.count = ds.Count;
				return View(ds);

			}
			return View(ds);
        }

	

		[RoleAdmin]
		public ActionResult ChiTietDonHang(string id)
        {
            mapDonHang map = new mapDonHang();
            
            return View(map.GetChiTiet(id));
        }

		[RoleAdmin]
		public ActionResult XoaDonHang()
		{
			return View();
		}

		[RoleAdmin]
		[HttpPost]
		public ActionResult XoaDonHang(string id)
		{
			mapDonHang map = new mapDonHang();
			map.XoaDonHang(id);
			return RedirectToAction("Danhsach","donhang");
		}

		[RoleAdmin]
		public ActionResult XacNhanGiao(string id)
		{
			mapDonHang map =new mapDonHang();
			map.SetTrangThaiDonHang(id);
			return Redirect("/admin/DonHang/danhsach");
		}
	}
}