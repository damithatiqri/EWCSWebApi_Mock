﻿using System.Web;
using System.Web.Mvc;

namespace EWCSWebApi_Mock
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
