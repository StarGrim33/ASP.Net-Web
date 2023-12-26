using OnlineShop.Db.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Diamond_Cleaning.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        public UserOrderInfoViewModel User { get; set; }

        public List<CartItemViewModel> Items { get; set; }

        public DateTime Time { get; set; }

        public OrderStatuses Status { get; set; }

        public static string GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
        }
    }
    public enum OrderStatuses
    {
        [Display(Name = "Создан")]
        Created,

        [Display(Name = "Обработан")]
        Processed,

        [Display(Name = "В пути")]
        Delivering,

        [Display(Name = "Доставлен")]
        Delivered,

        [Display(Name = "Отменен")]
        Canceled
    }
}
