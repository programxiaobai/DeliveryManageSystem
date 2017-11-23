using DeliveryManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeliveryManageSystem.Controllers
{
    public class STOProductsSearchController : Controller
    {
        private STODB db = new STODB();
        // GET: STOProductsSearch
        public ActionResult Index()
        {
            return View(db.STOProducts.ToList());
            //return View();
        }

        //后台对STOProduct表单中BarCode查找请求的处理
        public ActionResult BarCodeSearch(string barCodeSearch)
        {
            var barcode = GetBarCode(barCodeSearch);
            return PartialView(barcode);
        }
        private List<STOProduct> GetBarCode(string barCodeSearch)
        {
            return db.STOProducts.Where(a => a.BarCode.Contains(barCodeSearch)).ToList();
        }
        //自动补充 auto complete
        public ActionResult BarCodeQuickSearch(string term)
        {
            List<STOProduct> b = GetBarCode(term);
            List<STOProduct> list = new List<STOProduct>();

            int logo = 0;
            foreach (STOProduct item in b)
            {
                if (list.Any())
                {
                    if (item.BarCode.Contains(term))
                    {
                        for (int i = 0; i < list.Count(); i++)
                        {
                            if (item.BarCode.Equals(list.ElementAt(i).BarCode))
                            {
                                logo += 1;
                                continue;
                            }
                        }
                        if (logo == 0)
                        {
                            list.Add(item);
                        }
                        logo = 0;
                    }
                }
                else
                {
                    if (item.BarCode.Contains(term))
                    {
                        list.Add(item);
                    }
                }
            }
            var types = list.Select(a => new { value = a.BarCode });
            return Json(types, JsonRequestBehavior.AllowGet);
        }

    }
}