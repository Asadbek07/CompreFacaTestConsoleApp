using ComprefaceTestApp.DTOs.RecognitionDTOs.BaseRequests;

namespace ComprefaceTestApp.DTOs.RecognitionDTOs.VerifyFacesFromImageWithBase64;

public class VerifyFacesFromImageWithBase64Request : BaseVerifyFacesFromImageRequest
{
    public string FileBase64Value { get; set; }
}
