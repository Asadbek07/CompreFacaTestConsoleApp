using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ComprefaceTestApp.DTOs.ExampleSubject.DeleteAllSubjectExamples
{
    public class DeleteAllExamplesResponse
    {
        [JsonPropertyName("deleted")]
        public int Count{ get; set; }
    }
}
