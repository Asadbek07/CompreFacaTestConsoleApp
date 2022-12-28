using ComprefaceTestApp.Configuration;
using ComprefaceTestApp.DTOs.RecognitionDTOs.RecognizeFaceFromImage;
using ComprefaceTestApp.DTOs.RecognitionDTOs.RecognizeFacesFromImageWithBase64;
using ComprefaceTestApp.DTOs.RecognitionDTOs.VerifyFacesFromImage;
using ComprefaceTestApp.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64;
using Flurl;
using Flurl.Http;

namespace ComprefaceTestApp.Services;

public class RecognitionService
{
    private readonly ComprefaceConfiguration _comprefaceConfiguration;

    public RecognitionService(ComprefaceConfiguration comprefaceConfiguration)
    {
        _comprefaceConfiguration = comprefaceConfiguration;
    }
    
    public async Task<RecognizeFaceFromImageResponse> RecognizeFaceFromImage(RecognizeFaceFromImageRequest request)
    {
        var requestUrl = $"{_comprefaceConfiguration.BaseUrl}recognition/recognize";

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
        var requestUrl = $"{_comprefaceConfiguration.BaseUrl}recognition/recognize";

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

    public async Task<VerifyFacesFromImageResponse> VerifyFacesFromImage(VerifyFacesFromImageRequest request)
    {
        var requestUrl = $"{_comprefaceConfiguration.BaseUrl}recognition/faces/{request.ImageId}/verify";

        var response = await requestUrl
            .SetQueryParams(new
            {
                limit = request.Limit,
                det_prob_threshold = request.DetProbThreshold,
                face_plugins = string.Join(",", request.FacePlugins),
                status = request.Status,
            })
            .PostMultipartAsync(mp =>
                mp.AddFile("file", fileName: request.FileName, path: request.FilePath))
            .ReceiveJson<VerifyFacesFromImageResponse>();

        return response;
    }
    
    public async Task<VerifyFacesFromImageResponse> VerifyFacesFromBase64File(VerifyFacesFromImageWithBase64Request request)
    {
        var requestUrl = $"{_comprefaceConfiguration.BaseUrl}recognition/faces/{request.ImageId}/verify";

        var response = await requestUrl
            .SetQueryParams(new
            {
                limit = request.Limit,
                det_prob_threshold = request.DetProbThreshold,
                face_plugins = string.Join(",", request.FacePlugins),
                status = request.Status,
            })
            .PostJsonAsync(body: new {file = request.FileBase64Value})
            .ReceiveJson<VerifyFacesFromImageResponse>();

        return response;
    }
}