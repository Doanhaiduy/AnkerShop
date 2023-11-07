using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DATA;
using DATA.Entity;

namespace QLBH_AnkerShop.Controllers
{
    public class SanPhamController : Controller
    {

        // GET: SanPham/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mapSanPham map = new mapSanPham();
            var sp = map.GetChiTiet(id);
			if (sp == null)
            {
                return HttpNotFound();
            }
            ViewBag.sp = map.GetDanhMuc(sp.IdDanhMuc).Where(m=> m.Id != id).ToList();
			return View(sp);
        }
      
    }
}
