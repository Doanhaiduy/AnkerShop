using DATA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
	public class mapKhachHang
	{
		QLBH_AnkerEntities db = new QLBH_AnkerEntities();
		// Lấy dữ liệu khách hàng: 
		public List<KhachHang> LoadDanhSach()
		{
			//kết nối 
			// lấy danh sách từ bảng
			var danhSach = db.KhachHangs.ToList();
			//var danhSach2 = db.KhachHangs.Where(m => m.Ten == "Duy").ToList();
			// Lấy 1 đối tượng
			//var doiTuong = db.KhachHangs.Find("KH001");
			//var doiTuong2 = db.KhachHangs.SingleOrDefault( m => m.Id == "KH001");
			//var doiTuong3 = db.KhachHangs.FirstOrDefault( m => m.Id == "KH001");
			return danhSach;
		}
		public KhachHang GetChiTiet(string id)
		{
			var doiTuong = db.KhachHangs.Find(id);
			return doiTuong;
		}
	}
}
