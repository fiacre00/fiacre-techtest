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

namespace PdfDocs.Api.Tests.Controllers
{
    public partial class QueriesControllerTests
    {
        public class QueriesControllerTestGetFileList
        {
            private QueriesController CreateSut(
                IPdfFileTransformerService pdfFileTransformerService = null)
            {
                return new QueriesController(
                    pdfFileTransformerService ?? Mock.Of<IPdfFileTransformerService>());
            }

            [Fact]
            public async Task GetFileList_Returns_Ok_With_FileList()
            {

                var response =  await CreateSut().GetFileList();

                response.Result.ShouldBeOfType(typeof(OkObjectResult));
            }

        }
    }
}
