﻿using System.Web;
using System.Web.Mvc;

namespace AgileHub.AsyncAwaitMagic.AspNetMvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}