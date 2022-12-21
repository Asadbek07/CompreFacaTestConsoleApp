using ComprefaceTestApp.DTOs.HelperDTOs;

namespace ComprefaceTestApp.DTOs.RecognitionDTOs.VerifyFacesFromImage;

public class VerifyFacesFromImageResponse
{
    public IList<Result> Result { get; set; }

    public PluginVersions PluginsVersions { get; set; }
}

public class Result
{
    public Box Box { get; set; }

    public string Subject { get; set; }
    
    public decimal Similarity { get; set; }
    
    public Age Age { get; set; }

    public Gender Gender { get; set; }

    public Mask Mask { get; set; }

    public IList<decimal> Embedding { get; set; }

    public IList<IList<decimal>> Landmarks { get; set; }

    public ExecutionTime ExecutionTime { get; set; }
}

