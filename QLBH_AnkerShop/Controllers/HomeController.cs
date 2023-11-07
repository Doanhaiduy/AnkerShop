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
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			mapSanPham map = new mapSanPham();
			return View(map.LoadDanhSach());
		}
		public ActionResult Login()
		{
			var userSS = SessionConfig.GetUser();
			if (userSS != null)
			{
				return RedirectToAction("Index", "Home");
			}

			return View();
		}

		[HttpPost]
		public ActionResult Login(string username, string password)
		{
			string returnUrl = Session["ReturnUrlUser"] as string;
			var userSS = SessionConfig.GetUser();

			
			if (userSS != null)
			{
				//if (!string.IsNullOrEmpty(returnUrl))
				//{
				//	// Clear the stored return URL from the session
				//	Session.Remove("ReturnUrlUser");
				//	return Redirect(returnUrl);
				//}
				//else
				//{
				//	return RedirectToAction("index", "Home");
				//	//return Redirect("/home/index");
				//}
				return RedirectToAction("Index", "Home");
			}
			mapTaiKhoan map = new mapTaiKhoan();
			var user = map.TimKiemKhachHang(username, password);
			if (user != null)
			{
				SessionConfig.SetUser(user);
				//if (!string.IsNullOrEmpty(returnUrl))
				//{
				//	// Clear the stored return URL from the session
				//	Session.Remove("ReturnUrlUser");
				//	return Redirect(returnUrl);
				//}
				//else
				//{
				//	return RedirectToAction("index", "Home");
				//	//return Redirect("/home/index");
				//}
				return RedirectToAction("index", "Home");
			}
			ViewBag.error = "Tên đăng nhập hoặc mật khẩu không đúng";
			ViewBag.username = username;
			return View();
		}

		public ActionResult Register()
		{
			var userSS = SessionConfig.GetUser();
			if (userSS != null)
			{
				return RedirectToAction("Index", "Home");
			}
			return View();
		}

		[HttpPost]
		public ActionResult Register(KhachHang kh)
		{
			var userSS = SessionConfig.GetUser();
			if (userSS != null)
			{
				return RedirectToAction("Index", "Home");
			}
			ViewBag.Ho = kh.Ho;
			ViewBag.Ten = kh.Ten;
			ViewBag.TaiKhoan = kh.TaiKhoan;
			ViewBag.MatKhau = kh.MatKhau;
			mapTaiKhoan map = new mapTaiKhoan();
			if (map.Themmoi(kh) == true)
			{
				return RedirectToAction("login");
			}
			else
			{
				ViewBag.error = "Email đã tồn tại trong hệ thống!";
				return View(kh);
			}
		}
		public ActionResult Logout()
		{
			SessionConfig.SetUser(null);
			return RedirectToAction("Login", "Home");
		}
		public ActionResult TimKiem(string TuKhoa)
		{
			mapSanPham map = new mapSanPham();
			List<SanPham> ketqua = new List<SanPham>();

			if (!string.IsNullOrEmpty(TuKhoa))
			{
				ketqua = map.LoadDanhSach().Where(m => m.TenSP.ToLower().Contains(TuKhoa.ToLower())).ToList();
			}

			ViewBag.TuKhoa = TuKhoa;

			if (ketqua.Count == 0) 
			{
				ViewBag.noti = "Không có kết quả phù hợp với từ khóa " +"\"" + TuKhoa+ "\"";
			}
			return View(ketqua); 
		}

		public ActionResult DanhMuc(string idDanhMuc)
		{
			mapDanhMuc map = new mapDanhMuc();
			mapSanPham mapSP = new mapSanPham();
			ViewBag.danhMuc = map.LoadDanhSach();
			ViewBag.luachon = idDanhMuc;
			if (string.IsNullOrEmpty(idDanhMuc))
			{
				return View(mapSP.LoadDanhSach());

			}
			else
			{
				return View(mapSP.LoadDanhSach().Where(m => m.IdDanhMuc == idDanhMuc).ToList());
			}
		}
		

	}
}