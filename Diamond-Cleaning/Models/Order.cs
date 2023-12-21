using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Diamond_Cleaning.Models
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid();
            Time = DateTime.Now.ToString("HH:mm:ss");
            Date = DateTime.Now.ToString("dd-MM-yyyy");
            Status = OrderStatuses.Created;
        }

        public Guid Id { get; set; }

        public UserOrderInfo User { get; set; }

        public List<CartItemViewModel> Items { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public OrderStatuses Status { get; set; }
        public decimal Amount
        {
            get
            {
                return Items.Sum(x => x.Cost);
            }
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
