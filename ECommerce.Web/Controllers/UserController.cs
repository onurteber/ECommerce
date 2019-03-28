using ECommerce.Data;
using ECommerce.Services.System;
using ECommerce.Services.User;
using ECommerce.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ECommerce.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        private ISettingService _settingService;
        public UserController(IUserService userService, ISettingService settingService)
        {
            _userService = userService;
            _settingService = settingService;
        }
        


        #region Register

        
        [HttpPost]
        public ActionResult Register(UserRegisterModel userRegisterModel)
        {
            if(ModelState.IsValid)
            {
                if (_userService.EmailControl(userRegisterModel.Email))
                {
                    TempData["error"] = "email";
                    ModelState.AddModelError("Email", "Bu email adresine kayıtlı bir hesap bulunmaktadır.");
                    return RedirectToAction("Index", "Home");
                }
                if (!userRegisterModel.Password.Equals(userRegisterModel.PasswordAgain))
                {
                    TempData["error"] = "sifre";
                    ModelState.AddModelError("Password", "Şifreler Uyuşmuyor!");
                    return RedirectToAction("Index", "Home");
                }
                //if (userRegisterModel.UserNameActive)
                //{
                //    if (_userService.UserNameControl(userRegisterModel.UserName))
                //    {
                //        ModelState.AddModelError("UserName", "Bu kullanıcı adında kayıtlı bir hesap bulunmaktadır.");
                //        return RedirectToAction("Index", "Home", userRegisterModel);
                //    }
                //}
                var user = new User();
                user.Name = userRegisterModel.Name;
                user.LastName = userRegisterModel.LastName;
                user.Email = userRegisterModel.Email;
                user.Phone = userRegisterModel.Phone;
                user.Role = "Customer";
                user.Password = userRegisterModel.Password;
                var registerResult = _userService.Register(user);
                if (registerResult == RegisterResult.Successful)
                {
                    //TempData["error"] = "sifre";
                    TempData["successRegister"] = "true";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error"] = "system";
                    ModelState.AddModelError("", "Bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["error"] = "system";
                ModelState.AddModelError("", "Bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion

        #region Login

        
        [HttpGet]
        public ActionResult Login()
        {
            //if (!_settingService.GetSetting<bool>("Login Enabled"))
            //{
            //    return new HttpNotFoundResult();
            //}
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public ActionResult Login(LoginUserModel loginUserModel, string returnUrl)
        {
            //if (!_settingService.GetSetting<bool>("Login Enabled"))
            //{
            //    return new HttpNotFoundResult();
            //}
            if (ModelState.IsValid)
            {
                var user = new User();

                var url =TempData["ViewNameLogin"].ToString();


                user = _userService.GetUserByEmailCredantial(loginUserModel.Email, loginUserModel.Password);
                

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Email, true);

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        TempData["isLogin"] = "true";
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        TempData["isLogin"] = "true";
                        return Redirect("~/"+url);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı ya da Şifre Yanlış");
                    TempData["isLogin"] = "false";
                    return RedirectToAction("Index", "Home");
                }

            }
            TempData["isLogin"] = "false";
            return RedirectToAction(TempData["ViewName"].ToString(), "Home");
        }

        #endregion

        #region LogOut

        
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            var ipAddress = HttpContext.Request.UserHostAddress;
            FormsAuthentication.SetAuthCookie(ipAddress, true);
            var url =TempData["ViewNameLogOut"].ToString();
            return Redirect(url);
        }

        #endregion

        #region ConfirmEmail
                
        public ActionResult ConfirmEmail(string customerGuid)
        {
            try
            {
                _userService.ActivateUserByGuid(customerGuid);
                return View("ConfirmedEmail");
            }
            catch (Exception)
            {
                return new HttpNotFoundResult();
            }
        }

        #endregion

        //public JsonResult ResetPassword(string email)
        //{
        //    if (_userService.ResetPassword(email) == true)
        //    {
        //        TempData["resetPassword"] = "true";
        //        bool hata = true;
        //        return Json(hata, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        TempData["resetPassword"] = "false";
        //        bool hata = false;
        //        return Json(hata, JsonRequestBehavior.AllowGet);
        //    }
        //}

        public ActionResult ResetPassword(string email)
        {
            if (_userService.ResetPassword(email) == true)
            {
                TempData["resetPassword"] = "true";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["resetPassword"] = "false";
                return RedirectToAction("Index","Home");
            }
        }

    }
}