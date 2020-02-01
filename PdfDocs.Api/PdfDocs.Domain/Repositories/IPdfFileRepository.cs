using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PdfDocs.Domain
{
    public interface IPdfFileRepository
    {
        Task<int> UploadPdfFile(string fileName, byte[] fileContent);
    }
}
