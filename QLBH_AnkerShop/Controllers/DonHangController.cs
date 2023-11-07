using DATA;
using DATA.Entity;
using QLBH_AnkerShop.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QLBH_AnkerShop.Controllers
{
    public class DonHangController : Controller
    {
		// GET: DonHang
		KhachHang user = SessionConfig.GetUser();
		[RoleUser]
		public ActionResult Index()
        {
			mapDonHang map = new mapDonHang();
			return View(map.DanhSach().Where(m => m.IdKH == user.Id).ToList());
		}

		// GET: DonHang/Details/5
		public ActionResult Details(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			mapDonHang map = new mapDonHang();
			var dh = map.GetChiTiet(id);
			if (dh == null)
			{
				return HttpNotFound();
			}
			return View(dh);
		}
	}
}