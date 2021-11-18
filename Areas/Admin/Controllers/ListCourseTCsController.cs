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
    public class ListCourseTCsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ListCourseTCs
        public ActionResult Index()
        {
            var listCourseTCs = db.ListCourseTCs.Include(l => l.Course).Include(l => l.Teacher);
            return View(listCourseTCs.ToList());
        }

        // GET: Admin/ListCourseTCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListCourseTC listCourseTC = db.ListCourseTCs.Find(id);
            if (listCourseTC == null)
            {
                return HttpNotFound();
            }
            return View(listCourseTC);
        }

        // GET: Admin/ListCourseTCs/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name");
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name");
            return View();
        }

        // POST: Admin/ListCourseTCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeacherId,CourseId")] ListCourseTC listCourseTC)
        {
            if (ModelState.IsValid)
            {
                db.ListCourseTCs.Add(listCourseTC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", listCourseTC.CourseId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", listCourseTC.TeacherId);
            return View(listCourseTC);
        }

        // GET: Admin/ListCourseTCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListCourseTC listCourseTC = db.ListCourseTCs.Find(id);
            if (listCourseTC == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", listCourseTC.CourseId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", listCourseTC.TeacherId);
            return View(listCourseTC);
        }

        // POST: Admin/ListCourseTCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeacherId,CourseId")] ListCourseTC listCourseTC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listCourseTC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", listCourseTC.CourseId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", listCourseTC.TeacherId);
            return View(listCourseTC);
        }

        // GET: Admin/ListCourseTCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListCourseTC listCourseTC = db.ListCourseTCs.Find(id);
            if (listCourseTC == null)
            {
                return HttpNotFound();
            }
            return View(listCourseTC);
        }

        // POST: Admin/ListCourseTCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListCourseTC listCourseTC = db.ListCourseTCs.Find(id);
            db.ListCourseTCs.Remove(listCourseTC);
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
