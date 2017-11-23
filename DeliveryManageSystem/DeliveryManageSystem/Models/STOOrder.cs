using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DeliveryManageSystem.Models
{
    /// <summary>
    /// 订单表单：与海关对接使用
    /// </summary>
    public class STOOrder
    {
        ////Guid类型在生成EF框架中无法自动生成？
        public int STOOrderId { get; set; }
        [Display(Name = "客户单号")]
        public string CustomSheetId { get; set; }
        [Display(Name = "已备案商品管理编码")]
        public string RecordedCommodityId { get; set; }
        [Display(Name = "数量")]
        public int Number { get; set; }
        [Display(Name = "商品单价")]
        public double Price { get; set; }
        [Display(Name = "收件人姓名")]
        public string Name { get; set; }
        [Display(Name = "收货人电话")]
        public string PhoneNumber { get; set; }
        [Display(Name = "收件人身份证号码")]
        public string IDCardNumber { get; set; }
        [Display(Name = "收件人省份")]
        public string Province { get; set; }
        [Display(Name = "收件人市")]
        public string City { get; set; }
        [Display(Name = "收件人区县")]
        public string District { get; set; }
        [Display(Name = "收货人详细地址")]
        public string Address { get; set; }
        [Display(Name = "买家会员名")]
        public string MemberName { get; set; }

        //提交时间
        //public DateTime time { get; set; }

    }
}