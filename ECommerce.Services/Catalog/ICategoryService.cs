using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ECommerce.Services.Catalog
{
    public interface ICategoryService
    {
        IQueryable<Product> GetProductsByCategoryIds(int[] ids);
        IQueryable<Product> GetProductsByCategoryId(int id);
        IQueryable<Category> GetHomePageCategories();
        List<Category> GetCategories();
        Category GetCategory(string id);
        Category GetCategoryById(int id);
        IQueryable<int> GetCategoryByProductId(string id);
        void CreateCategory(Category category, HttpPostedFileBase photo);
        void DeleteCategory(int id);
        void UpdateCategory(Category category, HttpPostedFileBase photo);
        IQueryable<Category> GetAllCategories();
    }
}
