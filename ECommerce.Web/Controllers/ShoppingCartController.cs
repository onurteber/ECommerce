using ECommerce.Data;
using ECommerce.Services.Catalog;
using ECommerce.Services.ShoppingCart;
using ECommerce.Services.System;
using ECommerce.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ECommerce.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IShoppingCartService _shoppingCartService;
        private IProductService _productService;
        private IPhotoService _photoService;
        private string userEmail => User.Identity.Name;
        public ShoppingCartController(IShoppingCartService shoppingCartService, IProductService productService, IPhotoService photoService)
        {
            _shoppingCartService = shoppingCartService;
            _productService = productService;
            _photoService = photoService;
        }
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var data = _shoppingCartService.GetBasket(userEmail).ToList().Select(p => PrepareShoppingCartModel(p));
            var model = new ShoppingCartModel {
                ShoppingModels = _shoppingCartService.GetBasket(userEmail).ToList().Select(p => PrepareShoppingCartModel(p)),
                TopViewedProducts= _productService.GetTopViewedProducts().ToList().Select(p => PrepareProductModel(p, false))
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
        public ShoppingModels PrepareShoppingCartModel(Data.Basket basket)
        {
            var model = new ShoppingModels();
            var product = _productService.GetProductById(basket.ProductId);
            var price = decimal.Zero;
            model.Count = basket.Count;
            if (DateTime.Now < basket.Product.SpecialPriceFinishDate && DateTime.Now > basket.Product.SpecialPriceStartDate && basket.Product.SpecialPrice.HasValue)
            {
                price = basket.Product.SpecialPrice.Value;
            }
            else
            {
                price = basket.Product.Price;
            }
            model.Id = product.Id;
            model.Price = price;
            model.Link = product.Slug;
            model.ProductName = product.ProductName;
            if (product.ProductPhotoes.Any())
            {
                model.PhotoLink = _photoService.GetPhotoById(product.ProductPhotoes.FirstOrDefault().PhotoId).FileUrl;
            }
            else
            {
                model.PhotoLink = _photoService.GetPhotoById(0).FileUrl;
            }
            return model;

        }



        public void AddToBasket(int productId, int count = 1)
        {
            int countProduct;

            countProduct = _shoppingCartService.BasketByProductId(userEmail, productId);
            if (countProduct >= 1)
            {
                _shoppingCartService.DeleteFromBasket(productId, userEmail);
                countProduct++;
                _shoppingCartService.AddToBasket(productId, countProduct, userEmail);
            }
            else
            {
                if (countProduct >= 0)
                {
                    _shoppingCartService.AddToBasket(productId, count, userEmail);
                }
            }
        }
        public void DeleteFromBasket(int productId)
        {
            _shoppingCartService.DecreaseFromBasket(productId, userEmail);
        }
    }
}