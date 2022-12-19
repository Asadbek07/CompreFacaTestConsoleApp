using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using ComprefaceTestApp.DTOs.ExampleSubject.AddExampleSubject;
using ComprefaceTestApp.DTOs.ExampleSubject.ListAllExampleSubject;
using Shared;

namespace ComprefaceTestApp.Services;

public class ExampleSubjectService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public ExampleSubjectService(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = jsonSerializerOptions;
    }
    
    public async Task<AddExampleSubjectResponse> AddExampleSubject(AddExampleSubjectRequest request)
    {
        var queryBuilder = new QueryBuilder($"{_httpClient.BaseAddress}recognition/faces");
        var requestUrl = queryBuilder
            .SetQuery(request)
            .Build();
        
        var multipartFormContent = new MultipartFormDataContent();
        var fileStreamContent = new StreamContent(File.OpenRead(request.FilePath));
        fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("image/*");
        // fileStreamContent.Headers.Add("x-api-key", "746f45a6-b35e-4087-a79a-a686b3c47fb7");
        multipartFormContent.Add(fileStreamContent, name: "file", fileName: request.FilePath);

        var response =
            await _httpClient.PostAsJsonAsync(requestUrl, multipartFormContent);

        Console.WriteLine(response.RequestMessage);
        var exampleSubjectDto = await response.Content.ReadFromJsonAsync<AddExampleSubjectResponse>(options: _jsonSerializerOptions);

        return exampleSubjectDto;
    }
    public async Task<ListAllExampleSubjectResponse> GetAllExampleSubjects(ListAllExampleSubjectRequest request)
    {
        var queryBuilder = new QueryBuilder($"{_httpClient.BaseAddress}/recognition/faces");
        var requestUrl = queryBuilder.SetQuery(request).Build();
        
        
        var response = await _httpClient.GetFromJsonAsync<ListAllExampleSubjectResponse>(
            requestUrl,
            options: _jsonSerializerOptions);

        return response;
    }
}