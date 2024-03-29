﻿using Proteus.Shared.Contracts;
using Proteus.Shared.Entities;
using Proteus.Shared.Entities.Dtos;
using System.Drawing;
using System.Drawing.Imaging;

namespace Proteus.Domain.Business.ImageHandlers
{
    /// <summary>
    /// Bmp converter file handler
    /// </summary>
    public class BmpHandler : BaseHandler
    {
        public override OperationResult<ImageResponse> Execute(ImageRequest? request)
        {
            try
            {
                var imageContent = request?.ImageContent ?? "";

                var byteArray = Convert.FromBase64String(imageContent);

                using var stream = new MemoryStream(byteArray);
                var image = Image.FromStream(stream);


                using var pngStream = new MemoryStream();

                switch (request!.FileTypeTarget)
                {
                    case FileTypes.Png:
                        image.Save(pngStream, ImageFormat.Png);
                        break;
                    case FileTypes.Jpg:
                        image.Save(pngStream, ImageFormat.Jpeg);
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
