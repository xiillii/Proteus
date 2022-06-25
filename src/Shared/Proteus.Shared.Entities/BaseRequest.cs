namespace Proteus.Shared.Entities
{
    /// <summary>
    /// Base request
    /// </summary>
    public class BaseRequest
    {
        /// <summary>
        /// ID for the request
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Image content. Commonly base64 string or a xml file text.
        /// </summary>
        public string? ImageContent { get; set; }
        

    }
}
