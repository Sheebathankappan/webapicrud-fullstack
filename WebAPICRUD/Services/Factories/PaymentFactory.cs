using WebAPICRUD.Enums;
using WebAPICRUD.Services.Interfaces;

namespace WebAPICRUD.Services.Factories
{
    public class PaymentFactory : IPaymentFactory
    {
        private readonly IEnumerable<IPaymentMethods> _paymentMethods;

        public PaymentFactory(IEnumerable<IPaymentMethods> paymentMethods)
        {
            _paymentMethods = paymentMethods;
        }

        public IPaymentMethods GetPayMode(PaymentMode paymentMode)
        {
            return _paymentMethods.First(s => s.paymentMode == paymentMode);
        }
    }
}
