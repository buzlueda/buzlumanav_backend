namespace BuzluManav.Presentation.WebAPI.Infrastructure;
public class WebAPIConfiguration
{
    public string APIDomain { get; set; } = string.Empty;
    public string[] AllowedOrigins { get; set; } = [];
}