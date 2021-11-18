﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnCN2021.Models;

namespace DoAnCN2021.Areas.Admin.Controllers
{
    public class TeachersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Teachers
        public ActionResult Index()
        {
            return View(db.Teachers.ToList());
        }

        // GET: Admin/Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Admin/Teachers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Image")] Teacher teacher, HttpPostedFileBase image)
        {
            if (image == null)
            {
                ViewBag.Thongbao = "vui long chon anh";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var filename = Path.GetFileName(image.FileName);

                    var path = Path.Combine(Server.MapPath("~/Content/Image/") + filename);


                    image.SaveAs(path);

                    teacher.Image = "/Content/Image/" + filename;

                    db.Teachers.Add(teacher);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
           

            return View(teacher);
        }

        // GET: Admin/Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Admin/Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Image")] Teacher teacher, HttpPostedFileBase image)
        {
            if (image == null)
            {
                ViewBag.Thongbao = "vui long chon anh";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {


                    var filename = Path.GetFileName(image.FileName);

                    var path = Path.Combine(Server.MapPath("~/Content/Image/") + filename);


                    image.SaveAs(path);

                    teacher.Image = "/Content/Image/" + filename;


                    db.Entry(teacher).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
          
            return View(teacher);
        }

        // GET: Admin/Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Admin/Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
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
