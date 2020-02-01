using System;
using System.Collections.Generic;
using System.Text;

namespace PdfDocs.Domain.Entities
{
    public class DecodeValidateResponse
    {
        public bool IsValidPdf { get; set; }
        public byte[] Decoded { get; set; }
        public string ValidationError { get; set; }

    }
}
