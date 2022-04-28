using gy_TechShop.Entities.Concrete;
using gy_TechShop.Entities.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gy_TechShop.Business.Abstract
{
    public interface ICartService
    {
        List<CartLine> List(Cart cart);
        void AddToCart(Cart cart, Product product);
        void RemoveFromCart(Cart cart, int productId);
    }
}
