using System.Text.Json.Serialization;

namespace Kernel.Models.Request;

public class GetDatabaseCredentialsRequest : IModuleRequest
{
    [JsonPropertyName("accessKey")]
    public string AccessKey { get; set; }
}