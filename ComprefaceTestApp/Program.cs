using System.Text.Json;
using ComprefaceTestApp.Services;
using Flurl.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Shared;
using Shared.Constants;
using ComprefaceTestApp.DTOs.ExampleSubject.AddBase64ExampleSubject;

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
                    client.DefaultRequestHeaders.Add("x-api-key", "9cd290ce-62be-4c77-ae68-4a6605453783");
                });
            })
            .Build();

        FlurlHttp.GlobalSettings.BeforeCall += call =>
        {
            call.Request.Headers.Add("x-api-key", "9cd290ce-62be-4c77-ae68-4a6605453783");
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