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

    public class HomeController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private IPhotoService _photoService;
        private ISlideShowService _slideShowService;
        //private IRouteService _routeService;
        public HomeController(IProductService productService, IPhotoService photoService, ISlideShowService slideShowService, ICategoryService categoriService)
        {
            _productService = productService;
            _photoService = photoService;
            _slideShowService = slideShowService;
            _categoryService = categoriService;
            //_routeService = routeService;
        }
        public ActionResult Index()
        {
            var model = new HomePageModel
            {
                FeaturedProducts = _productService.GetFeaturedProducts().ToList().Select(p => PrepareProductModel(p, false)),
                SpecialProduct = _productService.GetSpecialProducts().Any() ? PrepareProductModel(_productService.GetSpecialProducts().FirstOrDefault()) : null,
                Slider = PrepareSlideShowModel(_slideShowService.GetHomePageSlides()),
                FeaturedCategories = PrepareHomePageCategoriesModel(_categoryService.GetHomePageCategories()),
                TopViewedProducts = _productService.GetTopViewedProducts().ToList().Select(p => PrepareProductModel(p,false))

            };
            return View(model);
        }

        [NonAction]
        public ProductModel PrepareProductModel(Product product, bool getRelated = false)
        {
            ProductModel model = new ProductModel();
            model.Description = product.ShortDescription;
            model.Slug = product.Slug;
            model.Name = product.ProductName;
            model.Full = product.Description;
            model.PastPrice = product.PastPrice;
            model.Id = product.Id;
            model.Price = product.Price;
            model.ShipmentDay = product.ShippingTime.ShippingTime1;
            model.SpecialPrice = product.SpecialPrice;
            model.SpecialPriceStartDate = product.SpecialPriceStartDate;
            model.SpecialPriceFinishDate = product.SpecialPriceFinishDate;
            model.Stock = product.StockActive ? -1 : product.StockCount;
            var photoid = product.ProductPhotoes.OrderBy(p => p.Queue).Select(p => p.PhotoId);
            model.Photos = _photoService.GetPhotosByIds(photoid.ToArray()).Select(p => p.FileUrl).ToList();
            if (getRelated)
            {
                model.RelatedProducts = _productService.GetRelatedProductsById(product.Id).Select(p => PrepareProductModel(p, false)).ToList();
            }
            return model;
        }

       

        [NonAction]
        public List<SlideShowModel> PrepareSlideShowModel(IQueryable<SlideShow> slides)
        {
            var data = new List<SlideShowModel>();
            foreach (var item in slides)
            {
                SlideShowModel slide = new SlideShowModel();
                slide.Description = item.Description;
                slide.ButtonName = item.ButtonName;
                slide.ButtonLink = item.ButtonLink;
                slide.Title = item.Title;
                var ids = new int[1] { item.PhotoId };
                slide.SlidePhoto = _photoService.GetPhotosByIds(ids).Any() ? _photoService.GetPhotosByIds(ids).FirstOrDefault().FileUrl : "/";
                data.Add(slide);
            }
            return data;
        }

        [NonAction]
        public List<HomePageCategoriesModel> PrepareHomePageCategoriesModel(IQueryable<Category> categories)
        {
            var data = new List<HomePageCategoriesModel>();
            foreach (var item in categories)
            {
                var model = new HomePageCategoriesModel();
                model.Title = item.Name;
                model.id =item.Id;
                model.Slug = item.Slug;
                if (item.PhotoId == null)
                {
                    model.Photo = "/Content/nophoto.jpg";
                }
                else
                {
                    model.Photo = _photoService.GetPhotoById(item.PhotoId ?? 0) != null ? _photoService.GetPhotoById(item.PhotoId ?? 0).FileUrl : "/Content/nophoto.jpg";
                }
                data.Add(model);
            }
            return
                 data;
        }

        //public ActionResult CheckRoute(string id)
        //{
        //    var controller = _routeService.CheckUrl(id);
        //    if(controller =="Products")
        //    {
        //        var defaultController = new ProductsController(_productService, _photoService);
        //        return defaultController.Details(id);
        //    }
        //    else if (controller == "Categories")
        //    {
        //        var defaultController = new ProductsController(_productService, _photoService);
        //        return defaultController.Details(id);
        //    }
        //    else if(controller == "Error")
        //    {
        //        return View("Error");
        //    }
        //    else
        //    {
        //        return new HttpNotFoundResult();
        //    }
        //}
    }
}