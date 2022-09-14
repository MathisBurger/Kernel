using System.Text.Json.Serialization;

namespace Kernel.Models.Request;

public class LoginRequest
{
    [JsonPropertyName("username")]
    public string Username { get; set; }
    
    [JsonPropertyName("password")]
    public string Password { get; set; }
    
    public LoginRequest(string username, string password)
    {
        Username = username;
        Password = password;
    }
}