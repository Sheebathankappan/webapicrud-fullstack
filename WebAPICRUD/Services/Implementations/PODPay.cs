using WebAPICRUD.Enums;
using WebAPICRUD.Services.Interfaces;

namespace WebAPICRUD.Services.Implementations
{
    public class PODPay:IPaymentService
    {
        public PaymentMode paymentMode => PaymentMode.POD;

        public string DoPay(string message)
        {
            return message + "POD";
        }
    }
}
