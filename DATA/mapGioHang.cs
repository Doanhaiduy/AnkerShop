using DATA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
	public class mapGioHang
	{
		QLBH_AnkerEntities db = new QLBH_AnkerEntities();
		public GioHang GetGioHang(string id)
		{
			var gh = db.GioHangs.FirstOrDefault(m => m.IdKH == id);
			if(gh == null)
			{
				GioHang newgh = new GioHang();
				string numberUser =id.Substring(2); // Lấy số sau "KH"
				newgh.Id = "GH" + numberUser;
				newgh.IdKH = id;
				newgh.NgayCapNhat = DateTime.Now;
				newgh.TongTien = 0;
				db.GioHangs.Add(newgh);
				db.SaveChanges();
				return newgh;
			}	
			return gh;
		}
		public List<SanPhamGioHang> GetSanPhamGioHang(string id)
		{
			var ds = db.SanPhamGioHangs.Where(m=> m.IdGH == id).ToList();
			return ds;

		}

		public void ThemVaoGioHang( string idGH, string idSP, int SoLuong )
		{
			
			var spGH = new SanPhamGioHang();
			var sp = db.SanPhamGioHangs.FirstOrDefault(m => m.IdSP == idSP & m.IdGH == idGH);
			if (sp == null)
			{
				spGH.IdGH = idGH;
				spGH.IdSP = idSP;
				spGH.SoLuong = SoLuong;
				spGH.Gia = db.SanPhams.Find(idSP).Gia * SoLuong;
				spGH.NgayThem = DateTime.Now;
				// thêm vào db
				db.SanPhamGioHangs.Add(spGH);
				// lưu vào db
				db.SaveChanges();
				var giohang = db.GioHangs.SingleOrDefault(m => m.Id == idGH);
				giohang.TongTien = GetSanPhamGioHang(idGH).Sum(m => m.SanPham.Gia * m.SoLuong);
				giohang.NgayCapNhat = DateTime.Now;
				db.SaveChanges();

			}
			else
			{
				sp.SoLuong += SoLuong;
				sp.Gia = sp.SanPham.Gia * sp.SoLuong;
				sp.NgayThem = DateTime.Now;
				db.SaveChanges();
				var giohang = db.GioHangs.SingleOrDefault(m => m.Id == idGH);
				giohang.TongTien = GetSanPhamGioHang(idGH).Sum(m => m.SanPham.Gia * m.SoLuong);
				giohang.NgayCapNhat = DateTime.Now;
				db.SaveChanges();
			}

		}

		public bool XoaSanPham(string idGH, string idSP)
		{
			var sp = db.SanPhamGioHangs.FirstOrDefault(m => m.IdGH == idGH & m.IdSP == idSP);
			if(sp != null)
			{
				db.SanPhamGioHangs.Remove(sp);
				db.SaveChanges();
				var giohang = db.GioHangs.SingleOrDefault(m => m.Id == idGH);
				giohang.TongTien = GetSanPhamGioHang(idGH).Sum(m => m.SanPham.Gia * m.SoLuong);
				giohang.NgayCapNhat = DateTime.Now;
				db.SaveChanges();
				return true;
			}
			else
			{
				return false;
			}
			
		}

		public void XoaGioHang(string idGH)
		{
			var ListSanPhamXoa= db.SanPhamGioHangs.Where(m => m.IdGH == idGH).ToList();
			db.GioHangs.FirstOrDefault(m => m.Id == idGH).TongTien = 0;
			db.SanPhamGioHangs.RemoveRange(ListSanPhamXoa);
			db.SaveChanges();
		}
	}
}
