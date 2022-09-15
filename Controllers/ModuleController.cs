using Kernel.Filter;
using Kernel.Models.Request;
using Kernel.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Kernel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModuleController : AuthorizedControllerBase
{
    private DbAccess Db;

    public ModuleController(DbAccess _db)
    {
        Db = _db;
    }

    [HttpPost("[action]")]
    [TypeFilter(typeof(ModuleAccessOnlyFilter))]
    public async Task<ActionResult> SetModuleHost([FromBody] SetModuleHostRequest request)
    {
        var module = await Db.ModuleRepository.GetTaskByKey(request.AccessKey);
        if (module == null)
        {
            return BadRequest();
        }

        module.ModuleHost = request.Host;
        Db.Database.Modules.Update(module);
        await Db.Database.SaveChangesAsync();
        return Ok();
    }
}