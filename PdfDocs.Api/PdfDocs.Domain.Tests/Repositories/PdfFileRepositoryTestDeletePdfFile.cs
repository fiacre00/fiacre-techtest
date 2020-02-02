using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PdfDocs.Domain.Tests.Repositories
{
    public partial class PdfFileRepositoryTests
    {
        public class PdfFileRepositoryTestDeletePdfFile : PdfFileRepositoryFixture
        {
            [Fact]
            public async Task DeletePdfFile_Calls_PdfFileDb_DeletePdfFile()
            {
                var location = Guid.NewGuid();
                var pdfFileDb = Mock.Of<IPdfFileDb>();

                await CreateSut(pdfFileDb).DeletePdfFile(location);

                Mock.Get(pdfFileDb).Verify(m => m.DeletePdfFile(location), Times.Once);

            }
        }
    }
}

