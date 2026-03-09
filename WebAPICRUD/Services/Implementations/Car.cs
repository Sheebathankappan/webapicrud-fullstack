using WebAPICRUD.Enums;
using WebAPICRUD.Services.Interfaces;

namespace WebAPICRUD.Services.Implementations
{
    public class Car : IVehicleService
    {
        public Vehicles vehicles =>Vehicles.car;

        public string ChooseVehicle(string message)
        {
            return "car " + message;
        }
    }
}
