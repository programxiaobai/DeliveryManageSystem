using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using DeliveryManageSystem.AuthorityDefine;
using System;


//此文件在系统启动时作用，创建关于用户的数据库
//需求：每一个用户添加Role属性，做登录时判断用

namespace DeliveryManageSystem.Models
{
    // 可以通过向 ApplicationUser 类添加更多属性来为用户添加配置文件数据。若要了解详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=317594。
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // 请注意，authenticationType 必须与 CookieAuthenticationOptions.AuthenticationType 中定义的相应项匹配
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在此处添加自定义用户声明
            return userIdentity;
        }
        //注册时添加用户名选项
        public string Name { get; set; }

        //添加用户权限
        public int UserRole { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        ////类中定义的静态方法，在程序启动后执行一次？
        //static ApplicationDbContext()
        //{
        //    Database.SetInitializer(new IdentityDbInit());
        //}
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
    
    ////这里进行初始化
    public class IdentityDbInit : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            ApplicationDbContextInit(context);
            base.Seed(context);
        }
        public void ApplicationDbContextInit(ApplicationDbContext context)
        {
            ApplicationUserManager userMgr = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            userMgr.UserValidator = new UserValidator<ApplicationUser>(userMgr)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            RoleManage roleMgr = new RoleManage(new RoleStore<IdentityRole>(context));
            string SuperUserPassword = "111111";

            if (!roleMgr.RoleExists(RoleDefine.SuperUser))
            {
                roleMgr.Create(new IdentityRole(RoleDefine.SuperUser));
            }
            if (!roleMgr.RoleExists(RoleDefine.User))
            {
                roleMgr.Create(new IdentityRole(RoleDefine.User));
            }
            this.AddUser(userMgr, "sbo8711@outlook.com", "SuperUser", "sbo8711@outlook.com", SuperUserPassword, RoleDefine.SuperUser);
            this.AddUser(userMgr, "test@163.com", "User", "test@163.com", SuperUserPassword, RoleDefine.User);
        }
        //属性与RegisterViewModel对应?
        //AddToRole的参数为Id?主键属性是否自动添加？
        private void AddUser(ApplicationUserManager userMgr, string id, string userName, string email, string password, string roleType)
        {
            try
            {
                ApplicationUser user = userMgr.FindByName(userName);
                if(user == null)
                {
                    var result = userMgr.Create(new ApplicationUser { Id = id, UserName = userName, Email = email}, password);
                    user = userMgr.FindByName(userName);
                }
                if (!userMgr.IsInRole(user.Id, roleType))
                {
                    userMgr.AddToRole(user.Id, roleType);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
