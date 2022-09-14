using Kernel.Filter;
using Kernel.Models.Database;
using Kernel.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Kernel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : AuthorizedControllerBase
{

    private readonly DbAccess Db;

    public UserController(DbAccess _db)
    {
        Db = _db;
    }

    [HttpGet("[action]")]
    [TypeFilter(typeof(FiltersAuthorization))]
    public ActionResult<User> GetCurrentUser() => AuthorizedUser;
}