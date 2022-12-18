using System.Text.Json;
using ComprefaceTestApp.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
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

        var serviceProvider = host.Services;

        var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
        var httpClient = httpClientFactory.CreateClient(Compreface);
        var jsonOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        
        var subjectService = new SubjectService(httpClient, jsonOptions);
        var exampleSubjectService = new ExampleSubjectService(httpClient, jsonOptions);
        
        
        // TODO: Fix sending http request to Add Example Subject endpoint!!! 
        // var addExampleSubjectRequest = new AddExampleSubjectRequest()
        // {
        //     DetProbThreShold = 0.81m,
        //     FilePath = @"C:\Users\asindarov\Desktop\Personal\Photo\photo_2022-12-14_10-55-57.jpg",
        //     Subject = "Asadbek Sindarov",
        // };
        //
        // var addExampleSubjectResponse = await exampleSubjectService.AddExampleSubject(addExampleSubjectRequest);
        //
        // Console.WriteLine(addExampleSubjectResponse.Subject);
        // Console.WriteLine(addExampleSubjectResponse.ImageId);
    }
}