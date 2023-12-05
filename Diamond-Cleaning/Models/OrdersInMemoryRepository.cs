using Diamond_Cleaning.Interfaces;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Diamond_Cleaning.Models
{
    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private List<Cart> _orders = [];
        private string _path = @"C:\Users\prosk\OneDrive\Desktop\C# course\Data.json";

        public async Task Add(Cart cart, Order order)
        {
            _orders.Add(cart);
            await Writer(order);
        }

        private async Task Writer(Order order)
        {
            var options1 = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            using FileStream writer = new FileStream(_path, FileMode.Append);
            await JsonSerializer.SerializeAsync<Order>(writer, order, options1);
            await writer.FlushAsync();
        }
    }
}
