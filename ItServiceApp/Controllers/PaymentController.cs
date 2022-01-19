using ItServiceApp.Extensions;
using ItServiceApp.Models.Payment;
using ItServiceApp.Services;
using ItServiceApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ItServiceApp.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public IActionResult Index()
        {
            //var result = _paymentService.CheckInstallments("5311570000000005", 1000);
            return View();
        }
        [HttpPost]
        public IActionResult CheckInstallment(string binNumber, decimal price)
        {
            var result = _paymentService.CheckInstallments(binNumber, price);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Index(PaymentViewModel model)
        {
            var paymentModel = new PaymentModel()
            {
                Installment = model.Installment,
                Address = new AddressModel(),
                BasketList = new List<BasketModel>(),
                Customer = new CustomerModel(),
                CardModel = new CardModel(),
                Price = 1000,
                UserId = HttpContext.GetUserId(),
                Ip = Request.HttpContext.Connection.RemoteIpAddress?.ToString()

            };
            var installmentInfo = _paymentService.CheckInstallments(paymentModel.CardModel.CardNumber, paymentModel.Price);
            var installmentNumber = installmentInfo.InstallmentPrices.FirstOrDefault(x => x.InstallmentNumber == model.Installment);
            paymentModel.PaidPrice = decimal.Parse(installmentNumber != null ? installmentNumber.TotalPrice.Replace('.', ',') : installmentInfo.InstallmentPrices[0].TotalPrice.Replace(".", ","));

            var result = _paymentService.Pay(paymentModel);
            return View();
        }
    }
}
