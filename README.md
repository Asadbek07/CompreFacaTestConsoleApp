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

