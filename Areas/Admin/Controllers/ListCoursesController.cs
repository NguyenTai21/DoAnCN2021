using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnCN2021.Models;

namespace DoAnCN2021.Areas.Admin.Controllers
{
    public class ListCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ListCourses
        public ActionResult Index()
        {
            var listCourses = db.ListCourses.Include(l => l.Course).Include(l => l.Customer);
            return View(listCourses.ToList());
        }

        // GET: Admin/ListCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListCourse listCourse = db.ListCourses.Find(id);
            if (listCourse == null)
            {
                return HttpNotFound();
            }
            return View(listCourse);
        }

        // GET: Admin/ListCourses/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name");
            ViewBag.CustomerId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: Admin/ListCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,CourseId")] ListCourse listCourse)
        {
            if (ModelState.IsValid)
            {
                db.ListCourses.Add(listCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", listCourse.CourseId);
            ViewBag.CustomerId = new SelectList(db.Users, "Id", "Name", listCourse.CustomerId);
            return View(listCourse);
        }

        // GET: Admin/ListCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListCourse listCourse = db.ListCourses.Find(id);
            if (listCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", listCourse.CourseId);
            ViewBag.CustomerId = new SelectList(db.Users, "Id", "Name", listCourse.CustomerId);
            return View(listCourse);
        }

        // POST: Admin/ListCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,CourseId")] ListCourse listCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", listCourse.CourseId);
            ViewBag.CustomerId = new SelectList(db.Users, "Id", "Name", listCourse.CustomerId);
            return View(listCourse);
        }

        // GET: Admin/ListCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListCourse listCourse = db.ListCourses.Find(id);
            if (listCourse == null)
            {
                return HttpNotFound();
            }
            return View(listCourse);
        }

        // POST: Admin/ListCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListCourse listCourse = db.ListCourses.Find(id);
            db.ListCourses.Remove(listCourse);
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
