using WebAPICRUD.Enums;

namespace WebAPICRUD.Services.Interfaces
{
    public interface IPaymentMethods
    {
        public PaymentMode paymentMode {  get; }
        string DoPay(string message );
    }
}
