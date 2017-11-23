using DeliveryManageSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveryManageSystem.AuthorityDefine
{
    //添加权限控制属性
    public class RoleManage : RoleManager<IdentityRole, String>, IDisposable
    {
        public RoleManage(IRoleStore<IdentityRole, string> store) : base(store)
        {
        }
        public static RoleManage Create(IdentityFactoryOptions<RoleManage> options, IOwinContext context)
        {
            return new RoleManage(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
        }
    }

}