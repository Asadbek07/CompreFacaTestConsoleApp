using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ComprefaceTestApp.DTOs.ExampleSubject.DownloadImageById
{
    public class DownloadImageByIdRequest : ImageBase
    {
        [JsonPropertyName("recognition_api_key")]
        public Guid ApiKey { get; set; }
    }
}
