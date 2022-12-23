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
using ComprefaceTestApp.DTOs.ExampleSubject.DeleteImageById;

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
                    client.DefaultRequestHeaders.Add("x-api-key", "e468da55-b884-4865-8c83-f1ad5775f00d");
                });
            })
            .Build();

        FlurlHttp.GlobalSettings.BeforeCall += call =>
        {
            call.Request.Headers.Add("x-api-key", "e468da55-b884-4865-8c83-f1ad5775f00d");
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

        await exampleSubjectService.DeletMultipleExamplesAsync(
            new DTOs.ExampleSubject.DeleteMultipleExamples.DeleteMultipleExamplesRequest()
            {
                ImageIdList = new List<Guid>
                {
                    Guid.Parse("c5bc0e91-c3c1-45a0-87e3-5e3beff17106"),
                    Guid.Parse("8c8d909d-40a1-471d-ba2a-cd8200d85754")
                }
            });
    }
}