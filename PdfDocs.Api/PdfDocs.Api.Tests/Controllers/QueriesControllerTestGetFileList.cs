using PdfDocs.Api.Controllers;
using PdfDocs.Api.Models;
using PdfDocs.Api.Transformers;
using PdfDocs.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;
using PdfDocs.Domain.Entities;

namespace PdfDocs.Api.Tests.Controllers
{
    public partial class QueriesControllerTests
    {
        public class QueriesControllerTestGetFileList
        {
            private QueriesController CreateSut(
                IPdfFileTransformerService pdfFileTransformerService = null,
                IPdfFileRepository pdfFileRepository = null,
                IFileListTransformerService fileListTransformerService = null)
            {
                return new QueriesController(
                    pdfFileTransformerService ?? Mock.Of<IPdfFileTransformerService>(),
                    pdfFileRepository ?? Mock.Of<IPdfFileRepository>(),
                    fileListTransformerService ?? Mock.Of<IFileListTransformerService>());
            }

            [Fact]
            public async Task GetFileList_Returns_Ok_With_FileList()
            {
                var fileList = new FileList();
                var fileListDto = new FileListDto();

                var repositoryMock = new Mock<IPdfFileRepository>();
                var transformerMock = new Mock<IFileListTransformerService>();

                repositoryMock.Setup(m => m.GetPdfFileList()).ReturnsAsync(fileList);
                transformerMock.Setup(m => m.Transform(fileList)).Returns(fileListDto);

                var response = await CreateSut(pdfFileRepository: repositoryMock.Object, fileListTransformerService: transformerMock.Object).GetFileList();

                repositoryMock.Verify(m => m.GetPdfFileList(), Times.Once);
                transformerMock.Verify(m => m.Transform(fileList), Times.Once);

                response.Result.ShouldBeOfType(typeof(OkObjectResult));
                var okObjectResult = response.Result as OkObjectResult;
                okObjectResult.Value.ShouldBeSameAs(fileListDto);
            }

            
        }
    }
}
