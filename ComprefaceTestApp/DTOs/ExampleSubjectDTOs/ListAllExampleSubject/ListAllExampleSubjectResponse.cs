using ComprefaceTestApp.DTOs.HelperDTOs;

namespace ComprefaceTestApp.DTOs.ExampleSubjectDTOs.ListAllExampleSubject;

public class ListAllExampleSubjectResponse
{
    public IList<Face> Faces { get; set; }

    public int PageNumber { get; set; }

    public int PageSize { get; set; }
    
    public int TotalPages { get; set; }
    
    public int TotalElements { get; set; }
}