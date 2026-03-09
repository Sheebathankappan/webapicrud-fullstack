using WebAPICRUD.Enums;

namespace WebAPICRUD.Services.Interfaces
{
    public interface IVehicleService
    {
        Vehicles vehicles { get; }
        string ChooseVehicle(string message);

    }
}
