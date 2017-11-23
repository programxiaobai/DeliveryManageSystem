using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DeliveryManageSystem.Models
{
    /// <summary>
    /// 商品信息表单：与海关对接使用
    /// </summary>
    public class STOProduct
    {
        public int STOProductId { get; set; }
        [Display(Name = "商品管理编码")]
        public string CommodityId { get; set; }
        [Display(Name = "商品条形码")]
        public string BarCode { get; set; }
        [Display(Name = "商品名称(中文)")]
        public string CommodityNameCN { get; set; }
        [Display(Name = "商品名称(日本語)")]
        public string CommodityNameJP { get; set; }
        [Display(Name = "规格型号(中文)")]
        public string SpecificationCN { get; set; }
        [Display(Name = "成分表(中文)")]
        public string IngredientCN { get; set; }
        [Display(Name = "成分表(日本語)")]
        public string IngredientJP { get; set; }
        [Display(Name = "商品价格(元)")]
        public double Price { get; set; }
        [Display(Name = "净含量")]
        public double NetWt { get; set; }
        [Display(Name = "毛重(KG)")]
        public double GrossWeight { get; set; }
        [Display(Name = "净重(KG)")]
        public double NetWeight { get; set; }
        [Display(Name = "厂商商品描述(销售网址)(ULR)")]
        public string ULR { get; set; }
        [Display(Name = "产地(中文)")]
        public string OriginCN { get; set; }
        [Display(Name = "产地(日本語)")]
        public string OriginJP { get; set; }
        [Display(Name = "厂家")]
        public string Factory { get; set; }
        [Display(Name = "品牌(中文)")]
        public string BrandCN { get; set; }
        [Display(Name = "品牌(日文)")]
        public string BrandJP { get; set; }
    }
}