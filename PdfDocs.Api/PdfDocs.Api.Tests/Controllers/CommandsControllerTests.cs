using PdfDocs.Api.Controllers;
using PdfDocs.Api.Transformers;
using PdfDocs.Domain;
using Moq;

namespace PdfDocs.Api.Tests.Controllers
{
    public partial class CommandsControllerTests
    {
        public abstract class CommandsControllerFixture
        {
            protected CommandsController CreateSut(
                IPdfFileTransformerService pdfFileTransformerService = null)
            {
                return new CommandsController(
                      pdfFileTransformerService ?? Mock.Of<IPdfFileTransformerService>());
            }
        }
    }
}
