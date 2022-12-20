﻿using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using ComprefaceTestApp.DTOs.ExampleSubject.AddExampleSubject;
using ComprefaceTestApp.DTOs.ExampleSubject.DeleteAllSubjectExamples;
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
}