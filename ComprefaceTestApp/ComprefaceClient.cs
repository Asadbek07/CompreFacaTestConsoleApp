using ComprefaceTestApp.Configuration;
using ComprefaceTestApp.Services;
using Microsoft.Extensions.Configuration;

namespace ComprefaceTestApp;

public class ComprefaceClient
{
    public ExampleSubjectService ExampleSubjectService { get; private set; }

    public SubjectService SubjectService { get; private set; }

    public ComprefaceClient(string apiKey, string host) : this(new ComprefaceConfiguration(apiKey, host))
    { }

    public ComprefaceClient(IConfiguration configuration, string sectionForApiKey, string sectionForBaseUrl) : this(new ComprefaceConfiguration(configuration, sectionForApiKey, sectionForBaseUrl))
    { }

    public ComprefaceClient(ComprefaceConfiguration comprefaceConfiguration)
    {
        ExampleSubjectService = new ExampleSubjectService(comprefaceConfiguration);
        SubjectService = new SubjectService(comprefaceConfiguration);
    }
}