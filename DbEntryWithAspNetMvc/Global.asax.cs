using Leafing.Data;
using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // 增加这一句，用于注册DbEntryModelBinder
            DbEntryModelBinderHelper.Init();

            // 初始化测试数据
            if(Article.GetCount(Condition.Empty) == 0)
            {
                new Article { Title = "test", Content = "let's do it!", Index = 2 }.Save();
                new Article { Title = "next", Content = "same old same old!", Index = 3 }.Save();
            }
        }
    }
}