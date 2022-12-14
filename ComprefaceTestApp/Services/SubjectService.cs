using System.Net.Http.Json;
using ComprefaceTestApp.DTOs.SubjectDTOs;
using ComprefaceTestApp.DTOs.SubjectDTOs.AddSubject;
using ComprefaceTestApp.DTOs.SubjectDTOs.DeleteAllSubjects;
using ComprefaceTestApp.DTOs.SubjectDTOs.DeleteSubject;
using ComprefaceTestApp.DTOs.SubjectDTOs.GetSubjectList;
using ComprefaceTestApp.DTOs.SubjectDTOs.RenameSubject;

namespace ComprefaceTestApp.Services;

public class SubjectService
{
    private readonly HttpClient _httpClient;
    
    public SubjectService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetAllSubjectResponse> GetAllSubject()
    {
        var response = await _httpClient.GetAsync("recognition/subjects/");
        var subjectDto = await response.Content.ReadFromJsonAsync<GetAllSubjectResponse>();

        return subjectDto;
    }

    public async Task<AddSubjectResponse> AddSubject(AddSubjectRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "recognition/subjects", 
            request);
        var subjectDto = await response.Content.ReadFromJsonAsync<AddSubjectResponse>();

        return subjectDto;
    }

    public async Task<RenameSubjectResponse> RenameSubject(RenameSubjectRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync(
            $"recognition/subjects/{request.CurrentSubject}",
            request.Subject);

        var subjectDto = await response.Content.ReadFromJsonAsync<RenameSubjectResponse>();

        return subjectDto;
    }

    public async Task<DeleteSubjectResponse> DeleteSubject(DeleteSubjectRequest request)
    {
        var response = await _httpClient.DeleteFromJsonAsync<DeleteSubjectResponse>(
            $"recognition/subjects/{request.ActualSubject}");

        return response;
    }

    public async Task<DeleteAllSubjectsResponse> DeleteAllSubjects()
    {
        var response = await _httpClient.DeleteFromJsonAsync<DeleteAllSubjectsResponse>(
            "recognition/subjects");

        return response;
    }
}