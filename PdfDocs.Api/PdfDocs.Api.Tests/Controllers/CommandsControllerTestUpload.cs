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

namespace PdfDocs.Api.Tests.Controllers
{
    public partial class CommandsControllerTests
    {
        public class CommandsControllerTestUpload : CommandsControllerFixture
        {
            [Fact]
            public async Task Uplpoad_Uses_RepositoryUpload_With_File()
            {
                var response = await CreateSut().Upload(new PdfFileDto());

                response.ShouldBe(StatusCodes.Status201Created);
            }

           
        }
    }
}
