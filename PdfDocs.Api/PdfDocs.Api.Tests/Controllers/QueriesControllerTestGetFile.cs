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
        public class QueriesControllerTestGetFile
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
            public async Task GetFile_Returns_Ok_With_File()
            {
                var location = Guid.NewGuid();
                var pdfFile = new PdfFile();
                var pdfFileDto = new PdfFileDto();
                var repositoryMock = new Mock<IPdfFileRepository>();
                var transformerMock = new Mock<IPdfFileTransformerService>();

                repositoryMock.Setup(m => m.GetPdfFile(It.IsAny<Guid>())).ReturnsAsync(pdfFile);
                transformerMock.Setup(m => m.Transform(pdfFile)).Returns(pdfFileDto);

                var response = await CreateSut(pdfFileRepository: repositoryMock.Object, pdfFileTransformerService: transformerMock.Object).GetFile(location);

                repositoryMock.Verify(m => m.GetPdfFile(location), Times.Once);
                transformerMock.Verify(m => m.Transform(pdfFile), Times.Once);

                response.Result.ShouldBeOfType(typeof(OkObjectResult));
                var okObjectResult = response.Result as OkObjectResult;
                okObjectResult.Value.ShouldBeSameAs(pdfFileDto);
            }
        }
    }
}

