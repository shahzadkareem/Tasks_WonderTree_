using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasksProject.Models;

namespace TasksProject.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationDbContext db;
        public CourseController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Course
        public ActionResult Index()
        {
            var Course = db.Course.ToList();
            return View(Course);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(Course model)
        {
            try
            {
                // TODO: Add insert logic here
                db.Course.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            var Course = db.Course.Where(a=> a.Cours_ID == id).ToList();
            return View(Course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Course Model)
        {
            try
            {

                db.Entry(Model).State = EntityState.Modified;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Course/Delete/5
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
