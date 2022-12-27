using System.Text.Json.Serialization;

namespace ComprefaceTestApp.DTOs.ExampleSubject.AddBase64ExampleSubject
{
    public class AddBase64ExampleSubjectRequest
    {
        public string Subject { get; set; }

        public decimal? DetProbThreShold { get; set; }

        public string File { get; set; }
    }
}
