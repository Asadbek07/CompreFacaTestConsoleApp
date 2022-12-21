using System.Net.Http.Json;
using ComprefaceTestApp.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using ComprefaceTestApp.DTOs.RecognitionDTOs.RecognizeFacesFromImageWithBase64;
using Flurl;
using Flurl.Http;
using Shared.Constants;

namespace ComprefaceTestApp.Services;

public class RecognitionService
{
    private readonly HttpClient _httpClient;

    public RecognitionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<RecognizeFaceFromImageResponse> RecognizeFaceFromImage(RecognizeFaceFromImageRequest request)
    {
        var requestUrl = $"{_httpClient.BaseAddress}recognition/recognize";

        var response = await requestUrl
            .SetQueryParams(new
            {
                limit = request.Limit,
                prediction_count = request.PredictionCount,
                det_prob_threshold = request.DetProbThreshold,
                face_plugins = string.Join(",", request.FacePlugins),
                status = request.Status,
            })
            .PostMultipartAsync(mp =>
                mp.AddFile("file", fileName: request.FileName, path: request.FilePath))
            .ReceiveJson<RecognizeFaceFromImageResponse>();

        return response;
    }

    public async Task<RecognizeFaceFromImageResponse> RecognizeFaceFromBase64File(
        RecognizeFacesFromImageWithBase64Request request)
    {
        var requestUrl = $"{RequestConstants.BaseUrl}recognition/recognize";

        var response = await requestUrl
            .SetQueryParams(new
            {
                limit = request.Limit,
                prediction_count = request.PredictionCount,
                det_prob_threshold = request.DetProbThreshold,
                face_plugins = string.Join(",", request.FacePlugins),
                status = request.Status,
            })
            .PostJsonAsync(body: new { file = request.FileBase64Value })
            .ReceiveJson<RecognizeFaceFromImageResponse>();

        return response;
    }
}