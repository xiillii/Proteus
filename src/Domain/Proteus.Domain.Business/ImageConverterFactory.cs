using Proteus.Domain.Business.ImageHandlers;
using Proteus.Shared.Contracts;
using Proteus.Shared.Contracts.Handlers;
using Proteus.Shared.Entities;
using Proteus.Shared.Entities.Dtos;

namespace Proteus.Domain.Business
{
    public class ImageConverterFactory: IProteusFactory<ImageRequest, ImageResponse>
    {
        private IProteusHandler<ImageRequest, ImageResponse> _handler;

        public ImageConverterFactory()
        {
            _handler = new BaseHandler();
        }
        
        public OperationResult<ImageResponse> Execute(ImageRequest request)
        {
            
            var errors = Validate(request);
            if (errors != null)
                return new OperationResult<ImageResponse>(errors);

            switch (request.FileTypeOrigin)
            {
                case FileTypes.Svg:
                    _handler = new SvgHandler();
                    break;
                case FileTypes.Png:
                    _handler = new PngHandler();
                    break;
                case FileTypes.Jpg:
                    break;
                case FileTypes.Bmp:
                    _handler = new BmpHandler();
                    break;
                
            }
            var result = _handler.Execute(request);

            return result;
        }

        public ErrorDto? Validate(ImageRequest request) 
            => _handler.Validate(request);
    }
}
