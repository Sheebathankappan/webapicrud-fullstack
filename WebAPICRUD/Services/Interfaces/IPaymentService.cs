using WebAPICRUD.Enums;

namespace WebAPICRUD.Services.Interfaces
{
    public interface IPaymentService
    {
        PaymentMode paymentMode { get; }

        string DoPay(string message);
    }
}
