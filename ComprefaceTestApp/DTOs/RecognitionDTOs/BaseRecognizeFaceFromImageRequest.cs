namespace ComprefaceTestApp.DTOs.RecognitionDTOs;

public class BaseRecognizeFaceFromImageRequest
{
    public int? Limit { get; set; }

    public decimal DetProbThreshold { get; set; }

    public int? PredictionCount { get; set; }

    public IList<string> FacePlugins { get; set; }

    public bool Status { get; set; }
}