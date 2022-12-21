using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using ComprefaceTestApp.DTOs.ExampleSubject.AddExampleSubject;
using ComprefaceTestApp.DTOs.ExampleSubject.ListAllExampleSubject;
using Flurl;
using Flurl.Http;
using Shared;
using Shared.Constants;

namespace ComprefaceTestApp.Services;

public class ExampleSubjectService
{
    public async Task<AddExampleSubjectResponse> AddExampleSubject(AddExampleSubjectRequest request)
    {
        var requestUrl = $"{RequestConstants.BaseUrl}recognition/faces";

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
        var requestUrl = $"{RequestConstants.BaseUrl}recognition/faces";

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
}