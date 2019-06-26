using Project.BuisnessLogic.Manage;
using Project.Service;
using Project.SQLDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAccountManager<Account> _rep;
        private readonly IManager<Account,Guid> _repo;

        public RegisterController() { }


        public RegisterController(IAccountManager<Account> rep, IManager<Account, Guid> repo)
        {
            _repo = repo;
            _rep = rep;
        }
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Account model)
        {
            model.PermissionID = 1;
            _repo.Create(model);

            EmailService.SendMail(model.Email, model.Id.ToString());

            return RedirectToAction("Index", "Home");
         
        }
        [HttpGet]
        public ActionResult ConfirmEmail(Guid id)
        {
            _rep.EmailConfirm(id);
            return View();
        }
    }
}