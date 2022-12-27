namespace ComprefaceTestApp.DTOs.ExampleSubject.DownloadImageById
{
    public class DownloadImageByIdRequest
    {
        public Guid ImageId { get; set; }

        public Guid RecognitionApiKey { get; set; }
    }
}
