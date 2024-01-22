namespace Diamond_Cleaning.Areas.Administrator.Models
{
	public class EditRoleViewModel
	{
		public string? Name { get; set; }

		public List<RoleViewModel> AllRoles { get; set; }

		public List<RoleViewModel> UserRoles { get; set; }
	}
}
