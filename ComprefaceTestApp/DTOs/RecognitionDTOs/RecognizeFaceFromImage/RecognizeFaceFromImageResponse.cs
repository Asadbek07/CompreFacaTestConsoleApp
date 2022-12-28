using ComprefaceTestApp.DTOs.HelperDTOs;
using ComprefaceTestApp.DTOs.RecognitionDTOs.BaseRequests;

namespace ComprefaceTestApp.DTOs.RecognitionDTOs.RecognizeFaceFromImage;

public class RecognizeFaceFromImageResponse
{
    public IList<Result> Result { get; set; }

    public PluginVersions PluginsVersions { get; set; }
}

public class Result : BaseResult
{
    public IList<SimilarSubject> Subjects { get; set; }
}
