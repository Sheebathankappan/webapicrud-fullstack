using WebAPICRUD.Enums;

namespace WebAPICRUD.Services.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicleService GetVehicle(Vehicles vehicles);
    }
}
