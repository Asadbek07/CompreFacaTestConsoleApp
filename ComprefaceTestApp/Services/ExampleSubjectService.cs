using System.Net.Http.Json;
using System.Web;
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