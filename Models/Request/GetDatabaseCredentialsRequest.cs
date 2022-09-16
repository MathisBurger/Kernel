namespace Kernel.Models.Request;

public class GetDatabaseCredentialsRequest : IModuleRequest
{
    public string AccessKey { get; set; }
}