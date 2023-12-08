using Diamond_Cleaning.Models;

namespace Diamond_Cleaning.Interfaces
{
    public interface IRolesRepository
    {
        void Add(Roles role);

        void Delete(Roles role);

        List<Roles> GetAll();
    }
}
