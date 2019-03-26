using ECommerce.Data;
using ECommerce.Services.Catalog;
using ECommerce.Services.System;
using ECommerce.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Web.Controllers
{
    public class CategoryController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private IPhotoService _photoService;
        public CategoryController(IProductService productService, IPhotoService photoService, ICategoryService categoriService)
        {
            _productService = productService;
            _photoService = photoService;
            _categoryService = categoriService;
        }



        [Route("Category/Details/{id}")]
        public ActionResult Details(string id)
        {
            var category = _categoryService.GetCategory(id);
            if(category != null)
            {
                var product = _categoryService.GetProductsByCategoryId(category.Id).ToList();
                var model = new CategoryModel
                {
                    Name = category.Name,
                    ShortDescription = category.ShortDescription,
                    Photo = _photoService.GetPhotoById(category.PhotoId ?? 0) != null ? _photoService.GetPhotoById(category.PhotoId ?? 0).FileUrl : "/Content/nophoto.jpg",
                    Products = product.Select(p => PrapareProductModel(p))
                };
                return View("~/Views/Category/Details.cshtml", model);
            }
            else
            {
                return new HttpNotFoundResult();
            }


        }

        [NonAction]
        public ProductModel PrapareProductModel(Product product)
        {
            ProductModel model = new ProductModel();
            model.Description = product.ShortDescription;
            model.Name = product.ProductName;
            model.Full = product.Description;
            model.Slug = product.Slug;
            model.Id = product.Id;
            model.PastPrice = product.PastPrice;
            model.Price = product.Price;
            model.ShipmentDay = product.ShippingTime.ShippingTime1;
            model.SpecialPrice = product.SpecialPrice;
            model.SpecialPriceStartDate = product.SpecialPriceStartDate;
            model.SpecialPriceFinishDate = product.SpecialPriceFinishDate;
            model.Stock = product.StockActive ? -1 : product.StockCount;
            var photoid = product.ProductPhotoes.Select(p => p.PhotoId);
            model.Photos = _photoService.GetPhotosByIds(photoid.ToArray()).Select(p => p.FileUrl).ToList();
            return model;
        }
    }
}