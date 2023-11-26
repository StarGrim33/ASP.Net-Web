using Diamond_Cleaning.Models;

namespace Diamond_Cleaning.Interfaces
{
    public interface IServicesRepository
    {
        List<Service> GetServices();

        Service? TryGetService(int id);
    }
}