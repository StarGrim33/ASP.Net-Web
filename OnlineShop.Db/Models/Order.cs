using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OnlineShop.Db.Models
{
    public class Order
    {
        public Order()
        {
            Time = DateTime.Now;
            Status = OrderStatuses.Created;
        }

        public Guid Id { get; set; }

        public UserOrderInfo User { get; set; }

        public List<CartItem> Items { get; set; }

        public DateTime Time { get; set; }

        public OrderStatuses Status { get; set; }
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

    public class OrderStatusDisplay
    {
        public static string GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
        }
    }
}
