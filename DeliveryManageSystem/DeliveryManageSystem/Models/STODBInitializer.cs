using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace DeliveryManageSystem.Models
{
    //向快递数据库中填写初始数据，仅仅在程序开始运行时生成
    public class STODBInitializer : DropCreateDatabaseAlways<STODB>
    {
        protected override void Seed(STODB context)
        {
            STODBInit(context);
            base.Seed(context);
        }
        public void STODBInit(STODB context)
        {
            context.STOProducts.Add(new STOProduct
            {
                CommodityId = "8376440",
                BarCode = "4545633021726",
                CommodityNameCN = "TRAIN女的欲望段式阴影着压细腿提臀连裤丝袜",
                CommodityNameJP = "ｼｪｰﾃﾞｨﾝｸﾞｽﾄｯｷﾝｸﾞﾌﾞﾗｯｸ",
                SpecificationCN = "M-L",
                IngredientCN = "ｼｪｰﾃﾞｨﾝｸﾞｽﾄｯｷﾝｸﾞﾌﾞﾗｯｸ",
                IngredientJP = "ｼｪｰﾃﾞｨﾝｸﾞｽﾄｯｷﾝｸﾞﾌﾞﾗｯｸ",
                Price = 52.2,
                NetWt = 45,
                GrossWeight = 0.05,
                NetWeight = 0.045,
                ULR = "http://www.train-shop.net/fs/trainshop/c/yokubou_tights",
                OriginCN = "日本",
                OriginJP = "日本",
                Factory = "株式会社 TRAIN",
                BrandCN = "TRAIN",
                BrandJP = "トレイン"
            });
            context.STOOrders.Add(new STOOrder
            {
                CustomSheetId = "Dingdan001",
                RecordedCommodityId = "8376440",
                Number = 1,
                Price = 52.2,
                Name = "李三",
                PhoneNumber = "13888888888",
                IDCardNumber = "123456789012345000",
                Province = "北京市",
                City = "北京市",
                District = "市中区",
                Address = "芜湖路132号XXX小区6号楼999室",
                MemberName = "TaoBaoZhangHao"
            });
        }
    }
}