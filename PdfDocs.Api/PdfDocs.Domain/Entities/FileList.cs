using System;
using System.Collections.Generic;
using System.Text;

namespace PdfDocs.Domain.Entities
{
    public class FileList
    {
        public IEnumerable<PdfFile> PdfFiles { get; set; } = new List<PdfFile>();
    }
}
