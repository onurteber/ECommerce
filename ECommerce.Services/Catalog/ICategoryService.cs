using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Catalog
{
    public interface ICategoryService
    {
        IQueryable<Product> GetProductsByCategoryIds(int[] ids);
        IQueryable<Product> GetProductsByCategoryId(int id);
        IQueryable<Category> GetHomePageCategories();
        List<Category> GetCategories();
        Category GetCategory(string id);
        IQueryable<int> GetCategoryByProductId(string id);
    }
}
