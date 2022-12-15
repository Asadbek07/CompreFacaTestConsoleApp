﻿using ComprefaceTestApp.DTOs.ExampleSubject.AddExampleSubject;
using ComprefaceTestApp.DTOs.ExampleSubject.ListAllExampleSubject;
using ComprefaceTestApp.DTOs.SubjectDTOs.AddSubject;
using ComprefaceTestApp.DTOs.SubjectDTOs.DeleteSubject;
using ComprefaceTestApp.DTOs.SubjectDTOs.RenameSubject;
using ComprefaceTestApp.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ComprefaceTestApp;

public class Program
{
    static async Task Main(string[] args)
    {
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:8000/api/v1/")
        };
        
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36");
        httpClient.DefaultRequestHeaders.Add("x-api-key", "746f45a6-b35e-4087-a79a-a686b3c47fb7");

        var subjectService = new SubjectService(httpClient);
        // var exampleSubjectService = new ExampleSubjectService(httpClient);
        
        /***  Get All Example Subject  ***/
        // var listAllExampleSubjectRequest = new ListAllExampleSubjectRequest()
        // {
        //     Page = 1,
        //     Size = 1,
        //     Subject = "Asadbek Sindarov",
        // };
        //
        // var listAllExampleSubjectResponse = await exampleSubjectService.GetAllExampleSubjects(listAllExampleSubjectRequest);
        //
        // foreach (var exampleSubject in listAllExampleSubjectResponse.Faces)
        // {
        //     Console.WriteLine(exampleSubject.Subject);
        //     Console.WriteLine(exampleSubject.ImageId);
        // }
        //
        // Console.WriteLine(listAllExampleSubjectResponse.PageNumber);
        // Console.WriteLine(listAllExampleSubjectResponse.PageSize);
        // Console.WriteLine(listAllExampleSubjectResponse.TotalElements);
        // Console.WriteLine(listAllExampleSubjectResponse.TotalPages);


        // var addExampleSubjectRequest = new AddExampleSubjectRequest()
        // {
        //     DetProbThreShold = 0.81m,
        //     FilePath = @"C:\Users\asindarov\Desktop\Personal\Photo\photo_2022-12-14_10-55-57.jpg",
        //     Subject = "Asadbek Sindarov",
        // };
        //
        // var addExampleSubjectResponse = await exampleSubjectService.AddExampleSubject(addExampleSubjectRequest);
        //
        // Console.WriteLine(addExampleSubjectResponse.Subject);
        // Console.WriteLine(addExampleSubjectResponse.ImageId);




        /***************************************/

        /*************     Subject  ******************/
        /***  Get All subjects ***/
        var getAllSubjectResponse = await subjectService.GetAllSubject();
        foreach (var subject in getAllSubjectResponse.Subjects)
        {
            Console.WriteLine(subject);
        }

        /*** Delete all subjects ***/
        // var deleteAllSubjectsResponse = await subjectService.DeleteAllSubjects();
        //
        // Console.WriteLine(deleteAllSubjectsResponse.Deleted);

        /*** Delete subject ***/
        // var deleteSubjectRequest = new DeleteSubjectRequest()
        // {
        //     ActualSubject = "Asadbek Sindarov"
        // };
        //
        // var deleteSubjectResponse = await subjectService.DeleteSubject(deleteSubjectRequest);
        //
        // Console.WriteLine(deleteSubjectResponse.Subject);

        /*** Add new Subject ***/
        // var addSubjectRequest = new AddSubjectRequest()
        // {
        //     Subject = "Jo'rabek"
        // };
        //
        // var addSubjectResponse = await subjectService.AddSubject(addSubjectRequest);
        //
        // Console.WriteLine(addSubjectResponse.Subject);


        /*** Rename Subject ***/
        // var renameSubjectRequest = new RenameSubjectRequest()
        // {
        //     CurrentSubject = "Asadbek",
        //     Subject = "Asadbek Sindarov"
        // };
        //
        // var renameSubjectResponse = await subjectService.RenameSubject(renameSubjectRequest);
        //
        // Console.WriteLine(renameSubjectResponse.Updated);



        /***************************************/
    }
}