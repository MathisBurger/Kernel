using System.Text.Json.Serialization;

namespace Kernel.Models.Request;

public class SetModuleHostRequest : IModuleRequest
{
    [JsonPropertyName("host")]
    public string Host { get; set; }
    
    [JsonPropertyName("accessKey")]
    public string AccessKey { get; set; }
}