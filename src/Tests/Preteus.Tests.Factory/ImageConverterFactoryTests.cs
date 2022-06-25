using Proteus.Tests.Factory.Properties;

namespace Proteus.Tests.Factory
{
    public class ImageConverterFactoryTests
    {
        private readonly string _base64PngFile;
        private readonly string _base64JpgFile;
        private readonly string _base64BmpFile;

        public ImageConverterFactoryTests()
        {
            _base64BmpFile = Resources.bpmFile;
            _base64JpgFile = Resources.jpgFile;
            _base64PngFile = Resources.pngFile;
        }

        [Fact]
        public void Generate_Right_Response_Type_Test()
        {
            // arrange
            IProteusFactory<ImageRequest, ImageResponse> target = new ImageConverterFactory();

            // act
            var result = target.Execute(new ImageRequest());

            // assert
            result.Should().BeOfType<OperationResult<ImageResponse>>();
        }

        [Fact]
        public void Generate_Success_Response_Test()
        {
            // arrange
            IProteusFactory<ImageRequest, ImageResponse> target = new ImageConverterFactory();
            var request = new ImageRequest(Guid.NewGuid())
            {
                FileTypeOrigin = FileTypes.Svg,
                FileTypeTarget = FileTypes.Png,
                ImageContent = Resources.svgFile
            };

            // act
            var result = target.Execute(request);

            // assert
            result.Success.Should().BeTrue();
            result.Failure.Should().BeFalse();
            result.Result.Should().NotBeNull();
            result.Result?.ImageContent.Should().Be(_base64PngFile);
        }

        [Fact]
        public void Generate_Failed_Response_Test()
        {
            // arrange
            IProteusFactory<ImageRequest, ImageResponse> target = new ImageConverterFactory();

            // act
            var result = target.Execute(new ImageRequest());

            // assert
            result.Success.Should().BeFalse();
            result.Failure.Should().BeTrue();
        }

        [Fact]
        public void Convert_Svg_To_Png_Success_Test()
        {
            // arrange
            IProteusFactory<ImageRequest, ImageResponse> target = new ImageConverterFactory();
            var request = new ImageRequest(Guid.NewGuid())
            {
                FileTypeOrigin = FileTypes.Svg,
                FileTypeTarget = FileTypes.Png,
                ImageContent = Resources.svgFile
            };

            // act
            var result = target.Execute(request);

            // assert
            result.Success.Should().BeTrue();
            result.Failure.Should().BeFalse();
            result.Result.Should().NotBeNull();
            result.Result?.ImageContent.Should().Be(_base64PngFile);
            result.Result?.FileTypeTarget.Should().Be(FileTypes.Png);
        }

        [Fact]
        public void Convert_Svg_To_Png_Failure_Test()
        {
            // arrange
            IProteusFactory<ImageRequest, ImageResponse> target = new ImageConverterFactory();
            var request = new ImageRequest(Guid.NewGuid())
            {
                FileTypeOrigin = FileTypes.Svg,
                FileTypeTarget = FileTypes.Png,
                ImageContent = Resources.svgFile + Guid.NewGuid().ToString()
            };

            // act
            var result = target.Execute(request);

            // assert
            result.Success.Should().BeFalse();
            result.Failure.Should().BeTrue();
        }

        [Fact]
        public void Convert_Svg_To_Jpg_Success_Test()
        {
            // arrange
            IProteusFactory<ImageRequest, ImageResponse> target = new ImageConverterFactory();
            var request = new ImageRequest(Guid.NewGuid())
            {
                FileTypeOrigin = FileTypes.Svg,
                FileTypeTarget = FileTypes.Jpg,
                ImageContent = Resources.svgFile
            };

            // act
            var result = target.Execute(request);

            // assert
            result.Success.Should().BeTrue();
            result.Failure.Should().BeFalse();
            result.Result.Should().NotBeNull();
            result.Result?.ImageContent.Should().Be(_base64JpgFile);
            result.Result?.FileTypeTarget.Should().Be(FileTypes.Jpg);
        }

        [Fact]
        public void Convert_Svg_To_Jpg_Failure_Test()
        {
            // arrange
            IProteusFactory<ImageRequest, ImageResponse> target = new ImageConverterFactory();
            var request = new ImageRequest(Guid.NewGuid())
            {
                FileTypeOrigin = FileTypes.Svg,
                FileTypeTarget = FileTypes.Jpg,
                ImageContent = Resources.svgFile + Guid.NewGuid().ToString()
            };

            // act
            var result = target.Execute(request);

            // assert
            result.Success.Should().BeFalse();
            result.Failure.Should().BeTrue();
        }

        [Fact]
        public void Convert_Svg_To_Bpm_Success_Test()
        {
            // arrange
            IProteusFactory<ImageRequest, ImageResponse> target = new ImageConverterFactory();
            var request = new ImageRequest(Guid.NewGuid())
            {
                FileTypeOrigin = FileTypes.Svg,
                FileTypeTarget = FileTypes.Bpm,
                ImageContent = Resources.svgFile
            };

            // act
            var result = target.Execute(request);

            // assert
            result.Success.Should().BeTrue();
            result.Failure.Should().BeFalse();
            result.Result.Should().NotBeNull();
            result.Result?.ImageContent.Should().Be(_base64BmpFile);
            result.Result?.FileTypeTarget.Should().Be(FileTypes.Bpm);
        }

        [Fact]
        public void Convert_Svg_To_Bpm_Failure_Test()
        {
            // arrange
            IProteusFactory<ImageRequest, ImageResponse> target = new ImageConverterFactory();
            var request = new ImageRequest(Guid.NewGuid())
            {
                FileTypeOrigin = FileTypes.Svg,
                FileTypeTarget = FileTypes.Bpm,
                ImageContent = Resources.svgFile + Guid.NewGuid().ToString()
            };

            // act
            var result = target.Execute(request);

            // assert
            result.Success.Should().BeFalse();
            result.Failure.Should().BeTrue();
        }

        [Fact]
        public void Convert_Png_To_Bpm_Success_Test()
        {
            // arrange
            IProteusFactory<ImageRequest, ImageResponse> target = new ImageConverterFactory();
            var request = new ImageRequest(Guid.NewGuid())
            {
                FileTypeOrigin = FileTypes.Png,
                FileTypeTarget = FileTypes.Bpm,
                ImageContent = Resources.pngFile
            };

            // act
            var result = target.Execute(request);

            // assert
            result.Success.Should().BeTrue();
            result.Failure.Should().BeFalse();
            result.Result.Should().NotBeNull();
            result.Result?.ImageContent.Should().NotBeNullOrEmpty();
            result.Result?.FileTypeTarget.Should().Be(FileTypes.Bpm);
        }

        [Fact]
        public void Convert_Png_To_Bpm_Failure_Test()
        {
            // arrange
            IProteusFactory<ImageRequest, ImageResponse> target = new ImageConverterFactory();
            var request = new ImageRequest(Guid.NewGuid())
            {
                FileTypeOrigin = FileTypes.Png,
                FileTypeTarget = FileTypes.Bpm,
                ImageContent = Resources.pngFile + Guid.NewGuid().ToString()
            };

            // act
            var result = target.Execute(request);

            // assert
            result.Success.Should().BeFalse();
            result.Failure.Should().BeTrue();
        }

        [Fact]
        public void Convert_Png_To_Jpg_Success_Test()
        {
            // arrange
            IProteusFactory<ImageRequest, ImageResponse> target = new ImageConverterFactory();
            var request = new ImageRequest(Guid.NewGuid())
            {
                FileTypeOrigin = FileTypes.Png,
                FileTypeTarget = FileTypes.Jpg,
                ImageContent = Resources.pngFile
            };

            // act
            var result = target.Execute(request);

            // assert
            result.Success.Should().BeTrue();
            result.Failure.Should().BeFalse();
            result.Result.Should().NotBeNull();
            result.Result?.ImageContent.Should().NotBeNullOrEmpty();
            result.Result?.FileTypeTarget.Should().Be(FileTypes.Jpg);
        }

        [Fact]
        public void Convert_Png_To_Jpg_Failure_Test()
        {
            // arrange
            IProteusFactory<ImageRequest, ImageResponse> target = new ImageConverterFactory();
            var request = new ImageRequest(Guid.NewGuid())
            {
                FileTypeOrigin = FileTypes.Png,
                FileTypeTarget = FileTypes.Jpg,
                ImageContent = Resources.pngFile + Guid.NewGuid().ToString()
            };

            // act
            var result = target.Execute(request);

            // assert
            result.Success.Should().BeFalse();
            result.Failure.Should().BeTrue();
        }
        
        [Fact]
        public void Convert_Png_To_Svg_Failure_Test()
        {
            // arrange
            IProteusFactory<ImageRequest, ImageResponse> target = new ImageConverterFactory();
            var request = new ImageRequest(Guid.NewGuid())
            {
                FileTypeOrigin = FileTypes.Png,
                FileTypeTarget = FileTypes.Svg,
                ImageContent = Resources.pngFile + Guid.NewGuid().ToString()
            };

            // act
            var result = target.Execute(request);

            // assert
            result.Success.Should().BeFalse();
            result.Failure.Should().BeTrue();
        }
    }
}