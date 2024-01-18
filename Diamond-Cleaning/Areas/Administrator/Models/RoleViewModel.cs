using System.ComponentModel.DataAnnotations;

namespace Diamond_Cleaning.Areas.Administrator.Models
{
    public class RoleViewModel
    {
        public string Name { get; set; }

		public override bool Equals(object? obj)
		{
			var role = obj as RoleViewModel;
			return Name == role.Name;
		}
	}
}
