using Project.BuisnessLogic.Manage;
using Project.Core.Stuff;
using Project.Helpers;
using Project.SQLDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAccountManager<Account> _repo;

        public LoginController() { }

        public LoginController(IAccountManager<Account> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult SignIn(string returnUrl)
        {
            var loginVm = new LoginVm
            {
                ReturnUrl = returnUrl
            };
            return View(loginVm);
        }

        [HttpPost]
        public ActionResult SignIn(LoginVm loginVm)
        {
            if (ModelState.IsValid)
            {
                var account = _repo.GetAccount(loginVm);
                if (account != null)
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.SetAuthCookie(account.Login, true);
                    Session["UserID"] = account.Id;
                    Session["UserName"] = account.Name;
                    SetRefreshTokenCookie(loginVm);
                    if (account.PermissionID == 1)
                        return RedirectToAction("Index", "User/UserHome");
                    else
                        return RedirectToAction("Index","Admin/AdminHome");
                }
                else
                {
                    ModelState.AddModelError("SigninError", "Wrong user");
                }

            }
            return View(loginVm);
        }

        private void SetRefreshTokenCookie(LoginVm loginVm)
        {
            var tokenHelper = new TokenHelper();
            var token = tokenHelper.GetRefreshToken(loginVm.Login, loginVm.Password);

            HttpCookie tokenCookie = new HttpCookie("ProjectCookie");
            tokenCookie.Value = token.RefreshToken;
            tokenCookie.Expires = DateTime.MaxValue;

            Response.Cookies.Add(tokenCookie);
        }


        public ActionResult SignOut(LoginVm loginVm)
        {
            FormsAuthentication.SignOut();
            HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

            Session.Clear();
            System.Web.HttpContext.Current.Session.RemoveAll();

            return RedirectToAction("Index", "Home");
        }
    }
}