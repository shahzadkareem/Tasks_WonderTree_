using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasksProject.Models;

namespace TasksProject.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext db;
        public StudentController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Student
        public ActionResult Index()
        {

            var studentdata = db.Student.ToList();
            return View(studentdata);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student model)
        {
            try
            {
                // TODO: Add insert logic here
                db.Student.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var studentdata = db.Student.Where(a => a.Stu_ID == id).FirstOrDefault();
            return View(studentdata);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student model)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(model).State = EntityState.Modified;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
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
