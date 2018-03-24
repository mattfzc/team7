using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using team7WebApp.Models;

namespace team7WebApp.Controllers
{
    public class DepartmentsController : Controller
    {
        private Team7DbContext _db = new Team7DbContext();
        // GET: Departments
        public ActionResult Index()
        {
            return View(_db.Department.ToList());
        }

        // GET: Departments/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                int nextId = 0;
                if(_db.Department.ToList().Count > 0)
                {
                    nextId = _db.Department.Max(x => x.Id) + 1;
                }
                Department newDep = new Department
                {
                    Id = nextId,
                    DeptName = Request.Form["DeptName"],
                    Description = Request.Form["Description"]
                };
                _db.Department.Add(newDep);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Departments/Edit/5
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

        // GET: Departments/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Departments/Delete/5
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
