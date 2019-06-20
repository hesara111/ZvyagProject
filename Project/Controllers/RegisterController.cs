﻿using Project.BuisnessLogic.Manage;
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
        private readonly IManager<Account,Guid> _repo;

        public RegisterController() { }


        public RegisterController(IManager<Account,Guid> repo)
        {
            _repo = repo;
        }
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Account model)
        {
            _repo.Create(model);
            return RedirectToAction("Index","Home");
        }
    }
}