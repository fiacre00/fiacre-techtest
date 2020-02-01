using PdfDocs.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PdfDocs.Data
{
    public class PdfFileRepository: IPdfFileRepository
    {

        private readonly IPdfFileDb _pdfFileDb;

        public PdfFileRepository(IPdfFileDb pdfFileDb)
        {
            _pdfFileDb = pdfFileDb ?? throw new ArgumentNullException(nameof(pdfFileDb));
        }
        public async Task<int> UploadPdfFile(string fileName, byte[] fileContent)
        {
           return await _pdfFileDb.InsertPdfFile(fileName, fileContent);
        }
    }
}
