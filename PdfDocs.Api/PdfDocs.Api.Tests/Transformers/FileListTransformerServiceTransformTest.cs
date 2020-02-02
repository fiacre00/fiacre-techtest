using Moq;
using PdfDocs.Api.Models;
using PdfDocs.Api.Transformers;
using PdfDocs.Domain.Entities;
using Shouldly;
using Xunit;

namespace PdfDocs.Api.Tests.Transformers
{
    public partial class FileListTransformerServiceTests
    {
        public class FileListTransformerServiceTransformTest
        {
            private FileListTransformerService CreateSut(ITransformer<FileList, FileListDto> fileListTransformer = null)
            {
                return new FileListTransformerService(fileListTransformer ??
                    Mock.Of<ITransformer<FileList, FileListDto>>());
            }

            [Fact]
            public void Transform_Uses_FileListTransformer_Transform_With_Source()
            {
                var source = new FileList();
                var fileListTransformer = Mock.Of<ITransformer<FileList, FileListDto>>();
                var sut = CreateSut(fileListTransformer);

                sut.Transform(source);

                Mock.Get(fileListTransformer).Verify(q => q.Transform(source), Times.Once());
            }

            [Fact]
            public void Transform_Returns_The_Instance_Of_FileListDto_Returned_By_FileListTransformer()
            {
                var fileListTransformer = Mock.Of<ITransformer<FileList, FileListDto>>();
                var fileListDto = new FileListDto();

                Mock.Get(fileListTransformer)
                    .Setup(q => q.Transform(It.IsAny<FileList>()))
                    .Returns(fileListDto);

                var result = CreateSut(fileListTransformer).Transform(new FileList());

                result.ShouldBeSameAs(fileListDto);
            }
        }
    }
}
