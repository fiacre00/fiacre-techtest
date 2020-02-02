using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PdfDocs.Domain.Tests.Repositories
{
    public partial class PdfFileRepositoryTests
    {
        public class PdfFileRepositoryTestGetPdfFileList : PdfFileRepositoryFixture
        {
            [Fact]
            public async Task GetPdfFileList_Calls_PdfFileDb_GetPdfFileList()
            {
                var location = Guid.NewGuid();
                var pdfFileDb = Mock.Of<IPdfFileDb>();

                await CreateSut(pdfFileDb).GetPdfFileList();

                Mock.Get(pdfFileDb).Verify(m => m.GetPdfFileList(), Times.Once);

            }
        }
    }
}
