using System;

namespace PdfDocs.Api.Models
{
    public class PdfFileDto
    {
        public Guid Location { get; set; }

        public string FileName { get; set; }

        public int FileSize { get; set; }

        public string FileContent { get; set; }

        public int FileOrdinal { get; set; }
    }
}
