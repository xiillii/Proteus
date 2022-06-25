namespace Proteus.Tests.Factory
{
    public class ImageConverterFactoryTests
    {
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

            // act
            var result = target.Execute(new ImageRequest());

            // assert
            result.Success.Should().BeTrue();
            result.Failure.Should().BeFalse();
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
    }
}