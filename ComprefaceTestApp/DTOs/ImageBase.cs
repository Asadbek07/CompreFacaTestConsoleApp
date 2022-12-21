using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ComprefaceTestApp.DTOs
{
    public class ImageBase
    {
        [JsonPropertyName("image_id")]
        public Guid ImageId { get; set; }
    }
}
