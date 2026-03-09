using WebAPICRUD.Enums;
using WebAPICRUD.Services.Interfaces;

namespace WebAPICRUD.Services.Implementations
{
    public class Bus : IVehicleService
    {
        public Vehicles vehicles => Vehicles.bus;

        public string ChooseVehicle(string message)
        {
            return "bus "+message;
        }
    }
}
