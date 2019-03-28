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
            return View(data);

        }

        [NonAction]
        public ShoppingCartModel PrepareShoppingCartModel(Data.Basket basket)
        {
            var model = new ShoppingCartModel();
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