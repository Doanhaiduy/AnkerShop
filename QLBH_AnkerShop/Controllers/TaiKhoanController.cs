using DATA;
using QLBH_AnkerShop.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_AnkerShop.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        [RoleUser]
        public ActionResult CaiDat()
        {
            mapKhachHang map = new mapKhachHang();
            var user = SessionConfig.GetUser();
            return View(map.GetChiTiet(user.Id));
        }

        [RoleUser]
        [HttpPost]
		public ActionResult CaiDat(string ho,string ten, string diaChi, string tp, string tinh, string quocGia, bool gioiTinh, string sdt, DateTime ngaySinh)
		{
			mapKhachHang map = new mapKhachHang();
			mapTaiKhoan maptk = new mapTaiKhoan();
			var user = SessionConfig.GetUser();
            var userCurrent = map.GetChiTiet(user.Id);
			userCurrent.Ho = ho;
			userCurrent.Ten = ten;
			userCurrent.DiaChi = diaChi + ", " + tp + ", " + tinh + ", " + quocGia;
            userCurrent.GioiTinh = gioiTinh;
            userCurrent.Sdt = sdt;
            userCurrent.Sdt = sdt;
            userCurrent.NgaySinh = ngaySinh;    
			maptk.CapNhatTaiKhoan(user.Id, userCurrent);
			return View(userCurrent);
		}
	}
}