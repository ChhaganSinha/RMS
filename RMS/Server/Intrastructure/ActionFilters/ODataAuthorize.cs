using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RMS.Server.Intrastructure.ActionFilters
{
    public class ODataAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext?.User?.Identity?.IsAuthenticated ?? false)
            {
                return;
            }

            context.Result = new ForbidResult();
        }
    }
}
