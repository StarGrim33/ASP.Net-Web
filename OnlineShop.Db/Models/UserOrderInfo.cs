﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
{
    public class UserOrderInfo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
