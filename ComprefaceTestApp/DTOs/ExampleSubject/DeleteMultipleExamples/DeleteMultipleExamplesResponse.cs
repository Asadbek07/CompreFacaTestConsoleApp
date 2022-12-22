using System.Text.Json.Serialization;

namespace ComprefaceTestApp.DTOs.ExampleSubject.DeleteMultipleExamples
{
    public class DeleteMultipleExamplesResponse
    {
        public IList<Face>? ExampleList { get; set; }
    }
}
