namespace ComprefaceTestApp.DTOs.RecognitionDTOs.RecognizeFacesFromImageWithBase64;

public class RecognizeFacesFromImageWithBase64Request : BaseRecognizeFaceFromImageRequest
{
    public string FileBase64Value { get; set; }
}