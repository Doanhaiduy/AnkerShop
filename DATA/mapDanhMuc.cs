using DATA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
	public class mapDanhMuc
	{

		QLBH_AnkerEntities db = new QLBH_AnkerEntities();
		public List<DanhMuc> LoadDanhSach()
		{
			var danhSach = db.DanhMucs.ToList();
	
			return danhSach;
		}
		
	}
}
