using WebAPICRUD.Enums;
using WebAPICRUD.Services.Interfaces;

namespace WebAPICRUD.Services.Implementations
{
    public class UPIPay : IPaymentService
    {
        public PaymentMode paymentMode => PaymentMode.UPI;

        public string DoPay(string message)
        {
            return message + "UPI";
        }
    }
}
