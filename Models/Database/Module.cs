namespace Kernel.Models.Database;

public class Module : Entity
{
    
    public string ModuleName { get; set; }
    
    public string? ModuleHost { get; set; }
    
    [System.Text.Json.Serialization.JsonIgnore]
    public string ModuleKey { get; set; }
    
}