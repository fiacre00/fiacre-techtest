using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PdfDocs.Domain
{
    public interface IPdfFileDb
    {
        Task<int> InsertPdfFile(string fileName, byte[] fileContent);
    }
}
