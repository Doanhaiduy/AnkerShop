using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_AnkerShop.App_Start
{
	public class RoleUser : AuthorizeAttribute
	{
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			var User = SessionConfig.GetUser();
			if (User == null)
			{
				//filterContext.HttpContext.Session["ReturnUrlUser"] = filterContext.HttpContext.Request.Url.PathAndQuery;
				// Điều hướng về trang đăng nhập
				filterContext.Result = new RedirectToRouteResult(
					new System.Web.Routing.RouteValueDictionary(new
					{
						Controller = "Home",
						Action = "Login",
					}));
				return;
			}

			return;
		}
	}
}