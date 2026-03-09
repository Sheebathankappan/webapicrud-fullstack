using WebAPICRUD.Enums;
using WebAPICRUD.Services.Interfaces;

namespace WebAPICRUD.Services.Implementations
{
    public class CardPay : IPaymentMethods
    {

        public PaymentMode paymentMode => PaymentMode.Card;

        public string DoPay(string message)
        {
            return "Card :" + message;
        }
    }
}
