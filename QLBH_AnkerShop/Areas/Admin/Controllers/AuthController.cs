using DATA;
using QLBH_AnkerShop.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_AnkerShop.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
		// GET: Admin/Auth
		public ActionResult Login()
		{
			var admin = SessionConfig.GetAdmin();
			if (admin != null)
			{
				return RedirectToAction("Index", "Home");
			}

			return View();
		}

		[HttpPost]
		public ActionResult Login(string username, string password)
		{
			string returnUrl = Session["ReturnUrlAdmin"] as string;
			mapTaiKhoan map = new mapTaiKhoan();
			var user = map.TimKiemAdmin(username, password);
			if (user != null)
			{
				SessionConfig.SetAdmin(user);
				//if (!string.IsNullOrEmpty(returnUrl))
				//{
				//	// Clear the stored return URL from the session
				//	Session.Remove("ReturnUrlAdmin");
				//	//if(returnUrl == "https://localhost:44310/GioHang/ThemVaoGioHang")
				//	//{
				//	//	return Redirect("index");

				//	//}
				//	return Redirect(returnUrl);
				//}
				//else
				//{
				//	return RedirectToAction("Index", "Home", new { area = "Admin" });
				//	//return Redirect("/Admin/home/index");
				//}
					return RedirectToAction("Index", "Home", new { area = "Admin" });

			}
			ViewBag.error = "Tên đăng nhập hoặc mật khẩu không đúng";
			return View();
		}

		public ActionResult Logout()
		{
			SessionConfig.SetAdmin(null);
			return RedirectToAction("Login", "Auth");
		}
	}
}