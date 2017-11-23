using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveryManageSystem.Models
{
    /// <summary>
    /// 快递定义：可有多个订单，每个订单可有多个商品
    /// </summary>
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public Guid CustomSheetId { get; set; }
        public Guid CommodityId { get; set; }
        public bool Record { get; set; }
        public List<STOOrder> Orders { get; set; }
    }
}