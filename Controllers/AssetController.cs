using Microsoft.AspNetCore.Mvc;

namespace Kernel.Controllers;

[ApiController]
public class AssetController : ControllerBase
{

    [HttpGet("/css/{name}")]
    public IActionResult CssServer([FromRoute] string name)
    {
        return StreamFile("css", name);
    }

    private IActionResult StreamFile(string dir, string name)
    {
        string path = Path.Combine(Path.Combine("wwwroot", dir), name);
        //return Ok(path);
 
        //Read the File data into Byte Array.
        byte[] bytes = System.IO.File.ReadAllBytes(path);
 
        //Send the File to Download.
        return File(bytes, "application/octet-stream", name);
    }
    
}