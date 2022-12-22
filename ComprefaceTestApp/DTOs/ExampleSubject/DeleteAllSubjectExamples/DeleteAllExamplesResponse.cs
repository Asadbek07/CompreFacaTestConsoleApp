using System.Text.Json.Serialization;

namespace ComprefaceTestApp.DTOs.ExampleSubject.DeleteAllSubjectExamples
{
    public class DeleteAllExamplesResponse
    {
        [JsonPropertyName("deleted")]
        public int Deleted{ get; set; }
    }
}
