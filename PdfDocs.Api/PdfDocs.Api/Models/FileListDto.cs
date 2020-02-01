using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdfDocs.Api.Models
{
    public class FileListDto
    {
        public IEnumerable<PdfFileDto> PdfFiles { get; set; } = new List<PdfFileDto>();
    }
}
