using WebAPICRUD.Enums;
using WebAPICRUD.Services.Interfaces;

namespace WebAPICRUD.Services.Implementations
{
    public class Jeep:IVehicleService
    {
        public Vehicles vehicles => Vehicles.jeep;

        public string ChooseVehicle(string message)
        {
            return message+"Jeep";
        }
    }
}
