using Proteus.Shared.Contracts;
using Proteus.Shared.Entities;

namespace Proteus.Domain.Business
{
    public class ImageConverterFactory: IProteusFactory<ImageRequest, ImageResponse>
    {
        public OperationResult<ImageResponse> Execute(ImageRequest request)
        {
            var response = new ImageResponse();

            return new OperationResult<ImageResponse>(response);
        }

        public bool Validate(ImageRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
