using Project.BuisnessLogic.Manage;
using Project.Core.Stuff;
using Project.SQLDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Areas.User.Controllers
{
    [Authorize]
    public class UserHomeController : Controller
    {
        private readonly IManager<Objective, Guid> _repo;

        public UserHomeController() { }

        public UserHomeController(IManager<Objective,Guid> repo)
        {
            List<SelectListItem> dropdownItems = new List<SelectListItem>();
            dropdownItems.AddRange(new[]{
                            new SelectListItem() { Text = "To do", Value = "1" },
                            new SelectListItem() { Text = "Done", Value = "2" },
                            new SelectListItem() { Text = "Review", Value = "3" },
                            new SelectListItem() { Text  = "In progress", Value = "4" },
                            new SelectListItem() { Text  = "Rework", Value = "5" } });
            ViewBag.Statuses = dropdownItems;
            _repo = repo;
        }
        // GET: User/UserHome
        public ActionResult Index()
        {
            var res = _repo.GetAll();
            return View(res);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Objective model)
        {
            model.UserID = (Guid)System.Web.HttpContext.Current.Session["UserID"];
            _repo.Create(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Objective model)
        {
            return View(_repo.Get(model.Id));
        }
        [HttpPost]
        public ActionResult Edit(Objective model, Guid id)
        {
            _repo.Edit(model, id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(Guid id,object o)
        {
            return View(_repo.Get(id));
        }
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(Guid id, object o)
        {
            return View(_repo.Get(id));
        }
        
    }
}