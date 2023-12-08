using Diamond_Cleaning.Interfaces;

namespace Diamond_Cleaning.Models
{
    public class InMemoryRolesRepository : IRolesRepository
    {
        private List<Roles> _roles;

        public InMemoryRolesRepository()
        {
            _roles =
            [
                new Roles { Name = "Admin" }
            ];
        }

        public List<Roles> GetAll()
        {
            var lowerCaseRoles = _roles.Select(role => new Roles { Name = role.Name.ToLower() }).ToList();
            return lowerCaseRoles;
        }

        public void Add(Roles role)
        {
            if (role != null)
                _roles.Add(role);
        }

        public void Delete(Roles role)
        {
            if (role != null)
                _roles.Remove(role);
        }
    }
}
