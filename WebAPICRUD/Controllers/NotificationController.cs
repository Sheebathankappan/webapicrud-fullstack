using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICRUD.Services.Interfaces;
using WebAPICRUD.Models;

namespace WebAPICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationFactory _factory;
        private readonly IPaymentFactory _paymentFactory;
        private readonly IVehicleFactory _vehicleFactory;

        public NotificationController(INotificationFactory factory,
            IPaymentFactory paymentFactory, 
            IVehicleFactory vehicleFactory)
        {
            _factory = factory;
            _paymentFactory = paymentFactory;
            _vehicleFactory = vehicleFactory;
        }

        [HttpPost]
        public IActionResult SendNotification([FromBody] NotificationRequest request)
        {
            var service = _factory.GetService(request.UserType);
            var result=service.Send(request.Message);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get([FromBody] PaymentDetails pay)
        {
            var mode = _paymentFactory.GetPayMode(pay.paymentMode);
            return Ok(mode.DoPay(pay.message));
        }

        [HttpGet("Vehicle")]
        public IActionResult GetVehicle([FromBody] VehicleManage vehicle)
        {
            var vehicletye = _vehicleFactory.GetVehicle(vehicle.vehicles);
            return Ok(vehicletye.ChooseVehicle(vehicle.message));
        }

    }
}
