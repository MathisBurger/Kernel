namespace Kernel.Models.Request;

public class SetModuleHostRequest : IModuleRequest
{
    public string Host { get; set; }
    public string AccessKey { get; set; }
}