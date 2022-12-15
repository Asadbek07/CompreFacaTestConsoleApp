using System.Text.Json.Serialization;

namespace ComprefaceTestApp.DTOs.ExampleSubject.AddExampleSubject;

public class AddExampleSubjectRequest
{
    public string Subject { get; set; }
    
    [JsonPropertyName("det_prob_threshold")]
    public decimal? DetProbThreShold { get; set; }

    public string FilePath { get; set; }
}