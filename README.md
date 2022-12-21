**Subject**


*Get All subjects*

```
    
    var getAllSubjectResponse = await subjectService.GetAllSubject();
    
    foreach (var subject in getAllSubjectResponse.Subjects)
    {
    
        Console.WriteLine(subject);
    
    }

```

*Delete all subjects*

````
        var deleteAllSubjectsResponse = await subjectService.DeleteAllSubjects();
        
        Console.WriteLine(deleteAllSubjectsResponse.Deleted);

````

*Delete subject*

```
        var deleteSubjectRequest = new DeleteSubjectRequest()
        {
            ActualSubject = "Asadbek Sindarov"
        };
        
        var deleteSubjectResponse = await subjectService.DeleteSubject(deleteSubjectRequest);
        
        Console.WriteLine(deleteSubjectResponse.Subject);

```

*Add new Subject*

```
        var addSubjectRequest = new AddSubjectRequest()
        {
            Subject = "Some guy's name"
        };
        
        var addSubjectResponse = await subjectService.AddSubject(addSubjectRequest);
        
        Console.WriteLine(addSubjectResponse.Subject);

```

*Rename Subject*

```
    var renameSubjectRequest = new RenameSubjectRequest()
        {
            CurrentSubject = "Asadbek",
            Subject = "Asadbek Sindarov"
        };
        
        var renameSubjectResponse = await subjectService.RenameSubject(renameSubjectRequest);
        
        Console.WriteLine(renameSubjectResponse.Updated);


```

**Subject Example**

*Get All Example Subject*

```
        var listAllExampleSubjectRequest = new ListAllExampleSubjectRequest()
        {
            Page = 1,
            Size = 1,
            Subject = "Asadbek Sindarov",
        };
        
        var listAllExampleSubjectResponse = await exampleSubjectService.GetAllExampleSubjects(listAllExampleSubjectRequest);
        
        foreach (var exampleSubject in listAllExampleSubjectResponse.Faces)
        {
            Console.WriteLine(exampleSubject.Subject);
            Console.WriteLine(exampleSubject.ImageId);
        }
        
        Console.WriteLine(listAllExampleSubjectResponse.PageNumber);
        Console.WriteLine(listAllExampleSubjectResponse.PageSize);
        Console.WriteLine(listAllExampleSubjectResponse.TotalElements);
        Console.WriteLine(listAllExampleSubjectResponse.TotalPages);

```

*Add Example Subject*

```
        var addExampleSubjectRequest = new AddExampleSubjectRequest()
        {
            DetProbThreShold = 0.81m,
            FilePath = @"image path here",
            Subject = "Asadbek Sindarov",
            FileName = "file name" // Guid.NewGuid().ToString(),
        };
    
        var addExampleSubjectResponse = await exampleSubjectService.AddExampleSubject(addExampleSubjectRequest);
    
        Console.WriteLine(addExampleSubjectResponse.Subject);
        Console.WriteLine(addExampleSubjectResponse.ImageId);
```

*Delete All Examples of the Subject by Name*
```
   await exampleSubjectService.ClearSubjectAsync(new DTOs.ExampleSubject.DeleteAllSubjectExamples.DeleteAllExamplesRequest()
        {
            Subject = "Stars"
        });
```

*Delete an Example of the Subject by ID*
```
    await exampleSubjectService.DeleteImageByIdAsync(new DTOs.ExampleSubject.DeleteImageById.DeleteImageByIdRequest
        {
            ImageId = Guid.Parse("c3dd56c2-1a51-450f-800f-b9fe230a9a7a")
        }
            );
```

*Delete multiple examples*
```
await exampleSubjectService.DeletMultipleExamples(
            new DTOs.ExampleSubject.DeleteMultipleExamples.DeleteMultipleExamplesRequest()
            {
                ImageIdList = new List<Guid>
                {
                    Guid.Parse("c5bc0e91-c3c1-45a0-87e3-5e3beff17106"),
                    Guid.Parse("8c8d909d-40a1-471d-ba2a-cd8200d85754")
                }
            });
```

*Direct Download an Image example of the Subject by ID*
```
      await exampleSubjectService.DownloadImageByIdAsync(
            new DTOs.ExampleSubject.DownloadImageById.DownloadImageByIdRequest()
            {
                ApiKey = Guid.Parse("e468da55-b884-4865-8c83-f1ad5775f00d"),
                ImageId = Guid.Parse("e0053da2-e0a1-4b6e-b647-5d7108e42aea")
            });
```

