using ClinicWebAPI.Services;
using ClinicWebAPI.Services.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace ClinicWebAPI.Attributes
{
    public class AuthorizationAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _param;

        public AuthorizationAttribute(string param)
        {
            _param = param;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var _userService = context.HttpContext.RequestServices.GetService(typeof(IUserService)) as IUserService;
            var _roleService = context.HttpContext.RequestServices.GetService(typeof(IRoleService)) as IRoleService;
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedObjectResult("Authentication credentials were not provided.");
                return;
            }
            var user = await _userService.FindByUserNameAsync(context.HttpContext.User.Identity.Name);
            var result = await _roleService.IsInRole(user, _param);
            if (!result)
            {
                context.Result = new UnauthorizedObjectResult("You do not have sufficient permissions to access this resource");
                return;
            }
            await next();
        }
    }
}
