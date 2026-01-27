namespace HomeServer.ExtApi.Models.Config;

public class NetdataOptions
{
    public const string SectionName = "Netdata";
    public string BaseUrl { get; set; } = string.Empty;
    public string BearerToken { get; set; } = string.Empty;
    public string XAuthToken { get; set; } = string.Empty;
}