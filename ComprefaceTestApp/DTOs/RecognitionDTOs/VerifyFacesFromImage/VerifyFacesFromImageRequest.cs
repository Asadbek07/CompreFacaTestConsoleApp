using ComprefaceTestApp.DTOs.RecognitionDTOs.BaseRequests;

namespace ComprefaceTestApp.DTOs.RecognitionDTOs.VerifyFacesFromImage;

public class VerifyFacesFromImageRequest : BaseVerifyFacesFromImageRequest
{
    public string FilePath { get; set; }
    
    public string FileName { get; set; }
}
