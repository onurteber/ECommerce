using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Data;

namespace ECommerce.Services.Catalog
{
    public class CategoryService : ICategoryService
    {
        AppDbContext appDbContext = new AppDbContext();
        public IQueryable<Product> GetProductsByCategoryIds(int[] ids)
        {
            return appDbContext.Category_Product_Mapping.Where(p => ids.Contains(p.CategoryId)).Select(p => p.Product);
        }
        public IQueryable<Product> GetProductsByCategoryId(int id)
        {
            var model = appDbContext.Category_Product_Mapping.Where(p => p.CategoryId == id);
            
            var product = model.Select(p => p.Product);
            return product;
        }
        public IQueryable<Category> GetHomePageCategories()
        {
            var model = appDbContext.Categories.OrderBy(f => f.Queue).Where(f => f.ShowHomePage);
            return model;
        }

        public List<Category> GetCategories()
        {
            var model = appDbContext.Categories.ToList();
            return model;
        }

        public IQueryable<int> GetCategoryByProductId(string id)
        {
            var model = appDbContext.Category_Product_Mapping.Where(p => p.Product.Slug == id).Select(p => p.CategoryId);
            return model;
        }

        

        public Category GetCategory(string slug)
        {
            var model = appDbContext.Categories.SingleOrDefault(p => p.Slug == slug);
            return model;
        }
    }
}
