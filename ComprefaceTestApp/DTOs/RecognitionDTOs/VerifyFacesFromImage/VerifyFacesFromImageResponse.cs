using ComprefaceTestApp.DTOs.HelperDTOs;
using ComprefaceTestApp.DTOs.RecognitionDTOs.BaseRequests;

namespace ComprefaceTestApp.DTOs.RecognitionDTOs.VerifyFacesFromImage;

public class VerifyFacesFromImageResponse
{
    public IList<Result> Result { get; set; }

    public PluginVersions PluginsVersions { get; set; }
}

public class Result : BaseResult
{
    public string Subject { get; set; }
    
    public decimal Similarity { get; set; }
}

