using PdfDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PdfDocs.Domain.Services
{
    public interface IDecodeValidateService
    {
        DecodeValidateResponse DecodeValidate(string encoded);
    }
}
