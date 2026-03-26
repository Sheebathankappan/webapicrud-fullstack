using WebAPICRUD.Enums;
using WebAPICRUD.Services.Interfaces;

namespace WebAPICRUD.Services.Factories
{
    public class PaymentFactory : IPaymentFactory
    {
        private readonly IEnumerable<IPaymentService> _services;
        public PaymentFactory(IEnumerable<IPaymentService> services)
        {
            _services = services;
        }

        public IPaymentService GetPay(PaymentMode paymentMode)
        {
            return _services.First(s=>s.paymentMode==paymentMode);
        }
    }
}
