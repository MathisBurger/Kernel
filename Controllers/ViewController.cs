using System.Net;
using Kernel.Filter;
using Kernel.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Kernel.Controllers;

[ApiController]
//[TypeFilter(typeof(FiltersAuthorization))]
[Route("api/[controller]")]
public class ViewController : AuthorizedControllerBase
{
    
    private DbAccess db;

    public ViewController(DbAccess _db)
    {
        db = _db;
    }

    [HttpGet("[action]/{moduleName}/{route}")]
    //[TypeFilter(typeof(HeadersFilter))]
    public async Task<ContentResult> View(string moduleName, string route)
    {
        var module = await db.ModuleRepository.GetModuleByName(moduleName);
        if (module == null)
        {
            return new ContentResult {
                ContentType = "text/plain",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Content = "Not allowed"
            };
        }

        var client = new HttpClient();
        client.BaseAddress = new Uri(module.ModuleHost!);
        var resp = await client.GetAsync("/" + route);
        return new ContentResult {
            ContentType = "text/html",
            StatusCode = (int)HttpStatusCode.OK,
            Content = await resp.Content.ReadAsStringAsync()
        };
    }
    
}