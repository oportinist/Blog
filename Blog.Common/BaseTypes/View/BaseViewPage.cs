
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Common.BaseTypes.View
{
    public abstract class BaseViewPage : RazorPage
    {
        public string ControllerName => (ViewContext.ActionDescriptor as ControllerActionDescriptor)?.ControllerName;
    }
    public abstract class BaseViewPage<TModel> : RazorPage<TModel>
    {
        public string ControllerName => (ViewContext.ActionDescriptor as ControllerActionDescriptor)?.ControllerName;
    }
}
