namespace Proteus.Shared.Entities
{
    public class ImageRequest : BaseRequest
    {
        public FileTypes FileTypeOrigin { get; set; }
        public FileTypes FileTypeTarget { get; set; }

        public ImageRequest() : this(Guid.NewGuid())
        {

        }

        public ImageRequest(Guid id)
        {
            Id = id;
        }
    }
}
