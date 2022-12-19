using System.Text.Json;
using ComprefaceTestApp.DTOs.ExampleSubject.AddExampleSubject;
using ComprefaceTestApp.DTOs.ExampleSubject.ListAllExampleSubject;
using ComprefaceTestApp.DTOs.SubjectDTOs.AddSubject;
using ComprefaceTestApp.DTOs.SubjectDTOs.RenameSubject;
using ComprefaceTestApp.Services;
using Flurl.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Shared;
using Shared.Constants;

namespace ComprefaceTestApp;

public class Program
{
    private static string Compreface => nameof(Compreface);
    
    static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(s =>
            {
                s.AddHttpClient(Compreface, (serviceProvider, client) =>
                {
                    client.BaseAddress = new Uri(RequestConstants.BaseUrl);
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36");
                    client.DefaultRequestHeaders.Add("x-api-key", "746f45a6-b35e-4087-a79a-a686b3c47fb7");
                });
            })
            .Build();

        FlurlHttp.GlobalSettings.BeforeCall += call =>
        {
            call.Request.Headers.Add("x-api-key", "746f45a6-b35e-4087-a79a-a686b3c47fb7");
        };
        
        var jsonOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        FlurlHttp.GlobalSettings.JsonSerializer = new SystemJsonSerializer(jsonOptions);
        
        var serviceProvider = host.Services;

        var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
        var httpClient = httpClientFactory.CreateClient(Compreface);
        
        var subjectService = new SubjectService(httpClient);
        var exampleSubjectService = new ExampleSubjectService(httpClient, jsonOptions);
        
    }
}