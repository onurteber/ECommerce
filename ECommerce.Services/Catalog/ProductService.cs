using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Data;

namespace ECommerce.Services.Catalog
{
    public class ProductService : IProductService
    {
        AppDbContext appDbContext = new AppDbContext();
        private ICategoryService _categoryService;
        public ProductService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public void DeleteProduct(int id)
        {
            var product = appDbContext.Products.FirstOrDefault(p => p.Id == id);
            product.Deleted=true;
            appDbContext.SaveChanges();
        }

        public IQueryable<Product> GetFeaturedProducts()
        {
            return appDbContext.Products.Where(p => p.ShowOnHomePage && p.Visibility).OrderByDescending(p => p.CreateDate);
        }

        public Product GetProductById(int id)
        {
            return appDbContext.Products.SingleOrDefault(p => p.Id == id && p.Visibility);
        }

        public Product GetProductBySlug(string slug)
        {
            return appDbContext.Products.SingleOrDefault(p => p.Slug == slug && p.Visibility);
        }

        public void ViewedProduct(int productId)
        {
            var product = appDbContext.Products.SingleOrDefault(p => p.Id == productId);
            if (product != null)
            {
                product.Viewed += 1;
                appDbContext.SaveChanges();
            }
        }

        public IQueryable<Product> GetProductsByCategoryIds(int[] ids)
        {
            return _categoryService.GetProductsByCategoryIds(ids);
        }

        public IQueryable<Product> GetProductsByIds(int[] ids)
        {
            return appDbContext.Products.Where(p => ids.Contains(p.Id) && p.Visibility);
        }

        public IQueryable<Product> GetRelatedProductsById(int id)
        {
            var categoryId = appDbContext.Products.SingleOrDefault(p => p.Id == id).Category_Product_Mapping.Select(p => p.CategoryId);
            return appDbContext.Category_Product_Mapping.Where(p => categoryId.Contains(p.CategoryId) && p.SpecialProduct).OrderBy(p => p.Queue).Select(p => p.Product);

        }

        public IQueryable<Product> GetSpecialProducts()
        {
            return appDbContext.Products.Where(p => p.SpecialPriceFinishDate > DateTime.Now && p.SpecialPriceStartDate < DateTime.Now && p.Visibility);
        }

        public void InsertProduct(Product product)
        {
            appDbContext.Products.Add(product);
            appDbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetTopViewedProducts()
        {
            var product = appDbContext.Products.OrderByDescending(p => p.Viewed);
            return product;
        }
    }
}
