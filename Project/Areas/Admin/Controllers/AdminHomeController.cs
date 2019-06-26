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
        private readonly IManager<Account, Guid> _repo;
        private readonly IManager<Objective, Guid> _rep;

        public AdminHomeController()
        {

        }
        public AdminHomeController(IManager<Account, Guid> repo, IManager<Objective, Guid> rep)
        {
            List<SelectListItem> dropdownItems = new List<SelectListItem>();
            dropdownItems.AddRange(new[]{
                            new SelectListItem() { Text = "User", Value = "1" },
                            new SelectListItem() { Text = "Admin", Value = "2" } });
            ViewBag.Permissions = dropdownItems;
            List<SelectListItem> list = new List<SelectListItem>();
            list.AddRange(new[]{
                            new SelectListItem() { Text = "To do", Value = "1" },
                            new SelectListItem() { Text = "Done", Value = "2" },
                            new SelectListItem() { Text = "Review", Value = "3" },
                            new SelectListItem() {Text="In progress", Value="4" },
                            new SelectListItem() {Text="Rework",Value="5" } });
            ViewBag.Statuses = list;
            _repo = repo;
            _rep = rep;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var res = _repo.GetAll().Where(x=>x.Id!=(Guid)System.Web.HttpContext.Current.Session["UserID"]);
            
            return View(res);
        }

        [HttpGet]
        public ActionResult Watch(Guid id)
        {
            var res = _rep.GetAll().Where(x => x.UserID == id);
            return View(res);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(_repo.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Account model,Guid id)
        {
            _repo.Edit(model, id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            return View(_repo.Get(id));
        }
        [HttpPost]
        public ActionResult Delete(Guid id,object o)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ODelete(Guid id)
        {
            return View(_rep.Get(id));
        }
        [HttpPost]
        public ActionResult ODelete(Guid id, object o)
        {
            _rep.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ODetails(Guid id)
        {
            return View(_rep.Get(id));
        }
        [HttpGet]
        public ActionResult OEdit(Guid id)
        {
            return View(_rep.Get(id));
        }
        [HttpPost]
        public ActionResult OEdit(Objective model,Guid id)
        {
            _rep.Edit(model,id);
            return RedirectToAction("Index");
        }

    }
}