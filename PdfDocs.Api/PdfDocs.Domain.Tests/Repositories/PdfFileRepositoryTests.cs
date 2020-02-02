using Moq;
using PdfDocs.Data;

namespace PdfDocs.Domain.Tests.Repositories
{
    public partial class PdfFileRepositoryTests
    {
        public abstract class PdfFileRepositoryFixture
        {
            protected PdfFileRepository CreateSut(
                IPdfFileDb pdfFileDb = null)
            {
                return new PdfFileRepository(
                      pdfFileDb ?? Mock.Of<IPdfFileDb>());
            }
        }
    }
}
