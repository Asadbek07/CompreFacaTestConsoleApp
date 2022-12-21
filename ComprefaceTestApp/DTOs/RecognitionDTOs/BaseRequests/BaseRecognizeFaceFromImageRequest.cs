namespace ComprefaceTestApp.DTOs.RecognitionDTOs.BaseRequests;

public class BaseRecognizeFaceFromImageRequest : BaseRecognitionRequest
{
    public int? PredictionCount { get; set; }
}
