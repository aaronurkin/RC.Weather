using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace RC.Weather.Api.Filters
{
    public class BadRequestsHandler : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.ToDictionary(item => item.Key, item => item.Value.Errors.Select(e => e.ErrorMessage));
                context.Result = new BadRequestObjectResult(errors);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
