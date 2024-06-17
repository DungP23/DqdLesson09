using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LttLesson09.Models;

namespace DqdLesson09.Controllers
{
    public class DqdKhoaController : Controller
    {
        private DqdK22CNTLesson09DbEntities2 db = new DqdK22CNTLesson09DbEntities2();

        // GET: LttKhoas
        public ActionResult DqdIndex()
        {
            return View(db.DqdKhoa.ToList());
        }

        // GET: LttKhoas/Details/5
        public ActionResult DqdDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DqdKhoa lttKhoa = db.DqdKhoa.Find(id);
            if (dqdKhoa == null)
            {
                return HttpNotFound();
            }
            return View(dqdKhoa);
        }

        // GET:  DqdKhoas/Create
        public ActionResult DqdCreate()
        {
            return View();
        }

        // POST:  DqdKhoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DqdCreate([Bind(Include = " DqdMaKH, DqdTenKH, DqdTrangThai")] DqdKhoa dqdKhoa)
        {
            if (ModelState.IsValid)
            {
                db.DqdKhoa.Add(dqdKhoa);
                db.SaveChanges();
                return RedirectToAction(" DqdIndex");
            }

            return View(dqdKhoa);
        }

        // GET:  DqdKhoas/Edit/5
        public ActionResult DqdEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DqdKhoa dqdKhoa = db.DqdKhoa.Find(id);
            if (dqdKhoa == null)
            {
                return HttpNotFound();
            }
            return View(dqdKhoa);
        }

        // POST: LttKhoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DqdMaKH, DqdTenKH, DqdTrangThai")] DqdKhoa dqdKhoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dqdKhoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(" DqdIndex");
            }
            return View(dqdKhoa);
        }

        // GET: LttKhoas/Delete/5
        public ActionResult DqdDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DqdKhoa dqdKhoa = db.DqdKhoa.Find(id);
            if (dqdKhoa == null)
            {
                return HttpNotFound();
            }
            return View(dqdKhoa);
        }

        // POST: LttKhoas/Delete/5
        [HttpPost, ActionName(" DqdDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LttKhoa dqdKhoa = db.DqdKhoa.Find(id);
            db.DqdKhoa.Remove(dqdKhoa);
            db.SaveChanges();
            return RedirectToAction(" DqdIndex");
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