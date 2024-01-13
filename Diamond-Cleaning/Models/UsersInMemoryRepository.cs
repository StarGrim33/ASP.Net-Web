using Diamond_Cleaning.Interfaces;

namespace Diamond_Cleaning.Models
{
    public class UsersInMemoryRepository : IUsersRepository
    {
        private List<UserViewModel> _users;

        public UsersInMemoryRepository()
        {
            _users =
            [
                new UserViewModel("kirill@kirill.ru", "12345678", "Кирилл", "Фисенко", "+79265846357"),
                new UserViewModel("andrey@andrey.ru", "12345678", "Андрей", "Петров", "+79164875124")
            ];
        }

        public List<UserViewModel> GetAll()
        {
            return _users;
        }

        public UserViewModel TryGetById(Guid user)
        {
            try
            {
                return _users.FirstOrDefault(usert => usert.Guid == user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserViewModel TryGetByName(string name)
        {
            return _users.FirstOrDefault(user => user.Name == name);
        }

        public void Delete(Guid userId)
        {
            var user = TryGetById(userId);
            _users.Remove(user);
        }

        public void Add(UserViewModel user)
        {
            _users.Add(user);
        }

        public void Edit(EditUser user, Guid userId)
        {
            var currentUser = TryGetById(userId);
            currentUser.Name = user.Name;
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.Phone = user.Phone;
        }

        public void ChangePassword(Guid userId, string password)
        {
            var currentUser = TryGetById(userId);
            currentUser.Password = password;
        }

        public void ChangeAccess(Guid userId, string roleName)
        {
            var currentUser = TryGetById(userId);
            currentUser.Role.Name = roleName;
        }
    }
}
