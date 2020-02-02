using PdfDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PdfDocs.Domain
{
    public interface IPdfFileDb
    {
        Task<int> InsertPdfFile(string fileName, byte[] fileContent);

        Task<int> DeletePdfFile(Guid Location);

        Task<int> RearrangePdfFileList(ICollection<FileArrangeType> orderedLocations);

        Task<byte[]> GetPdfFile(Guid location);

        Task<IEnumerable<PdfFile>> GetPdfFileList();
    }
}
