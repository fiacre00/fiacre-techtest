using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PdfDocs.Domain.Tests.Repositories
{
    public partial class PdfFileRepositoryTests
    {
        public class PdfFileRepositoryTestGetPdfFile : PdfFileRepositoryFixture
        {

            [Fact]
            public async Task GetPdfFile_Calls_PdfFileDb_GetPdfFile()
            {
                var location = Guid.NewGuid();
                var pdfFileDb = Mock.Of<IPdfFileDb>();
                
                await CreateSut(pdfFileDb).GetPdfFile(location);

                Mock.Get(pdfFileDb).Verify(m => m.GetPdfFile(location), Times.Once);

            }
        }
    }
}
