using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace ActionFilters.CustomFilters
{
    public class CustomActionFilterAttribute : FilterAttribute, IActionFilter
    {
        Stopwatch watch;
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            watch.Stop();
            filterContext.HttpContext.Response.Write("Action execution time is " + watch.ElapsedTicks.ToString());
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            watch = Stopwatch.StartNew();
        }
    }
}