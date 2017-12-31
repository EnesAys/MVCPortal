using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcPortal.Admin.CustomFilter
{
    public class LoginFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)//Action method çalıştırıldıktan sonra tetiklenir
        {
            HttpContextWrapper wrapper = new HttpContextWrapper(HttpContext.Current);
            var SessionControl = filterContext.HttpContext.Session["KullaniciEmail"];
            if (SessionControl == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "controller", "Account" }, { "action", "Login" } });
                   
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)//Action method çalıştırıldığında tetiklenir
        {
        
        }
    }
}