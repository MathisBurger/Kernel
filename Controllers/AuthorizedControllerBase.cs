using Kernel.Models.Database;
using Kernel.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Kernel.Controllers;

public class AuthorizedControllerBase : ControllerBase
{
    /// <summary>
    /// The AuthClaims of the user
    /// </summary>
    public AuthClaims AuthClaims { get; set; }
    
    /// <summary>
    /// The user that is currently logged in
    /// </summary>
    public User AuthorizedUser { get; set; }
}