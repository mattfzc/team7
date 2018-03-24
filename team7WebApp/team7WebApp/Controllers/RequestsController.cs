using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using team7WebApp.Models;

namespace team7WebApp.Controllers
{
    public class RequestsController : Controller
    {
        private Team7DbContext _db = new Team7DbContext();
        //public SelectList SelList;
        public List<int> IdList;

        // GET: Requests
        public ActionResult Index()
        {
            return View(_db.Request.ToList());
        }

        // GET: Requests/Details/5
        public ActionResult Details(int id)
        {
            var model = _db.Request.Find(id);
            return View(model);
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            var inquirerRole = _db.Role.FirstOrDefault(x => !x.CanTakeRequests && !x.CanAssign)?.ID;
            if (inquirerRole == null)
            {
                throw new Exception();
            }
            IdList = _db.User.Where(x => x.RoleId == inquirerRole).Select(x => x.Id).ToList();


            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach(var v in IdList)
            {
                listItems.Add(new SelectListItem
                {
                    Text = v.ToString(),
                    Value = v.ToString()
                });
            }
           

            ViewBag.InquirerIdList = listItems;
            

            return View();
        }

        // POST: Requests/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                int nextId = 0;
                if (_db.Request.ToList().Count > 0)
                {
                    nextId = _db.Request.Max(x => x.RequestID) + 1;
                }
                // TODO: Add insert logic here
                Request newRequest = new Request
                {
                    RequestID = nextId,
                    InquirerID = Convert.ToInt32(Request.Form["InquirerID"]),
                    DeptID = Convert.ToInt32(Request.Form["DeptID"]),
                    LiasonID = -1,
                    MeetTime = DateTime.Now,
                    HasInquiererAccepted = false
                };
                _db.Request.Add(newRequest);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Requests/Edit/5
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

        // GET: Requests/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _db.Request.Find(id);
            return View(model);
        }

        // POST: Requests/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var model = _db.Request.Find(id);
                if(model != null)
                {
                    _db.Request.Remove(model);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
