using ECommerce.Services.ShoppingCart;
using ECommerce.Services.System;
using ECommerce.Services.User;
using ECommerce.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Web.Controllers
{
    public class CommonController : Controller
    {
        private ISettingService _settingService;
        private IUserService _userService;
        private IShoppingCartService _shoppingCartService;
        public CommonController(ISettingService settingService, IUserService userService, IShoppingCartService shoppingCartService)
        {
            _settingService = settingService;
            _userService = userService;
            _shoppingCartService = shoppingCartService;
        }
        // GET: Common
        public ActionResult Header()
        {
            var model = new HeaderModel();
            string email = HttpContext.User.Identity.Name;
            if(email != "")
            {
                model.BaketsCount = _shoppingCartService.GetBasketCount(email);
            }
            else
            {
                email = "guest";
                model.BaketsCount = _shoppingCartService.GetBasketCount(email);
            }
            
            model.Logo = _settingService.GetSetting<string>("LogoUrl");
            model.LogoHeight = _settingService.GetSetting<int>("LogoHeight");
            model.LogoWidth = _settingService.GetSetting<int>("LogoWidth");
            return View(model);
        }
        
        public ActionResult Footer()
        {
            return View();
        }
        
        public ActionResult ModalsPartials()
        {
            return PartialView("ModalsPartial");
        }
    }
}