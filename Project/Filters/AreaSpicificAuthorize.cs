using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Filters
{
    public class AreaSpecificAuthorize : AuthorizeAttribute
    {
        string _areaName;
        public AreaSpecificAuthorize(string areaName)
        {
            if (string.IsNullOrWhiteSpace(areaName))
                throw new ArgumentNullException();
            _areaName = areaName;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.RouteData.DataTokens["Area"].ToString() == _areaName)
                base.OnAuthorization(filterContext);
        }
    }
}