using Project.BuisnessLogic.Manage;
using Project.SQLDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminHomeController : Controller
    {
        private readonly IManager<Account,Guid> _repo;
        public AdminHomeController()
        {

        }
        public AdminHomeController(IManager<Account,Guid> repo)
        {
            _repo = repo;
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View(_repo.GetAll());
        }
    }
}