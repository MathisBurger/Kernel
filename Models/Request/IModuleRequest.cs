using System.Text.Json.Serialization;

namespace Kernel.Models.Request;

public interface IModuleRequest
{
    [JsonPropertyName("accessKey")]
    public string AccessKey { get; set; }
}