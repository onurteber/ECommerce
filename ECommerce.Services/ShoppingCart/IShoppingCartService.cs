using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.ShoppingCart
{
    public interface IShoppingCartService
    {
        void AddToBasket(int productId, int count, string email);
        void DeleteFromBasket(int productId, string email);
        void UpdateBasket(IEnumerable<Basket> basket, string email);
        IQueryable<Basket> GetBasket(string email);
        int BasketByProductId(string email, int productId);
        int GetBasketCount(string email);
    }
}
