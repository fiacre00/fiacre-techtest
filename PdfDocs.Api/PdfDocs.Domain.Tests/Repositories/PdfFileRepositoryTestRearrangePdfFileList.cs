using Moq;
using PdfDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PdfDocs.Domain.Tests.Repositories
{
    public partial class PdfFileRepositoryTests
    {
        public class PdfFileRepositoryTestRearrangePdfFileList : PdfFileRepositoryFixture
        {
            [Fact]
            public async Task RearrangePdfFileList_Calls_PdfFileDb_RearrangePdfFileList()
            {
                var location = Guid.NewGuid();
                var locations = new List<Guid>();
                locations.Add(location);
                
                var pdfFileDb = Mock.Of<IPdfFileDb>();

                await CreateSut(pdfFileDb).RearrangePdfFileList(locations);

                Mock.Get(pdfFileDb).Verify(m => m.RearrangePdfFileList(It.IsAny<List<FileArrangeType>>()), Times.Once);

            }
        }
    }
}
