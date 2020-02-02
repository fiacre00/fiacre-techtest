using PdfDocs.Api.Models;
using PdfDocs.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;
using Xunit;

namespace PdfDocs.Api.Tests.Controllers
{
    public partial class CommandsControllerTests
    {
        public class CommandsControllerTestRearrange : CommandsControllerFixture
        {
            [Fact]
            public async Task Rearrange_Uses_RepositoryRearrange_With_Locations()
            {
                var fileList = new FileListDto();
                var pdfFiles = new List<PdfFileDto>();
                pdfFiles.Add(new PdfFileDto { Location = Guid.NewGuid() });
                fileList.PdfFiles = pdfFiles;

                var repositoryMock = new Mock<IPdfFileRepository>();
                var response = await CreateSut(pdfFileRepository: repositoryMock.Object).Rearrange(fileList);

                (response.Result as ObjectResult).StatusCode.ShouldBe(StatusCodes.Status200OK);

                repositoryMock.Verify(m => m.RearrangePdfFileList(It.IsAny<IEnumerable<Guid>>()), Times.Once);
            }
        }
    }
}
