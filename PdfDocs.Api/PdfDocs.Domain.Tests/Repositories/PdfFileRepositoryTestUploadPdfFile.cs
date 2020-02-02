using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PdfDocs.Domain.Tests.Repositories
{
    public partial class PdfFileRepositoryTests
    {
        public class PdfFileRepositoryTestUploadPdfFile : PdfFileRepositoryFixture
        {
            [Fact]
            public async Task UploadPdfFile_Calls_PdfFileDb_InsertPdfFile()
            {
                var fileName = "testFile.pdf";
                byte[] fileContent = new byte[] {0x00, 0x21};

                var pdfFileDb = Mock.Of<IPdfFileDb>();

                await CreateSut(pdfFileDb).UploadPdfFile(fileName, fileContent);

                Mock.Get(pdfFileDb).Verify(m => m.InsertPdfFile(fileName,fileContent), Times.Once);

            }
        }
    }
}
