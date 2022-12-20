namespace ComprefaceTestApp.DTOs.RecognitionDTOs.RecognizeFaceFromImage;

public class RecognizeFaceFromImageRequest
{
    public string FilePath { get; set; }

    public string FileName { get; set; }
    
    public int? Limit { get; set; }

    public decimal DetProbThreshold { get; set; }

    public int? PredictionCount { get; set; }

    public IList<string> FacePlugins { get; set; }

    public bool Status { get; set; }
}
