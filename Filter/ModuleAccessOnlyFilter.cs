using System.Net;
using Kernel.Controllers;
using Kernel.Models.Request;
using Kernel.Shared;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Kernel.Filter;

public class ModuleAccessOnlyFilter : ActionFilterAttribute
{

    private readonly DbAccess Db;

    public ModuleAccessOnlyFilter(DbAccess db)
    {
        Db = db;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var req = context.ActionArguments.Values.FirstOrDefault();
        if (null == req)
        {
            context.Result = new AuthorizedControllerBase().Unauthorized();
            return;
        }
        var module = await Db.ModuleRepository.GetTaskByKey((req as IModuleRequest).AccessKey);
        if (module == null)
        {
            context.Result = new AuthorizedControllerBase().Unauthorized();
            return;
        }

        await next();
    }

}