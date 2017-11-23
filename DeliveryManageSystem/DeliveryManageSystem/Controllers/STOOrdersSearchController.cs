using DeliveryManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeliveryManageSystem.Controllers
{

    //一个模型可以对应多个控制器？
    public class STOOrdersSearchController : Controller
    {
        //提供数据库对象进行后续操作
        private STODB db = new STODB();

        // GET: STODBSearch
        public ActionResult Index()
        {
            return View(db.STOOrders.ToList());
        }

        //后台对STOOrder表单中RecordedCommodityId查找请求的处理
        public ActionResult RecordedCommodityIdSearch(string q)
        {
            var CustomSheetId = GetRecordedCommodityId(q);
            return PartialView(CustomSheetId);
        }
        private List<STOOrder> GetRecordedCommodityId(string q)
        {
            return db.STOOrders.Where(a => a.RecordedCommodityId.Contains(q)).ToList();
        }
        public ActionResult RecordedCommodityIdQuickSearch(string term)
        {
            List<STOOrder> b = GetRecordedCommodityId(term);
            List<STOOrder> list = new List<STOOrder>();

            int logo = 0;
            foreach (STOOrder item in b)
            {
                if (list.Any())
                {
                    if (item.RecordedCommodityId.Contains(term))
                    {
                        for (int i = 0; i < list.Count(); i++)
                        {
                            if (item.RecordedCommodityId.Equals(list.ElementAt(i).RecordedCommodityId))
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
                    if (item.RecordedCommodityId.Contains(term))
                    {
                        list.Add(item);
                    }
                }
            }
            var types = list.Select(a => new { value = a.RecordedCommodityId });
            return Json(types, JsonRequestBehavior.AllowGet);
        }


    }
}