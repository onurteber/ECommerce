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
    public class ProductsController : Controller
    {
        private IProductService _productService;
        private IPhotoService _photoService;
        public ProductsController(IProductService productService, IPhotoService photoService)
        {
            _productService = productService;
            _photoService = photoService;
        }

        //// GET: Products
        //public ActionResult Detai(string id)
        //{
        //    var product = _productService.GetProductBySlug(id);
        //    if(product != null)
        //    {
        //        ProductModel model = PrapareProductModel(product, true);
        //        return View("~/Views/Products/Details.cshtml",model);
        //    }
        //    else
        //    {
        //        return new HttpNotFoundResult();
        //    }
        //}

        [Route("Products/Details/{id}")]
        public ActionResult Details(string id)
        {
            var product = _productService.GetProductBySlug(id);
            if(product != null)
            {
                _productService.ViewedProduct(product.Id);
                ProductModel model = PrapareProductModel(product);
                return View("~/Views/Products/Details.cshtml", model);
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
           
            return model;
        }
    }
}