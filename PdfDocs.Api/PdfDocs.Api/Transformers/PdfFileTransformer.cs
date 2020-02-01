using PdfDocs.Api.Models;
using PdfDocs.Domain.Entities;

namespace PdfDocs.Api.Transformers
{
    public class PdfFileTransformer : ITransformer<PdfFile, PdfFileDto>
    {
        public PdfFileDto Transform(PdfFile source)
        {
            return new PdfFileDto
            {
                Location = source.Location,
                FileName = source.FileName,
                FileSize = source.FileSize,
                FileContent = source.FileContent,
                FileOrdinal = source.FileOrdinal
            };
        }
    }
}
