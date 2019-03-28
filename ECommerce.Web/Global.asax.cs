
using Autofac;
using Autofac.Integration.Mvc;
using ECommerce.Services.Catalog;
using ECommerce.Services.Communication;
using ECommerce.Services.ShoppingCart;
using ECommerce.Services.System;
using ECommerce.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace ECommerce.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static Autofac.IContainer _appContainer;
        protected void Application_Start()
        {
            AutofacRun();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest()
        {
            if (HttpContext.Current.User == null)
            {
                CreateGuestMember();
            }
            else
            {
                var ipAddress = HttpContext.Current.Request.UserHostAddress;
                FormsAuthentication.SetAuthCookie(ipAddress, true);
            }
        }
        private void CreateGuestMember()
        {
            var _customerService = _appContainer.Resolve<IUserService>();
            var ipAddress = HttpContext.Current.Request.UserHostAddress;
            if (!_customerService.EmailControl(ipAddress))
            {
                _customerService.CreateGuestMember(ipAddress);
                FormsAuthentication.SetAuthCookie(ipAddress, true);
            }
        }

        private void AutofacRun()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<EmailSenderService>().As<IEmailSenderService>();
            builder.RegisterType<SettingService>().As<ISettingService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<PhotoService>().As<IPhotoService>();
            builder.RegisterType<SlideShowService>().As<ISlideShowService>();
            builder.RegisterType<ShoppingCartService>().As<IShoppingCartService>();
            //builder.RegisterType<RouteService>().As<IRouteService>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            _appContainer = container;
        }

        protected void Application_PostAuthenticateRequest()
        {
            if (FormsAuthentication.CookiesSupported)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        var userService = _appContainer.Resolve<IUserService>();
                        string userName = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        var user = userService.GetUserByEmail(userName);
                        string role = user.Role;
                        HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new System.Security.Principal.GenericIdentity(user.Email, "Forms"), role.Split(';'));
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    var ipAddress = HttpContext.Current.Request.UserHostAddress;
                    FormsAuthentication.SetAuthCookie(ipAddress, true);
                }
            }
        }
    }
}
