﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcApp
{
public class MvcApplication : System.Web.HttpApplication
{
    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        ModelBinderProviders.BinderProviders.Add(new FooModelBinderProvider());
        ModelBinders.Binders.Add(typeof(Foo), new BazModelBinder());
        ModelBinders.Binders.Add(typeof(Bar), new BarModelBinder());
    }
}
}
