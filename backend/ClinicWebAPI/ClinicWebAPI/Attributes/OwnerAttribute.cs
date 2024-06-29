using ClinicWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClinicWebAPI.Attributes
{
    public class OwnerAttribute : Attribute, IAsyncActionFilter
    {
        public OwnerAttribute() { }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var _userService = context.HttpContext.RequestServices.GetService(typeof(IUserService)) as IUserService;

            // Check Current User
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedObjectResult("Authentication credentials were not provided.");
                return;
            }
            var isId = context.ActionArguments.ContainsKey("id");
            if (isId)
            {
                var id = context.ActionArguments["id"];
                var user = await _userService.FindByUserNameAsync(context.HttpContext.User.Identity.Name);

                Console.WriteLine(user.Id);
                if (!user.Id.Equals(id))
                {
                    context.Result = new UnauthorizedObjectResult("Authentication credentials do not have sufficient permissions to use the resource");
                    return;
                }
            } 
            else
            {
                context.Result = new UnauthorizedObjectResult("Authentication credentials were not provided.");
                return;
            }
            await next();
        }
    }
}
