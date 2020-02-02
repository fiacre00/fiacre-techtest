using PdfDocs.Api.Models;
using PdfDocs.Domain.Entities;
using System;

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
                FileContent = (source.FileContent == null) ? null: Convert.ToBase64String(source.FileContent, Base64FormattingOptions.None),
                FileOrdinal = source.FileOrdinal
            };
        }
    }
}
