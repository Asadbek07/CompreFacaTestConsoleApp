using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;
using ComprefaceTestApp.DTOs.ExampleSubject.AddExampleSubject;
using ComprefaceTestApp.DTOs.ExampleSubject.ListAllExampleSubject;
using Shared;

namespace ComprefaceTestApp.Services;

public class ExampleSubjectService
{
    private readonly HttpClient _httpClient;

    public ExampleSubjectService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AddExampleSubjectResponse> AddExampleSubject(AddExampleSubjectRequest request)
    {
        var uriBuilder = new UriBuilder($"{_httpClient.BaseAddress}recognition/faces");
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);

        query[nameof(request.Subject).ToLower()] = request.Subject;

        if (request.DetProbThreShold.HasValue)
        {
            query["det_prob_threshold"] = request.DetProbThreShold.Value.ToString();
        }
        
        uriBuilder.Query = query.ToString();

        var requestUrl = uriBuilder.ToString();
        
        var multipartFormContent = new MultipartFormDataContent();
        var fileStreamContent = new StreamContent(File.OpenRead(request.FilePath));
        fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("image/*");
        // fileStreamContent.Headers.Add("x-api-key", "746f45a6-b35e-4087-a79a-a686b3c47fb7");
        multipartFormContent.Add(fileStreamContent, name: "file", fileName: request.FilePath);

        // _httpClient.DefaultRequestHeaders.Add("x-api-key", "746f45a6-b35e-4087-a79a-a686b3c47fb7");
        var response =
            await _httpClient.PostAsJsonAsync(requestUrl, multipartFormContent);

        Console.WriteLine(response.RequestMessage);
        var exampleSubjectDto = await response.Content.ReadFromJsonAsync<AddExampleSubjectResponse>();

        return exampleSubjectDto;
    }
    public async Task<ListAllExampleSubjectResponse> GetAllExampleSubjects(ListAllExampleSubjectRequest request)
    {
        var uriBuilder = new UriBuilder($"{_httpClient.BaseAddress}/recognition/faces");
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        if (request.Page.HasValue)
        {
            query[nameof(request.Page).ToLower()] = request.Page.Value.ToString();
        }
        
        if (request.Size.HasValue)
        {
            query[nameof(request.Size).ToLower()] = request.Size.Value.ToString();
        }
        
        if (request.Subject != null)
        {
            query[nameof(request.Subject).ToLower()] = request.Subject;
        }

        uriBuilder.Query = query.ToString();
        var requestUrl = uriBuilder.ToString();

        var response = await _httpClient.GetFromJsonAsync<ListAllExampleSubjectResponse>(
            requestUrl);

        return response;
    }
}