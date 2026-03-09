using WebAPICRUD.Enums;
using WebAPICRUD.Services.Interfaces;

namespace WebAPICRUD.Services.Implementations
{
    public class UPIPay : IPaymentMethods
    {
        public PaymentMode paymentMode => PaymentMode.UPI;
        public string DoPay(string message)
        {
            return "UPI :" + message;
        }
    }
}
