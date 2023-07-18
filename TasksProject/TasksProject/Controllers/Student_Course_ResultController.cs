using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TasksProject;
using TasksProject.Models;

namespace TasksProject.Controllers
{
    public class Student_Course_ResultController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Student_Course_Result
        public ActionResult Index()
        {
            var student_Course_Results = db.student_Course_Results.Include(s => s.Course).Include(s => s.Student);
            return View(student_Course_Results.ToList());
        }

        // GET: Student_Course_Result/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Course_Result student_Course_Result = db.student_Course_Results.Find(id);
            if (student_Course_Result == null)
            {
                return HttpNotFound();
            }
            return View(student_Course_Result);
        }

        // GET: Student_Course_Result/Create
        public ActionResult Create()
        {
            ViewBag.Cours_ID = new SelectList(db.Course, "Cours_ID", "CourseName");
            ViewBag.Stu_ID = new SelectList(db.Student, "Stu_ID", "StudentName");
            return View();
        }

        // POST: Student_Course_Result/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Stu_ID,Cours_ID,date")] Student_Course_Result student_Course_Result)
        {
            if (ModelState.IsValid)
            {
                db.student_Course_Results.Add(student_Course_Result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cours_ID = new SelectList(db.Course, "Cours_ID", "CourseName", student_Course_Result.Cours_ID);
            ViewBag.Stu_ID = new SelectList(db.Student, "Stu_ID", "StudentName", student_Course_Result.Stu_ID);
            return View(student_Course_Result);
        }

        // GET: Student_Course_Result/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Course_Result student_Course_Result = db.student_Course_Results.Find(id);
            if (student_Course_Result == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cours_ID = new SelectList(db.Course, "Cours_ID", "CourseName", student_Course_Result.Cours_ID);
            ViewBag.Stu_ID = new SelectList(db.Student, "Stu_ID", "StudentName", student_Course_Result.Stu_ID);
            return View(student_Course_Result);
        }

        // POST: Student_Course_Result/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Stu_ID,Cours_ID,date")] Student_Course_Result student_Course_Result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Course_Result).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cours_ID = new SelectList(db.Course, "Cours_ID", "CourseName", student_Course_Result.Cours_ID);
            ViewBag.Stu_ID = new SelectList(db.Student, "Stu_ID", "StudentName", student_Course_Result.Stu_ID);
            return View(student_Course_Result);
        }

        // GET: Student_Course_Result/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Course_Result student_Course_Result = db.student_Course_Results.Find(id);
            if (student_Course_Result == null)
            {
                return HttpNotFound();
            }
            return View(student_Course_Result);
        }

        // POST: Student_Course_Result/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Course_Result student_Course_Result = db.student_Course_Results.Find(id);
            db.student_Course_Results.Remove(student_Course_Result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
