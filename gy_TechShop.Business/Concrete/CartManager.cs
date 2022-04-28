using gy_TechShop.Business.Abstract;
using gy_TechShop.Entities.Concrete;
using gy_TechShop.Entities.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gy_TechShop.Business.Concrete
{
    public class CartManager : ICartService
    {
        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }

        public void AddToCart(Cart cart, Product product)
        {
            var cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (cartLine != null) ++cartLine.Quantity;
            else cart.CartLines.Add(new CartLine { Product = product, Quantity = 1 });
        }

        public void RemoveFromCart(Cart cart, int productId)
        {
            var cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId);
            if (cartLine?.Quantity > 1) --cartLine.Quantity;
            else cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId));
        }
    }
}
