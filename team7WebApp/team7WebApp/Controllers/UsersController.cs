using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using team7WebApp.Models;

namespace team7WebApp.Controllers
{
    public class UsersController : Controller
    {
        private Team7DbContext _db = new Team7DbContext();
        public class RequestDto
        {
            public string ToDept;
            public string Status;
            public string FromUser;
        }
        // GET: Users
        public ActionResult Index()
        {
            return View(_db.User.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            var model = _db.User.Find(id);
            var outgoing = _db.Request.Where(x => x.InquirerID == id).ToList();
            List<RequestDto> list1 = new List<RequestDto>();
            foreach(var req in outgoing)
            {
                var dept = _db.Department.Find(req.DeptID);
                if (dept == null)
                {
                    list1.Add(new RequestDto { ToDept = "???", Status = "(Please add Department)" });
                }
                else
                {
                    list1.Add(new RequestDto { ToDept = dept.DeptName, FromUser = model.FirstName + model.LastName, Status = "SENT" });
                }
            }
            ViewBag.requests = list1;
            var incoming = _db.Request.Where(x => x.DeptID == model.DepartmentId);
            var list2 = new List<RequestDto>();
            foreach(var req in incoming)
            {
                var user = _db.User.Find(req.InquirerID);
                if (user == null)
                {
                    list2.Add(new RequestDto { FromUser = "???", Status = "READY FOR RESPONSE" });
                }
                else
                {
                    list2.Add(new RequestDto { FromUser = user.FirstName + user.LastName, Status = "READY FOR RESPONSE" });
                }
            }
            ViewBag.inbound = list2;
            return View(model);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                int nextId = 0;
                if (_db.User.ToList().Count > 0)
                {
                    nextId = _db.User.Max(x => x.Id) + 1;
                }
                // TODO: Add insert logic here
                User newUser = new User
                {
                    Id = nextId,
                    FirstName = Request.Form["FirstName"],
                    LastName = Request.Form["LastName"],
                    PhoneNumber = Request.Form["PhoneNumber"],
                    EmailAddress = Request.Form["EmailAddress"],
                    DepartmentId = Convert.ToInt32(Request.Form["DepartmentId"]),
                    RoleId = Convert.ToInt32(Request.Form["RoleId"])
                };
                _db.User.Add(newUser);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _db.User.Find(id);
            return View(model);
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var model = _db.User.Find(id);
                if (model != null)
                {
                    _db.User.Remove(model);
                    _db.SaveChanges();
                }

                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
