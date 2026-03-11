using WebAPICRUD.Enums;

namespace WebAPICRUD.Services.Interfaces
{
    public interface IPaymentFactory
    {
        IPaymentService GetPay(PaymentMode paymentMode);
    }
}
