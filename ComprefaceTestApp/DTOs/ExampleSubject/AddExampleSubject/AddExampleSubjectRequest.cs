namespace ComprefaceTestApp.DTOs.ExampleSubject.AddExampleSubject;

public class AddExampleSubjectRequest : SubjectBase
{
    public decimal? DetProbThreShold { get; set; }

    public string? FilePath { get; set; }

    public string? FileName { get; set; }
}