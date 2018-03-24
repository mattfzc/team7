using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using team7WebApp.Models;

namespace team7WebApp.Controllers
{
    public class RolesController : Controller
    {
        private Team7DbContext _db = new Team7DbContext();
        // GET: Roles
        public ActionResult Index()
        {
            return View(_db.Role.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                int nextId = 0;
                if (_db.Role.ToList().Count > 0)
                {
                    nextId = _db.Role.Max(x => x.ID) + 1;
                }
                Role newRole = new Role
                {
                    ID = nextId,
                    RoleName = Request.Form["RoleName"],
                    CanAssign = Request.Form["CanAssign"] == "true" ? true : false,
                    CanTakeRequests = Request.Form["CanTakeRequests"] == "true" ? true : false
                };
                _db.Role.Add(newRole);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Roles/Edit/5
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

        // GET: Roles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Roles/Delete/5
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
