using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Catalog
{
    public interface IProductService
    {
        void InsertProduct(Product product);
        void DeleteProduct(int id);
        void UpdateProduct(Product product);
        IQueryable<Product> GetFeaturedProducts();
        IQueryable<Product> GetSpecialProducts();
        IQueryable<Product> GetTopViewedProducts();
        IQueryable<Product> GetProductsByIds(int[] ids);
        IQueryable<Product> GetProductsByCategoryIds(int[] ids);
        Product GetProductById(int id);
        Product GetProductBySlug(string slug);
        IQueryable<Product> GetRelatedProductsById(int id);
        void ViewedProduct(int productId);
        
    }
}
