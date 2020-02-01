using PdfDocs.Api.Models;
using PdfDocs.Api.Transformers;
using PdfDocs.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using System;
using System.Threading.Tasks;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;
using Xunit;
using PdfDocs.Domain.Services;

namespace PdfDocs.Api.Tests.Controllers
{
    public partial class CommandsControllerTests
    {
        public class CommandsControllerTestUpload : CommandsControllerFixture
        {
            [Fact]
            public async Task Uplpoad_Uses_RepositoryUpload_With_File()
            {
                
                var pdfFile = new PdfFileDto
                {
                    FileContent = "JVBERgo=",
                    FileName = "my.pdf"
                };
                                                               
                var mock = new Mock<IDecodeValidateService>();
                
                mock.Setup(f => f.DecodeValidate(pdfFile.FileContent)).Returns(new Domain.Entities.DecodeValidateResponse { IsValidPdf = true });
                
                var response = await CreateSut(decodeValidateService:mock.Object).Upload(pdfFile);

                (response.Result as ObjectResult).StatusCode.ShouldBe(StatusCodes.Status201Created);

                mock.Verify(m => m.DecodeValidate(pdfFile.FileContent), Times.Once());
            }

           
        }
    }
}
