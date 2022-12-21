using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using ComprefaceTestApp.DTOs;
using ComprefaceTestApp.DTOs.ExampleSubject.AddExampleSubject;
using ComprefaceTestApp.DTOs.ExampleSubject.DeleteAllSubjectExamples;
using ComprefaceTestApp.DTOs.ExampleSubject.DeleteImageById;
using ComprefaceTestApp.DTOs.ExampleSubject.DeleteMultipleExamples;
using ComprefaceTestApp.DTOs.ExampleSubject.DownloadImageById;
using ComprefaceTestApp.DTOs.ExampleSubject.DownloadImageBySubjectId;
using ComprefaceTestApp.DTOs.ExampleSubject.ListAllExampleSubject;
using Flurl;
using Flurl.Http;
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
        var requestUrl = $"{_httpClient.BaseAddress}recognition/faces";

        var response = await requestUrl
            .SetQueryParams(new
            {
                subject = request.Subject,
                det_prob_threshold = request.DetProbThreShold,
            })
            .PostMultipartAsync(mp =>
                mp.AddFile("file", fileName: request.FileName, path: request.FilePath))
            .ReceiveJson<AddExampleSubjectResponse>();

        return response;
    }

    public async Task<ListAllExampleSubjectResponse> GetAllExampleSubjects(ListAllExampleSubjectRequest request)
    {
        var requestUrl = $"{_httpClient.BaseAddress}recognition/faces";

        var response = await requestUrl
            .SetQueryParams(new
            {
                page = request.Page,
                size = request.Size,
                subject = request.Subject,
            })
            .GetJsonAsync<ListAllExampleSubjectResponse>();

        return response;
    }

    public async Task<DeleteAllExamplesResponse> ClearSubjectAsync(DeleteAllExamplesRequest request)
    {
        var requestUrl = $"{_httpClient.BaseAddress}recognition/faces";

        var response = await requestUrl.
            SetQueryParam("subject", request.Subject)
            .DeleteAsync(HttpCompletionOption.ResponseContentRead);

        return await response.ResponseMessage.Content.ReadFromJsonAsync<DeleteAllExamplesResponse>();
    }

    public async Task<DeleteImageByIdResponse> DeleteImageByIdAsync(DeleteImageByIdRequest request)
    {
        var requestUrl = $"{_httpClient.BaseAddress}recognition/faces";

        var response = await requestUrl
            .AppendPathSegment(request.ImageId.ToString())
            .DeleteAsync(HttpCompletionOption.ResponseContentRead);

        return await response.ResponseMessage.Content.ReadFromJsonAsync<DeleteImageByIdResponse>();
    }

    public async Task<List<Face>> DeletMultipleExamples(DeleteMultipleExamplesRequest deleteMultipleExamplesRequest)
    {
        var requestUrl = $"{_httpClient.BaseAddress}recognition/faces";

        var response = await requestUrl
            .AppendPathSegment("delete")
            .SendJsonAsync(HttpMethod.Post, deleteMultipleExamplesRequest.ImageIdList.ToList().Select(x => x.ToString()).ToList());

        return await response.ResponseMessage.Content.ReadFromJsonAsync<List<Face>>();
    }

    public async Task<byte[]> DownloadImageByIdAsync(DownloadImageByIdRequest downloadImageByIdRequest)
    {
        var requestUrl = $"{_httpClient.BaseAddress}static";

        var response = await requestUrl
            .AppendPathSegments(downloadImageByIdRequest.ApiKey.ToString(), "/images/", downloadImageByIdRequest.ImageId.ToString())
            .GetBytesAsync(HttpCompletionOption.ResponseContentRead);

        return response;
    }

    public async Task<byte[]> DownloadImageBySubjectIdAsync(DownloadImageBySubjectIdRequest downloadImageBySubjectIdRequest)
    {
        var requestUrl = $"{_httpClient.BaseAddress}recognition/faces";

        var response = await requestUrl
            .AppendPathSegments(downloadImageBySubjectIdRequest.ImageId.ToString(), "/img")
            .GetBytesAsync(HttpCompletionOption.ResponseContentRead);

        return response;
    }
}