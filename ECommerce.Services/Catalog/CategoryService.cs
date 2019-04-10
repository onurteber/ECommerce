using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ECommerce.Data;
using ECommerce.Services.System;

namespace ECommerce.Services.Catalog
{
    public class CategoryService : ICategoryService
    {
        private AppDbContext _appDbContext;
        private IUrlService _urlService;
        private IPhotoService _photoService;
        public CategoryService(AppDbContext appDbContext,IUrlService urlService,IPhotoService photoService)
        {
            _appDbContext = appDbContext;
            _urlService = urlService;
            _photoService = photoService;
        }
        public IQueryable<Product> GetProductsByCategoryIds(int[] ids)
        {
            return _appDbContext.Category_Product_Mapping.Where(p => ids.Contains(p.CategoryId)).Select(p => p.Product);
        }
        public IQueryable<Product> GetProductsByCategoryId(int id)
        {
            var model = _appDbContext.Category_Product_Mapping.Where(p => p.CategoryId == id);

            var product = model.Select(p => p.Product);
            return product;
        }
        public IQueryable<Category> GetHomePageCategories()
        {
            var model = _appDbContext.Categories.OrderBy(f => f.Queue).Where(f => f.ShowHomePage);
            return model;
        }

        public List<Category> GetCategories()
        {
            var model = _appDbContext.Categories.ToList();
            return model;
        }

        public IQueryable<int> GetCategoryByProductId(string id)
        {
            var model = _appDbContext.Category_Product_Mapping.Where(p => p.Product.Slug == id).Select(p => p.CategoryId);
            return model;
        }



        public Category GetCategory(string slug)
        {
            var model = _appDbContext.Categories.SingleOrDefault(p => p.Slug == slug);
            return model;
        }

        public void CreateCategory(Category category, HttpPostedFileBase photo)
        {
            var model = new Category();
            model.Name = category.Name;
            model.Queue = category.Queue;
            model.ShortDescription = category.ShortDescription;
            model.ShowHomePage = category.ShowHomePage;
            model.UserId = category.UserId;
            model.Slug = _urlService.GenerateSlug(category.Name);
            if (photo != null && photo.ContentLength > 0)
            {
                model.PhotoId = _photoService.UploadPicture(photo, category.Slug).Id;
            }
            model.ParentCategoryId = category.ParentCategoryId;
            _appDbContext.Categories.Add(model);
            _appDbContext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category != null)
            {
                _appDbContext.Categories.Remove(category);
                _appDbContext.SaveChanges();
            }
        }

        public void UpdateCategory(Category category, HttpPostedFileBase photo)
        {
            var model = GetCategoryById(category.Id);
            model.Name = category.Name;
            model.Queue = category.Queue;
            model.ShortDescription = category.ShortDescription;
            model.ShowHomePage = category.ShowHomePage;
            model.UserId = category.UserId;
            model.Slug = _urlService.GenerateSlug(category.Name);
            if(photo != null && photo.ContentLength > 0)
            {
                model.PhotoId = _photoService.UploadPicture(photo, category.Slug).Id;
            }
            model.ParentCategoryId = category.ParentCategoryId;
            _appDbContext.SaveChanges();
        }

        public IQueryable<Category> GetAllCategories()
        {
            return _appDbContext.Categories.OrderBy(p => p.Queue);
        }

        public Category GetCategoryById(int id)
        {
            return _appDbContext.Categories.SingleOrDefault(p => p.Id == id);
        }
    }
}
