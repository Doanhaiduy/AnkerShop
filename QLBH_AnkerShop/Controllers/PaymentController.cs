using QLBH_AnkerShop.Models;
using QLBH_AnkerShop.Pay;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_AnkerShop.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

		//public ActionResult VnPayPayment()
		//{
		//	string vnp_Returnurl = ConfigurationManager.AppSettings["vnp_Returnurl"]; //URL nhan ket qua tra ve 
		//	string vnp_Url = ConfigurationManager.AppSettings["vnp_Url"]; //URL thanh toan cua VNPAY 
		//	string vnp_TmnCode = ConfigurationManager.AppSettings["vnp_TmnCode"]; //Ma định danh merchant kết nối (Terminal Id)
		//	string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"]; //Secret Key

		//	OrderInfo order = new OrderInfo();
		//	order.OrderId = DateTime.Now.Ticks; // Giả lập mã giao dịch hệ thống merchant gửi sang VNPAY
		//	order.Amount = 100000; // Giả lập số tiền thanh toán hệ thống merchant gửi sang VNPAY 100,000 VND
		//	order.Status = "0"; //0: Trạng thái thanh toán "chờ thanh toán" hoặc "Pending" khởi tạo giao dịch chưa có IPN
		//	order.CreatedDate = DateTime.Now;

		//	VnPayLibrary vnpay = new VnPayLibrary();

		//	vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
		//	vnpay.AddRequestData("vnp_Command", "pay");
		//	vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
		//	vnpay.AddRequestData("vnp_Amount", (order.Amount * 100).ToString()); //Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND (một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 10000000
		//	if (bankcode_Vnpayqr.Checked == true)
		//	{
		//		vnpay.AddRequestData("vnp_BankCode", "VNPAYQR");
		//	}
		//	else if (bankcode_Vnbank.Checked == true)
		//	{
		//		vnpay.AddRequestData("vnp_BankCode", "VNBANK");
		//	}
		//	else if (bankcode_Intcard.Checked == true)
		//	{
		//		vnpay.AddRequestData("vnp_BankCode", "INTCARD");
		//	}

		//}
	}
}