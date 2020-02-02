using Moq;
using PdfDocs.Api.Models;
using PdfDocs.Api.Transformers;
using PdfDocs.Domain.Entities;
using Shouldly;
using Xunit;

namespace PdfDocs.Api.Tests.Transformers
{
    public partial class PdfFileTransformerServiceTests
    {
        public class PdfFileTransformerServiceTransformTest
        {
            private PdfFileTransformerService CreateSut(ITransformer<PdfFile, PdfFileDto> pdfFileTransformer = null)
            {
                return new PdfFileTransformerService(pdfFileTransformer ??
                    Mock.Of<ITransformer<PdfFile, PdfFileDto>>());
            }

            [Fact]
            public void Transform_Uses_PdfFileTransformer_Transform_With_Source()
            {
                var source = new PdfFile();
                var pdfFileTransformer = Mock.Of<ITransformer<PdfFile, PdfFileDto>>();
                var sut = CreateSut(pdfFileTransformer);

                sut.Transform(source);

                Mock.Get(pdfFileTransformer).Verify(q => q.Transform(source), Times.Once());
            }

            [Fact]
            public void Transform_Returns_The_Instance_Of_PdfFileDto_Returned_By_PdfFileTransformer()
            {
                var pdfFileTransformer = Mock.Of<ITransformer<PdfFile, PdfFileDto>>();
                var pdfFileDto = new PdfFileDto();

                Mock.Get(pdfFileTransformer)
                    .Setup(q => q.Transform(It.IsAny<PdfFile>()))
                    .Returns(pdfFileDto);

                var result = CreateSut(pdfFileTransformer).Transform(new PdfFile());

                result.ShouldBeSameAs(pdfFileDto);
            }
        }
    }
}
