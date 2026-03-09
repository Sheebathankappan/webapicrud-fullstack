using WebAPICRUD.Enums;
namespace WebAPICRUD.Services.Interfaces
{
    public interface IPaymentFactory
    {
        IPaymentMethods GetPayMode(PaymentMode paymentMode);
    }
}
