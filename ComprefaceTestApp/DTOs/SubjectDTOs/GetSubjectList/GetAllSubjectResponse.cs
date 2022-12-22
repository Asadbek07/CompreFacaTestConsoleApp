using System.Text.Json.Serialization;

namespace ComprefaceTestApp.DTOs.SubjectDTOs.GetSubjectList;

public class GetAllSubjectResponse
{
    public IList<string>? Subjects { get; set; }
}