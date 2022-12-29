using System.Text.Json;
using ComprefaceTestApp.Services;
using Flurl.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Shared.Constants;
using Shared.CustomJSONSerializer;

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
                    client.DefaultRequestHeaders.Add("User-Agent",
                        RequestConstants.UserAgent);
                });
            })
            .Build();

        FlurlHttp.GlobalSettings.BeforeCall += call =>
        {
            call.Request.Headers.Add("x-api-key", RequestConstants.API_KEY);
        };

        var jsonOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = SnakeCaseToCamelCaseNamingPolicy.Policy,
            PropertyNameCaseInsensitive = true,
        };

        FlurlHttp.GlobalSettings.JsonSerializer = new SystemJsonSerializer(jsonOptions);

        var serviceProvider = host.Services;

        var subjectService = new SubjectService();
        var exampleSubjectService = new ExampleSubjectService();
        var recognitionService = new RecognitionService();

        await exampleSubjectService.DeletMultipleExamplesAsync(
            new DTOs.ExampleSubjectDTOs.DeleteMultipleExamples.DeleteMultipleExampleRequest()
            {
                ImageIdList = new List<Guid>
                {
                    Guid.Parse("39bbf8c8-e7de-4b0c-9035-bbbe3621ab89"),
                    Guid.Parse("208a3002-75cd-4b95-93aa-89c727e454da")
                }
            });
    }
}