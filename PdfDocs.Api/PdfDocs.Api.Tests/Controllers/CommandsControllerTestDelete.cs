using PdfDocs.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using System;
using System.Threading.Tasks;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;
using Xunit;


namespace PdfDocs.Api.Tests.Controllers
{
    public partial class CommandsControllerTests
    {
        public class CommandsControllerTestDelete : CommandsControllerFixture
        {
            [Fact]
            public async Task Delete_Uses_RepositoryDelete_With_Location()
            {
                var location = Guid.NewGuid();

                var repositoryMock = new Mock<IPdfFileRepository>();
                repositoryMock.Setup(f => f.DeletePdfFile(It.IsAny<Guid>())).ReturnsAsync(true);

                var response = await CreateSut(pdfFileRepository: repositoryMock.Object).Delete(location);

                (response.Result as ObjectResult).StatusCode.ShouldBe(StatusCodes.Status200OK);

                repositoryMock.Verify(m => m.DeletePdfFile(location), Times.Once);

            }
        }
    }
}
