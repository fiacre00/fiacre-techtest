using PdfDocs.Domain;
using PdfDocs.Domain.Entities;
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
        public  async Task<bool> DeletePdfFile(Guid location)
        {
            var result = await _pdfFileDb.DeletePdfFile(location);
            return  (result != 0);
        }

        public async Task<int> RearrangePdfFileList(IEnumerable<Guid> locations)
        {
            var orderedLocations = new List<FileArrangeType>();
            int i = 0;
            foreach(var location in locations)
            {
                orderedLocations.Add(new FileArrangeType
                {
                    Location = location,
                    FileOrdinal = ++i
                });
            }
            return await _pdfFileDb.RearrangePdfFileList(orderedLocations);
        }


        public async Task<PdfFile> GetPdfFile(Guid location)
        {
            var result = await _pdfFileDb.GetPdfFile(location);

            return new PdfFile
            {
                Location = location,
                FileContent = result,
                FileSize = (result == null) ? 0 : result.Length
            };
        }

        public async Task<FileList> GetPdfFileList()
        {
            var result = await _pdfFileDb.GetPdfFileList();

            return new FileList { PdfFiles = result };
        }

    }
}
