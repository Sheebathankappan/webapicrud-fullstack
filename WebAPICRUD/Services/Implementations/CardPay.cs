using WebAPICRUD.Enums;
using WebAPICRUD.Services.Interfaces;

namespace WebAPICRUD.Services.Implementations
{
    public class CardPay:IPaymentService
    {
        public PaymentMode paymentMode => PaymentMode.Card;

        public string DoPay(string message)
        {
            return message + "Card";
        }
    }
}
