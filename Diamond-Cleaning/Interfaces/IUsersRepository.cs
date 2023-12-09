using Diamond_Cleaning.Models;

namespace Diamond_Cleaning.Interfaces
{
    public interface IUsersRepository
    {
        List<User> GetAll();

        User TryGetById(Guid userId);

        User TryGetByName(string name);

        void Delete(Guid userId);

        void Add(User user);

        void Edit(EditUser user, Guid userId);

        void ChangePassword(Guid userId, string password);

        void ChangeAccess(Guid userId, string roleName);
    }
}
