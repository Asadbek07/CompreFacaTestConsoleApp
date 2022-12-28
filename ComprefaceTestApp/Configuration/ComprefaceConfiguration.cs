using Microsoft.Extensions.Configuration;

namespace ComprefaceTestApp.Configuration;

public class ComprefaceConfiguration : IComprefaceConfiguration
{
    public string BaseUrl { get; set; }
    
    public string ApiKey { get; set; }

    public ComprefaceConfiguration()
    { }
    
    public ComprefaceConfiguration(string apiKey, string baseUrl)
    {
        BaseUrl = baseUrl;
        ApiKey = apiKey;
    }

    public ComprefaceConfiguration(IConfiguration configuration, string sectionForApiKey, string sectionForBaseUrl)
    {
        BaseUrl = configuration.GetSection(sectionForBaseUrl).Value;
        ApiKey = configuration.GetSection(sectionForApiKey).Value;
    }
}