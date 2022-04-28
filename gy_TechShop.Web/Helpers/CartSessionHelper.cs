﻿using gy_TechShop.Entities.DomainModels;
using gy_TechShop.Web.Extension;
using Microsoft.AspNetCore.Http;

namespace gy_TechShop.Web.Helpers
{
    public class CartSessionHelper : ICartSessionHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartSessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Cart GetCart(string key)
        {
            var cartToCheck = _httpContextAccessor.HttpContext?.Session.GetObject<Cart>(key);
            if (cartToCheck == null)
            {
                SetCart(key, new Cart());
                cartToCheck = _httpContextAccessor.HttpContext?.Session.GetObject<Cart>(key);
            }

            return cartToCheck;
        }

        public void SetCart(string key, Cart cart)
        {
            _httpContextAccessor.HttpContext?.Session.SetObject(key, cart);
        }

        public void Clear()
        {
            _httpContextAccessor.HttpContext?.Session.Clear();
        }
    }
}
