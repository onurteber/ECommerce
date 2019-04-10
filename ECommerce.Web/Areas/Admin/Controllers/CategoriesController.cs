using ECommerce.Data;
using ECommerce.Services.Catalog;
using ECommerce.Services.System;
using ECommerce.Services.User;
using ECommerce.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private ICategoryService _categoryService;
        private IPhotoService _photoService;
        private IUserService _userService;
        private int UserId => _userService.GetUserByEmail(User.Identity.Name).Id;
        public CategoriesController(ICategoryService categoryService, IPhotoService photoService)
        {
            _categoryService = categoryService;
            _photoService = photoService;
        }
        // GET: Admin/Categories
        public ActionResult Index()
        {
            var data = _categoryService.GetAllCategories().ToList().Select(p => PrepareCategoryIndexModel(p));
            return View(data);
        }
        public void CategoryDelete(int id)
        {
            _categoryService.DeleteCategory(id);
        }

        public ActionResult EditCategory(int id)
        {
            var data = _categoryService.GetCategoryById(id);
            ViewBag.ParentCategoryId = new SelectList(_categoryService.GetAllCategories().Where(f => f.Id != id), "Id", "Name", data.ParentCategoryId);
            return View(PrepareCategoryEditCreateModel(data));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory(CategoryEditCreateModel model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.UpdateCategory(new Category
                {
                    UserId = UserId,
                    Description = model.Description,
                    Name = model.Name,
                    ShortDescription = model.ShortDescription,
                    ShowHomePage = model.ShowOnHomePage,
                    Queue = model.Queue,
                    ParentCategoryId = model.ParentCategoryId,
                    Id = model.Id,
                    CreateDate = DateTime.Now,
                    Slug = Server.MapPath("~/uploads")
                }, model.Photo);
                return RedirectToAction("Index");
            }
            ViewBag.ParentCategoryId = new SelectList(_categoryService.GetAllCategories(), "Id", "Name", model.ParentCategoryId);
            return View(model);
        }

        public ActionResult CreateCategory()
        {
            ViewBag.ParentCategoryId = new SelectList(_categoryService.GetAllCategories(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(CategoryEditCreateModel model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.CreateCategory(new Category
                {
                    UserId = UserId,
                    Description = model.Description,
                    Name = model.Name,
                    ShortDescription = model.ShortDescription,
                    ShowHomePage = model.ShowOnHomePage,
                    Queue = model.Queue,
                    ParentCategoryId = model.ParentCategoryId,
                    CreateDate = DateTime.Now,
                    Slug = Server.MapPath("~/uploads")
                }, model.Photo);
                return RedirectToAction("Index");
            }
            ViewBag.ParentCategoryId = new SelectList(_categoryService.GetAllCategories(), "Id", "Name", model.ParentCategoryId);
            return View(model);
        }


        [NonAction]
        private CategoryIndexModel PrepareCategoryIndexModel(Category category)
        {
            var model = new CategoryIndexModel();
            model.Id = category.Id;
            model.Name = category.Name;
            model.PhotoURL = _photoService.GetPhotoById(category.PhotoId ?? 0).FileUrl;
            model.Queue = category.Queue;
            model.ProductCount = _categoryService.GetProductsByCategoryId(category.Id).Count();
            return model;
        }


        [NonAction]
        private CategoryEditCreateModel PrepareCategoryEditCreateModel(Category category)
        {
            var model = new CategoryEditCreateModel();
            model.Description = category.Description;
            model.Name = category.Name;
            model.Id = category.Id;
            model.ParentCategoryId = category.ParentCategoryId;
            model.ShortDescription = category.ShortDescription;
            model.PhotoURL = _photoService.GetPhotoById(category.PhotoId ?? 0).FileUrl;
            model.ShowOnHomePage = category.ShowHomePage;
            model.Queue = category.Queue;
            return model;
        }
    }
}