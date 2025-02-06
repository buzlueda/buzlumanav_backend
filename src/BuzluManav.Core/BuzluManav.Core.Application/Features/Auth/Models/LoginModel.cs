using System.Text.Json.Serialization;

namespace BuzluManav.Core.Application.Features.Auth.Models;

public record LoginModel(string Email, string Password)
{
    [JsonIgnore]
    public string IpAddress { get; set; } = string.Empty;
    public LoginModel() : this(string.Empty, string.Empty)
    {
    }
}