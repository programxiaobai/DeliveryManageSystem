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
    public class STOProductsController : Controller
    {
        private STODB db = new STODB();

        // GET: STOProducts
        public ActionResult Index()
        {
            return View(db.STOProducts.ToList());
        }

        // GET: STOProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOProduct sTOProduct = db.STOProducts.Find(id);
            if (sTOProduct == null)
            {
                return HttpNotFound();
            }
            return View(sTOProduct);
        }

        // GET: STOProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: STOProducts/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STOProductId,CommodityId,BarCode,CommodityNameCN,CommodityNameJP,SpecificationCN,IngredientCN,IngredientJP,Price,NetWt,GrossWeight,NetWeight,ULR,OriginCN,OriginJP,Factory,BrandCN,BrandJP")] STOProduct sTOProduct)
        {
            if (ModelState.IsValid)
            {
                db.STOProducts.Add(sTOProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sTOProduct);
        }

        // GET: STOProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOProduct sTOProduct = db.STOProducts.Find(id);
            if (sTOProduct == null)
            {
                return HttpNotFound();
            }
            return View(sTOProduct);
        }

        // POST: STOProducts/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STOProductId,CommodityId,BarCode,CommodityNameCN,CommodityNameJP,SpecificationCN,IngredientCN,IngredientJP,Price,NetWt,GrossWeight,NetWeight,ULR,OriginCN,OriginJP,Factory,BrandCN,BrandJP")] STOProduct sTOProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTOProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sTOProduct);
        }

        // GET: STOProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STOProduct sTOProduct = db.STOProducts.Find(id);
            if (sTOProduct == null)
            {
                return HttpNotFound();
            }
            return View(sTOProduct);
        }

        // POST: STOProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STOProduct sTOProduct = db.STOProducts.Find(id);
            db.STOProducts.Remove(sTOProduct);
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
