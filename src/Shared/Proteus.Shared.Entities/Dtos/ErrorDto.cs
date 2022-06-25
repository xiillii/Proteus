namespace Proteus.Shared.Entities.Dtos
{
    public class ErrorDto
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> MessageList { get; set; }

        public ErrorDto()
        {
            
        }

        public ErrorDto(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
