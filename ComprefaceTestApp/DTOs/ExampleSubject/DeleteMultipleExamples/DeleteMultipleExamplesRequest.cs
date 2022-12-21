using ComprefaceTestApp.DTOs.ExampleSubject.DeleteImageById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComprefaceTestApp.DTOs.ExampleSubject.DeleteMultipleExamples
{
    public class DeleteMultipleExamplesRequest
    {
        public IList<Guid>? ImageIdList { get; set; }
    }
}
