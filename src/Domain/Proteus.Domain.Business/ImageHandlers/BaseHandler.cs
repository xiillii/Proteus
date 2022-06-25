using Proteus.Shared.Contracts;
using Proteus.Shared.Contracts.Handlers;
using Proteus.Shared.Entities;
using Proteus.Shared.Entities.Dtos;

namespace Proteus.Domain.Business.ImageHandlers
{
    public class BaseHandler : IProteusHandler<ImageRequest, ImageResponse>
    {
        /// <summary>
        /// Validate if the request is a SVG image file
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual ErrorDto? Validate(ImageRequest? request)
        {
            ErrorDto? result = null;
            var lstErrors = new List<string>();

            if (request == null)
            {
                lstErrors.Add("Request is mandatory");
            }
            else
            {
                

                if (request.ImageContent == null)
                {
                    lstErrors.Add("Image content is mandatory");
                }
            }

            if (lstErrors.Count > 0)
            {
                result = new ErrorDto
                {
                    Code = "ER-REQUEST",
                    MessageList = lstErrors
                };
            }

            return result;
        }

        public virtual OperationResult<ImageResponse> Execute(ImageRequest? request) 
            => new(new ErrorDto());
    }
}
