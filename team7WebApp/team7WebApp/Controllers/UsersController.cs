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
        // GET: Users
        public ActionResult Index()
        {
            return View(_db.User.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
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
