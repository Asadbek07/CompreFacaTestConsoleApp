using System.Net.Http.Json;
using ComprefaceTestApp.DTOs.SubjectDTOs.AddSubject;
using ComprefaceTestApp.DTOs.SubjectDTOs.DeleteAllSubjects;
using ComprefaceTestApp.DTOs.SubjectDTOs.DeleteSubject;
using ComprefaceTestApp.DTOs.SubjectDTOs.GetSubjectList;
using ComprefaceTestApp.DTOs.SubjectDTOs.RenameSubject;
using Flurl.Http;
using Shared.Constants;

namespace ComprefaceTestApp.Services;

public class SubjectService
{
    public async Task<GetAllSubjectResponse> GetAllSubject()
    {
        var requestUrl = $"{RequestConstants.BaseUrl}recognition/subjects/";
        var response = await requestUrl.GetJsonAsync<GetAllSubjectResponse>();

        return response;
    }

    public async Task<AddSubjectResponse> AddSubject(AddSubjectRequest request)
    {
        var requestUrl = $"{RequestConstants.BaseUrl}recognition/subjects";

        var response = await requestUrl.PostJsonAsync(request);
        var subjectDto = await response.ResponseMessage.Content.ReadFromJsonAsync<AddSubjectResponse>();

        return subjectDto;
    }

    public async Task<RenameSubjectResponse> RenameSubject(RenameSubjectRequest request)
    {
        var requestUrl = $"{RequestConstants.BaseUrl}recognition/subjects/{request.CurrentSubject}";
        var response = await requestUrl
            .PutJsonAsync(request.Subject);
        
        var subjectDto = await response.ResponseMessage.Content.ReadFromJsonAsync<RenameSubjectResponse>();

        return subjectDto;
    }

    public async Task<DeleteSubjectResponse> DeleteSubject(DeleteSubjectRequest request)
    {
        var requestUrl = $"{RequestConstants.BaseUrl}recognition/subjects/{request.ActualSubject}";

        var response = await requestUrl.DeleteAsync();
        
        var deleteSubjectResponse = await response.ResponseMessage.Content.ReadFromJsonAsync<DeleteSubjectResponse>();
        
        return deleteSubjectResponse;
    }

    public async Task<DeleteAllSubjectsResponse> DeleteAllSubjects()
    {
        var requestUrl = $"{RequestConstants.BaseUrl}recognition/subjects";

        var response = await requestUrl.DeleteAsync();

        var deleteAllSubjectsResponse = await response.ResponseMessage.Content.ReadFromJsonAsync<DeleteAllSubjectsResponse>();
        
        return deleteAllSubjectsResponse;
    }
}