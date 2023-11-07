using DATA;
using DATA.Entity;
using QLBH_AnkerShop.App_Start;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_AnkerShop.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
		// GET: Admin/Product
		[RoleAdmin]

		public ActionResult DanhSach()
        {
			
			var map = new mapSanPham();
            var sp = map.LoadDanhSach();
			return View(sp);
        }

		[RoleAdmin]
		public ActionResult ThemMoi()
		{
			
			return View();
		}

		[RoleAdmin]
		[HttpPost]
		public ActionResult ThemMoi(SanPham sp, HttpPostedFileBase fileUpload)
		{

			var map = new mapSanPham();
			if (fileUpload != null)
			{
				if (fileUpload.ContentLength > 0)
				{
					// lưu 
					// 1. xác định thư mục lưu: assets\imgs\product\
					string folder = "/images/product/";
					// 2. xác định tên file
					string fileName = fileUpload.FileName;
					// 3. xác định đường dẫn tuyệt đối của file
					string pathAbsolute = Server.MapPath(folder + fileName);
					// 4. Kiêm tra tồn tại file có tồn tại file cũ
					// xóa
					//if(System.IO.File.Exists(pathAbsolute) == true)
					//{
					//	System.IO.File.Delete(pathAbsolute);
					//}
					// tăng đuôi thêm 1
					int i = 0;
					string name = Path.GetFileNameWithoutExtension(fileName);
					string ext = Path.GetExtension(fileName);
					while (System.IO.File.Exists(pathAbsolute) == true)
					{
						i++;

						fileName = name + "_" + i + ext;
						pathAbsolute = Server.MapPath(folder + fileName);
					}

					// 5. Lưu
					fileUpload.SaveAs(pathAbsolute);
					sp.Anh = folder + fileName;
				}
			}

			map.ThemMoi(sp);
			return Redirect("danhsach");
		}

		[RoleAdmin]
		public ActionResult Xoa(string Id)
		{
			
			var map = new mapSanPham();
			var sp = map.GetChiTiet(Id);
			return View(sp);
		}

		[RoleAdmin]
		[HttpPost, ActionName("Xoa")]
		public ActionResult XacNhanXoa(string Id)
		{
			
			var map = new mapSanPham();
			map.Xoa(Id);
			return RedirectToAction("danhsach");
		}

		[RoleAdmin]
		public ActionResult CapNhat(string Id)
		{

		
			var sp = new mapSanPham().GetChiTiet(Id);
			return View(sp);
		}

		[RoleAdmin]
		[HttpPost]
		public ActionResult CapNhat(SanPham sp, HttpPostedFileBase fileUpload)
		{

			var map = new mapSanPham();

			// 1.Kiểm tra tồn tại: người dùng có đưa file lên không ( check null, length)
			if (fileUpload != null)
			{
				if(fileUpload.ContentLength > 0)
				{
					// lưu 
					// 1. xác định thư mục lưu: assets\imgs\product\
					string folder = "/images/product/";
					// 2. xác định tên file
					string fileName = fileUpload.FileName;
					// 3. xác định đường dẫn tuyệt đối của file
					string pathAbsolute = Server.MapPath(folder + fileName);
					// 4. Kiêm tra tồn tại file có tồn tại file cũ
					// xóa
					//if(System.IO.File.Exists(pathAbsolute) == true)
					//{
					//	System.IO.File.Delete(pathAbsolute);
					//}
					// tăng đuôi thêm 1
					int i = 0;
					string name = Path.GetFileNameWithoutExtension(fileName);
					string ext = Path.GetExtension(fileName);
					while (System.IO.File.Exists(pathAbsolute) == true)
					{
						i++;

						fileName = name + "_" + i + ext;
						pathAbsolute = Server.MapPath(folder + fileName);
					}
					
					// 5. Lưu
					fileUpload.SaveAs(pathAbsolute);
					sp.Anh = folder + fileName;
				}
			}
			if (map.CapNhat(sp) == true)
			{
				return RedirectToAction("danhsach");
			}
			else
			{
				return View(sp);
			}
		}
	}
}