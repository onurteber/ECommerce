using ECommerce.Services.Catalog;
using ECommerce.Services.ShoppingCart;
using ECommerce.Services.System;
using ECommerce.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public void AddToBasket(int productId,int count=1)
        {
            int countProduct;
            if (userEmail == "")
            {
                string email= "guest";//Todo 
                countProduct = _shoppingCartService.BasketByProductId(email, productId);
                if (countProduct >= 1)
                {
                    _shoppingCartService.DeleteFromBasket(productId, userEmail);
                    countProduct++;
                    _shoppingCartService.AddToBasket(productId, countProduct, userEmail);
                }
                else
                {
                    _shoppingCartService.AddToBasket(productId, count, userEmail);
                }
            }
            else
            {
                countProduct = _shoppingCartService.BasketByProductId(userEmail, productId);
                if (countProduct >= 1)
                {
                    _shoppingCartService.DeleteFromBasket(productId, userEmail);
                    countProduct++;
                    _shoppingCartService.AddToBasket(productId, countProduct, userEmail);
                }
                else
                {
                    _shoppingCartService.AddToBasket(productId, count, userEmail);
                }
            }
            
        }
        public ActionResult DeleteFromBasket(int productId)
        {
            _shoppingCartService.DeleteFromBasket(productId,userEmail);
            return View("Index");
        }
    }
}