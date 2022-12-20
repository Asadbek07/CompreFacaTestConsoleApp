using System.Text.Json.Serialization;
using ComprefaceTestApp.DTOs.HelperDTOs;

namespace ComprefaceTestApp.DTOs.RecognitionDTOs.RecognizeFaceFromImage;

public class RecognizeFaceFromImageResponse
{
    public IList<Result> Result { get; set; }

    public PluginVersions PluginsVersions { get; set; }
}

public class Result
{
    public Age Age { get; set; }

    public Gender Gender { get; set; }

    public Box Box { get; set; }
    
    public IList<SimilarSubject> Subjects { get; set; }

    public IList<decimal> Embedding { get; set; }
    
    public IList<List<int>> Landmarks { get; set; }


    public ExecutionTime ExecutionTime { get; set; }
}
