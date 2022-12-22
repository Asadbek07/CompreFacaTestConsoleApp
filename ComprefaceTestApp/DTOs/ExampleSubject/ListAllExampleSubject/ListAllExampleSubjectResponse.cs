using System.Text.Json.Serialization;

namespace ComprefaceTestApp.DTOs.ExampleSubject.ListAllExampleSubject;

public class ListAllExampleSubjectResponse
{
    public IList<Face> Faces { get; set; }

    [JsonPropertyName("page_number")]
    public int PageNumber { get; set; }

    [JsonPropertyName("page_size")]
    public int PageSize { get; set; }
    
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
    
    [JsonPropertyName("total_elements")]
    public int TotalElements { get; set; }
}