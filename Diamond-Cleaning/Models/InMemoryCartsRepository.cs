﻿
using Diamond_Cleaning.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Diamond_Cleaning.Models
{
    public class InMemoryCartsRepository : ICartsRepository
    {
        private List<Cart> _carts;

        public InMemoryCartsRepository()
        {
            _carts = [];
        }

        public Cart TryGetByUserId(string userId)
        {
            return _carts.FirstOrDefault(c => c.UserId == userId);
        }

        public void Add(Service service, string userId)
        {
            var existingCart = TryGetByUserId(userId);

            if (existingCart == null)
            {
                var newCart = new Cart()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItem>()
                    {
                        new CartItem()
                        {
                            Id = Guid.NewGuid(),
                            Amount = 1,
                            Service = service
                        }
                    }
                };

                _carts.Add(newCart);
            }
            else
            {
                var existingCartService = existingCart.Items.FirstOrDefault(x => x.Service.Id == service.Id);

                if (existingCartService != null)
                {
                    existingCartService.Amount += 1;
                }
                else
                {
                    existingCart.Items.Add(new CartItem()
                    {
                        Id = Guid.NewGuid(),
                        Amount = 1,
                        Service = service
                    });
                }
            }
        }
    }
}