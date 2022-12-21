using System.Text.Json.Serialization;

namespace ComprefaceTestApp.DTOs.RecognitionDTOs.RecognizeFaceFromImage;

public class RecognizeFaceFromImageRequest : BaseRecognizeFaceFromImageRequest
{
    public string FilePath { get; set; }

    public string FileName { get; set; }
}
