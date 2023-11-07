using DATA;
using QLBH_AnkerShop.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_AnkerShop.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
		int currentDate = Convert.ToInt32(DateTime.Now.Month);

		// GET: Admin/Home
		[RoleAdmin]
        public ActionResult Index(int thang = 0)
        {

			mapThongKe maptk = new mapThongKe();
			if(thang == 0)
			{
				ViewBag.tk = maptk.getThongKe(currentDate);
				ViewBag.thang = currentDate;
			}
			else
			{
				ViewBag.tk = maptk.getThongKe(thang);
				ViewBag.thang = thang;
			}
			mapKhachHang map = new mapKhachHang();
			var ds = map.LoadDanhSach();
			return View(ds);
        }



		[RoleAdmin]
		public ActionResult Lich()
		{
			return View();
		}
	}
}