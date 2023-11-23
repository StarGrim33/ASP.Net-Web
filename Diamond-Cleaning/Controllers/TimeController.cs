using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Controllers
{
    public class TimeController : Controller
    {
        public string Hello()
        {
            var nightTime1 = new TimeOnly(0, 0);
            var nightTime2 = new TimeOnly(5, 59);
            var morningTime1 = new TimeOnly(6, 0);
            var morningTime2 = new TimeOnly(11, 59);
            var dayTime1 = new TimeOnly(12, 0);
            var dayTime2 = new TimeOnly(17, 59);
            var eviningTime1 = new TimeOnly(18, 0);
            var eviningTime2 = new TimeOnly(23, 59);
            var time = TimeOnly.FromDateTime(DateTime.Now);
            string helloText = "";

            if (time >= nightTime1 && time <= nightTime2)
            {
                helloText = $"Доброй ночи! Текущее время: {DateTime.Now}";
            }
            else if (time >= morningTime1 && time <= morningTime2)
            {
                helloText = "Доброе утро!";
            }
            else if (time >= dayTime1 && time <= dayTime2)
            {
                helloText = "Добрый день!";
            }
            else if (time >= eviningTime1 && time <= eviningTime2)
            {
                helloText = "Добрый вечер!";
            }

            return helloText;
        }
    }
}
