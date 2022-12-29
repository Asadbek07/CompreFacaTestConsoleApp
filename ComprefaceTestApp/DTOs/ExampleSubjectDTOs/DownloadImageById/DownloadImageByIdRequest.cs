namespace ComprefaceTestApp.DTOs.ExampleSubjectDTOs.DownloadImageById
{
    public class DownloadImageByIdRequest
    {
        public Guid ImageId { get; set; }

        public Guid RecognitionApiKey { get; set; }
    }
}
