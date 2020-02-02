using Moq;
using PdfDocs.Api.Controllers;
using PdfDocs.Api.Transformers;
using PdfDocs.Domain;
using PdfDocs.Domain.Services;

namespace PdfDocs.Api.Tests.Controllers
{
    public partial class CommandsControllerTests
    {
        public abstract class CommandsControllerFixture
        {
            protected CommandsController CreateSut(
                IPdfFileTransformerService pdfFileTransformerService = null,
                IPdfFileRepository pdfFileRepository = null,
                IDecodeValidateService decodeValidateService = null)
            {
                return new CommandsController(
                      pdfFileTransformerService ?? Mock.Of<IPdfFileTransformerService>(),
                      pdfFileRepository ?? Mock.Of<IPdfFileRepository>(),
                      decodeValidateService ?? Mock.Of<IDecodeValidateService>());
            }
        }
    }
}
