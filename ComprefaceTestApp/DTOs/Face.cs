using System.Text.Json.Serialization;

namespace ComprefaceTestApp.DTOs;

public class Face
{
    [JsonPropertyName("image_id")]
    public Guid ImageId { get; set; }
    
    public string Subject{ get; set; }
}