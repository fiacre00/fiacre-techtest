using PdfDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PdfDocs.Domain
{
    public interface IPdfFileRepository
    {
        Task<int> UploadPdfFile(string fileName, byte[] fileContent);

        Task<bool> DeletePdfFile(Guid location);

        Task<int> RearrangePdfFileList(IEnumerable<Guid> locations);

        Task<PdfFile> GetPdfFile(Guid location);

        Task<FileList> GetPdfFileList();
    }
}
