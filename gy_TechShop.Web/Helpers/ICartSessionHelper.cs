using gy_TechShop.Entities.DomainModels;

namespace gy_TechShop.Web.Helpers
{
    public interface ICartSessionHelper
    {
        Cart GetCart(string key);
        void SetCart(string key, Cart cart);
        void Clear();
    }
}
