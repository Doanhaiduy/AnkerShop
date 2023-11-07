using DATA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
	public class mapSanPham
	{
		QLBH_AnkerEntities db = new QLBH_AnkerEntities();
		public List<SanPham> LoadDanhSach()
		{
			var danhSach = db.SanPhams.ToList();
		
			return danhSach;
		}
		public SanPham GetChiTiet(string id)
		{
			var doiTuong = db.SanPhams.Find(id);
			return doiTuong;
		}

		public void ThemMoi(SanPham sp)
		{
			string lastProductId = db.SanPhams.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();
			int lastProductNumber = int.Parse(lastProductId.Substring(2)); 
			int nextProductNumber = lastProductNumber + 1;
			string newProductId = "SP" + nextProductNumber.ToString("D3"); 
			sp.Id = newProductId;
			sp.NgayNhap = DateTime.Now;
			// thêm vào db
			db.SanPhams.Add(sp);
			// lưu vào db
			db.SaveChanges();
		}

		public void Xoa(string id)
		{
			SanPham sanPham = db.SanPhams.Find(id);
			db.SanPhams.Remove(sanPham);
			db.SaveChanges();
		}

		public bool CapNhat(SanPham model)
		{
			var sp = db.SanPhams.Find(model.Id);
			if(sp == null)
			{
				return false;
			}
			if(model.Anh != null)
			{
				sp.Anh = model.Anh;
			}
			sp.TenSP = model.TenSP;
			sp.MoTa = model.MoTa;
			sp.Gia = model.Gia;
			sp.SoLuong = model.SoLuong;
			sp.IdDanhMuc = model.IdDanhMuc;
			//sp.Anh = model.Anh;
			db.SaveChanges();
			return true;
		}

		public List<SanPham> GetDanhMuc(string IdDanhMuc) {
			var sp = db.SanPhams.Where(m => m.IdDanhMuc == IdDanhMuc).ToList();
			return sp;
		}
	}
}
