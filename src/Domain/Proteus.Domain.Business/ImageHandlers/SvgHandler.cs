using Proteus.Shared.Contracts;
using Proteus.Shared.Entities;
using Proteus.Shared.Entities.Dtos;
using Svg;
using System.Drawing.Imaging;
using System.Text;

namespace Proteus.Domain.Business.ImageHandlers
{
    /// <summary>
    /// Svg converter file handler
    /// </summary>
    public class SvgHandler : BaseHandler
    {
        public override OperationResult<ImageResponse> Execute(ImageRequest? request)
        {
            try
            {
                var imageContent = request?.ImageContent ?? "";

                var byteArray = Encoding.ASCII.GetBytes(imageContent);
                using var stream = new MemoryStream(byteArray);
                var svgDocument = SvgDocument.Open<SvgDocument>(stream);
                var bitmap = svgDocument.Draw();
                using var pngStream = new MemoryStream();
                

                switch (request!.FileTypeTarget)
                {
                    case FileTypes.Png:

                        bitmap.Save(pngStream, ImageFormat.Png);
                        break;
                    case FileTypes.Jpg:
                        bitmap.Save(pngStream, ImageFormat.Jpeg);
                        break;
                    case FileTypes.Bmp:
                        bitmap.Save(pngStream, ImageFormat.Bmp);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                
                var pngBytes = pngStream.ToArray();

                var imageResponse = new ImageResponse
                {
                    Id = request!.Id,
                    FileTypeTarget = request!.FileTypeTarget,
                    ImageContent = Convert.ToBase64String(pngBytes)
                };

                return new OperationResult<ImageResponse>(imageResponse);
            }
            catch (Exception e)
            {
                var error = new ErrorDto("LO-01", e.Message);
                return new OperationResult<ImageResponse>(error);
            }
        }
    }
}
