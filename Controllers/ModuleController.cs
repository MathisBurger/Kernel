using Kernel.Filter;
using Kernel.Models.Database;
using Kernel.Models.Request;
using Kernel.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    [HttpGet("[action]")]
    [TypeFilter(typeof(FiltersAuthorization))]
    public async Task<ActionResult<Module[]>> GetAllModules()
    {
        var modules = await Db.ModuleRepository.FindAll();
        return Ok(modules);
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

    [HttpPost("[action]")]
    [TypeFilter(typeof(ModuleAccessOnlyFilter))]
    public async Task<ActionResult<string>> GetDatabaseCredentials([FromBody] GetDatabaseCredentialsRequest request)
    {
        var module = await Db.ModuleRepository.GetTaskByKey(request.AccessKey);
        if (module == null)
        {
            return BadRequest();
        }

        return Ok(Db.Database.Database.GetConnectionString());
    }
}