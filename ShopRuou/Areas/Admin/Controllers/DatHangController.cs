﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopRuou.Models;

namespace ShopRuou.Areas.Admin.Controllers
{
    public class DatHangController : Controller
    {
        private ShopRuouEntities db = new ShopRuouEntities();

        // GET: DatHang
        public ActionResult Index()
        {
            var datHang = db.DatHang.Include(d => d.KhachHang).Include(d => d.TaiKhoan);
            return View(datHang.ToList());
        }

        // GET: DatHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatHang datHang = db.DatHang.Find(id);
            if (datHang == null)
            {
                return HttpNotFound();
            }
            return View(datHang);
        }

        // GET: DatHang/Create
        public ActionResult Create()
        {
            ViewBag.KhachHang_ID = new SelectList(db.KhachHang, "ID", "HoTen");
            ViewBag.TaiKhoan_ID = new SelectList(db.TaiKhoan, "ID", "HoTen");
            return View();
        }

        // POST: DatHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TaiKhoan_ID,KhachHang_ID,DienThoaiGiaoHang,DiaChiGiaoHang,NgayDatHang,TinhTrang")] DatHang datHang)
        {
            if (ModelState.IsValid)
            {
                db.DatHang.Add(datHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KhachHang_ID = new SelectList(db.KhachHang, "ID", "HoTen", datHang.KhachHang_ID);
            ViewBag.TaiKhoan_ID = new SelectList(db.TaiKhoan, "ID", "HoTen", datHang.TaiKhoan_ID);
            return View(datHang);
        }

        // GET: DatHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatHang datHang = db.DatHang.Find(id);
            if (datHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.KhachHang_ID = new SelectList(db.KhachHang, "ID", "HoTen", datHang.KhachHang_ID);
            ViewBag.TaiKhoan_ID = new SelectList(db.TaiKhoan, "ID", "HoTen", datHang.TaiKhoan_ID);
            return View(datHang);
        }

        // POST: DatHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TaiKhoan_ID,KhachHang_ID,DienThoaiGiaoHang,DiaChiGiaoHang,NgayDatHang,TinhTrang")] DatHang datHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KhachHang_ID = new SelectList(db.KhachHang, "ID", "HoTen", datHang.KhachHang_ID);
            ViewBag.TaiKhoan_ID = new SelectList(db.TaiKhoan, "ID", "HoTen", datHang.TaiKhoan_ID);
            return View(datHang);
        }

        // GET: DatHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatHang datHang = db.DatHang.Find(id);
            if (datHang == null)
            {
                return HttpNotFound();
            }
            return View(datHang);
        }

        // POST: DatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatHang datHang = db.DatHang.Find(id);
            db.DatHang.Remove(datHang);
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
