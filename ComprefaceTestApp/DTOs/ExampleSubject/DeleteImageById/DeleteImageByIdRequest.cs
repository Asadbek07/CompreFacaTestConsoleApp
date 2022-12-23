using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ComprefaceTestApp.DTOs.ExampleSubject.DeleteImageById
{
    public class DeleteImageByIdRequest
    {
        public Guid ImageId { get; set; }

    }
}
