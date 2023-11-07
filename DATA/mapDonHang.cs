using DATA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
	public class mapDonHang
	{
		QLBH_AnkerEntities db = new QLBH_AnkerEntities();
		public List<DonHang> DanhSach()
		{
			return db.DonHangs.ToList();
		}
		public DonHang GetChiTiet(string id)
		{
			return db.DonHangs.Find(id);
		}

		public void ThemSanPhamDonHang(string idGH, string idDH)
		{

			var newDH = new DonHang();
			mapGioHang map = new mapGioHang();
			var dsSP = map.GetSanPhamGioHang(idGH);
			List<SanPhamDonHang> listSp = new List<SanPhamDonHang>();
			foreach (var sp in dsSP)
			{
				if(db.SanPhams.Find(sp.IdSP).SoLuong - sp.SoLuong < 0)
				{
					continue;  
				}
				db.SanPhams.Find(sp.IdSP).SoLuong = (int)(db.SanPhams.Find(sp.IdSP).SoLuong - sp.SoLuong);
				SanPhamDonHang spdh = new SanPhamDonHang();
				spdh.IdSP = sp.IdSP;
				spdh.IdDonHang = idDH;
				spdh.TenSP = sp.SanPham.TenSP;
				spdh.Anh = sp.SanPham.Anh;
				spdh.DanhMuc = sp.SanPham.DanhMuc.Ten;
				spdh.SoLuong = sp.SoLuong;
				spdh.Gia = sp.SanPham.Gia * sp.SoLuong;
				listSp.Add(spdh);
			}
			db.SanPhamDonHangs.AddRange(listSp);
			//db.SaveChanges();
		}
		public DonHang ThemDonHang(string idKH, string idGH, string idPT, string sdt, string ten, string ghiChu, string diaChi)
		{
			var newDH = new DonHang();
			mapGioHang map = new mapGioHang();
			string lastDHId = db.DonHangs.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();
			string newDHId;
			if (lastDHId == null)
			{
				newDHId = "DH001";
			}
			else
			{
				int lastDHNumber = int.Parse(lastDHId.Substring(2));
				int nextDHNumber = lastDHNumber + 1;
				newDHId = "DH" + nextDHNumber.ToString("D3");
			}
			ThemSanPhamDonHang(idGH, newDHId);
			newDH.Id = newDHId;
			newDH.IdKH = idKH;
			newDH.IdPT = idPT;
			newDH.Ten = ten;
			newDH.DienThoai = sdt;
			newDH.GhiChuDonHang = ghiChu;
			newDH.DiaChi = diaChi;
			newDH.TrangThai = "Đang giao";
			newDH.NgayTaoDon = DateTime.Now;
			newDH.TongTienThanhToan = db.GioHangs.FirstOrDefault(m => m.IdKH == idKH).TongTien + db.PhuongThucs.FirstOrDefault(m => m.Id == idPT).PhiVanChuyen;
			map.XoaGioHang(idGH);
			db.DonHangs.Add(newDH);
			db.SaveChanges();
			return newDH;
		}
		
		public List<PhuongThuc> GetPhuongThuc()
		{
			var dsPT = db.PhuongThucs.ToList();
			return dsPT;
		}

		public List<SanPhamDonHang> GetSanPhamDonHangs(string id) {
			var ds = db.SanPhamDonHangs.Where(m => m.IdDonHang == id).ToList();
			return ds;

		}

		public List<SanPhamDonHang> GetAllSanPhamDonHangs()
		{
			var ds = db.SanPhamDonHangs.ToList();
			return ds;

		}

		public void SetTrangThaiDonHang(string id)
		{
			var dh = db.DonHangs.Find(id);
			dh.TrangThai = "Đã giao";
			db.SaveChanges();
		}

		public void XoaDonHang(string id)
		{
			var dh = db.DonHangs.FirstOrDefault(m => m.Id == id);
			db.DonHangs.Remove(dh);
			db.SaveChanges();
		}
	}
}
