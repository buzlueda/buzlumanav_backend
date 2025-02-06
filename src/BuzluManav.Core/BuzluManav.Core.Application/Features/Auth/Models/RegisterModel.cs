using System.Text.Json.Serialization;

namespace BuzluManav.Core.Application.Features.Auth.Models;

public record RegisterModel(string FirstName, string LastName, string Email, string Phone, string Password, string ConfirmPassword)
{
    [JsonIgnore]
    public string? IpAddress { get; set; }
    public RegisterModel() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty) { }
}