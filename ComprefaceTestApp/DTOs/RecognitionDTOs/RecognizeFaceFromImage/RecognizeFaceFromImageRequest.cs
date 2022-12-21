using System.Text.Json.Serialization;
using ComprefaceTestApp.DTOs.RecognitionDTOs.BaseRequests;

namespace ComprefaceTestApp.DTOs.RecognitionDTOs.RecognizeFaceFromImage;

public class RecognizeFaceFromImageRequest : BaseRecognizeFaceFromImageRequest
{
    public string FilePath { get; set; }

    public string FileName { get; set; }
}
