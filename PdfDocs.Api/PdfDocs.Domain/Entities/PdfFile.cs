using System;
using System.Collections.Generic;
using System.Text;

namespace PdfDocs.Domain.Entities
{
    public class PdfFile
    {
        public Guid Location { get; set; }

        public string FileName { get; set; }

        public int FileSize { get; set; }

        public byte[] FileContent { get; set; }

        public int FileOrdinal { get; set; }
    }
}
