using WebAPICRUD.Enums;
using WebAPICRUD.Services.Interfaces;

namespace WebAPICRUD.Services.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        private readonly IEnumerable<IVehicleService> Services;
        public VehicleFactory(IEnumerable<IVehicleService> services)
        {
            Services = services;
        }

        public IVehicleService GetVehicle(Vehicles vehicles)
        {
            return Services.First(s=>s.vehicles == vehicles);
        }
    }
}
