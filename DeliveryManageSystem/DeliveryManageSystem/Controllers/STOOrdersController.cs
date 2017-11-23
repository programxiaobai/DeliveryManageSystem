using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeliveryManageSystem.Models;

namespace DeliveryManageSystem.Controllers
{
    public class STOOrdersController : Controller
    {
        private STODB db = new STODB();

        // GET: STOOrders
        public ActionResult Index()
        {
            return View(db.STOOrders.ToList());
        }

        // GET: STOOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOOrder sTOOrder = db.STOOrders.Find(id);
            if (sTOOrder == null)
            {
                return HttpNotFound();
            }
            return View(sTOOrder);
        }

        // GET: STOOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: STOOrders/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STOOrderId,CustomSheetId,RecordedCommodityId,Number,Price,Name,PhoneNumber,IDCardNumber,Province,City,District,Address,MemberName")] STOOrder sTOOrder)
        {
            if (ModelState.IsValid)
            {
                db.STOOrders.Add(sTOOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sTOOrder);
        }

        // GET: STOOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOOrder sTOOrder = db.STOOrders.Find(id);
            if (sTOOrder == null)
            {
                return HttpNotFound();
            }
            return View(sTOOrder);
        }

        // POST: STOOrders/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STOOrderId,CustomSheetId,RecordedCommodityId,Number,Price,Name,PhoneNumber,IDCardNumber,Province,City,District,Address,MemberName")] STOOrder sTOOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTOOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sTOOrder);
        }

        // GET: STOOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOOrder sTOOrder = db.STOOrders.Find(id);
            if (sTOOrder == null)
            {
                return HttpNotFound();
            }
            return View(sTOOrder);
        }

        // POST: STOOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STOOrder sTOOrder = db.STOOrders.Find(id);
            db.STOOrders.Remove(sTOOrder);
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
