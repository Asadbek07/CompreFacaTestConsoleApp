namespace ComprefaceTestApp.DTOs.RecognitionDTOs.BaseRequests;

public class BaseVerifyFacesFromImageRequest : BaseRecognitionRequest
{
    public Guid ImageId { get; set; }
}
