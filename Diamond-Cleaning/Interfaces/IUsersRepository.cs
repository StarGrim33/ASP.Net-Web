using Diamond_Cleaning.Models;

namespace Diamond_Cleaning.Interfaces
{
    public interface IUsersRepository
    {
        List<UserViewModel> GetAll();

        UserViewModel TryGetById(Guid userId);

        UserViewModel TryGetByName(string name);

        void Delete(Guid userId);

        void Add(UserViewModel user);

        void Edit(EditUserViewModel user, Guid userId);

        void ChangePassword(Guid userId, string password);

        void ChangeAccess(Guid userId, string roleName);
    }
}
