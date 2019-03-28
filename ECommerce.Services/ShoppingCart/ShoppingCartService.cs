using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Data;
using ECommerce.Services.Catalog;

namespace ECommerce.Services.ShoppingCart
{
    public class ShoppingCartService : IShoppingCartService
    {
        AppDbContext appDbContext = new AppDbContext();
        private IProductService _productService;
        public ShoppingCartService(IProductService productService)
        {
            _productService = productService;
        }
        public void AddToBasket(int productId, int count, string email)
        {
            var userId = appDbContext.Users.SingleOrDefault(p => p.Email == email).Id;
            if (_productService.GetProductById(productId) != null)
            {
                appDbContext.Baskets.Add(new Basket
                {
                    ProductId = productId,
                    Count = count,
                    UserId = userId,
                    Price = 0
                });

                appDbContext.SaveChanges();
            }
        }

        public void DeleteFromBasket(int productId, string email)
        {
            var userId = appDbContext.Users.SingleOrDefault(p => p.Email == email).Id;
            var product = appDbContext.Baskets.SingleOrDefault(p => p.ProductId == productId && p.UserId == userId);
            if (product != null)
            {
                appDbContext.Baskets.Remove(product);
                appDbContext.SaveChanges();
            }
        }

        public void DecreaseFromBasket(int productId, string email)
        {
            var userId = appDbContext.Users.SingleOrDefault(p => p.Email == email).Id;
            var product = appDbContext.Baskets.SingleOrDefault(p => p.ProductId == productId && p.UserId == userId);
            if (product != null)
            {
                product.Count--;
                if (product.Count <= 0)
                {
                    appDbContext.Baskets.Remove(product);
                }
                appDbContext.SaveChanges();
            }
        }

        public IQueryable<Basket> GetBasket(string email)
        {
            var userId = appDbContext.Users.SingleOrDefault(p => p.Email == email).Id;

            return appDbContext.Baskets.Where(p => p.UserId == userId);
        }
        public int GetBasketCount(string email)
        {

            var userId = appDbContext.Users.SingleOrDefault(p => p.Email == email).Id;
            if (appDbContext.Baskets.FirstOrDefault(p => p.UserId == userId) != null)
            {
                var productCount = Convert.ToInt32(appDbContext.Baskets.Where(p => p.UserId == userId).Sum(p => p.Count));
                if (productCount != null)
                {
                    return productCount;
                }
            }
            return 0;
        }

        public int BasketByProductId(string email, int productId)
        {
            var userId = appDbContext.Users.SingleOrDefault(p => p.Email == email).Id;
            int ali = appDbContext.Baskets.Where(p => p.UserId == userId && p.ProductId == productId).Count();
            if (ali >= 1)
            {
                int countProduct = appDbContext.Baskets.FirstOrDefault(p => p.UserId == userId && p.ProductId == productId).Count;
                return countProduct;
            }
            else
            {
                return 0;
            }
        }


        public void UpdateBasket(IEnumerable<Basket> basket, string email)
        {
            var userId = appDbContext.Users.SingleOrDefault(p => p.Email == email).Id;
            if (GetBasket(email).Count() > 0)
            {
                var userBasket = appDbContext.Baskets.Where(p => p.UserId == userId);
                appDbContext.Baskets.RemoveRange(userBasket);
                appDbContext.SaveChanges();
                foreach (var item in basket)
                {
                    AddToBasket(item.ProductId, item.Count, email);
                }
            }
        }
    }
}
