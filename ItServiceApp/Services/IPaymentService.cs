using ItServiceApp.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiceApp.Services
{
    public interface IPaymentService
    {
        InstallmentModel CheckInstallments(string binNumber,decimal price);
        PaymentResponseModel Pay(PaymentModel model);
    }
}
