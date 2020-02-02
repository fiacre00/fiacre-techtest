using PdfDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PdfDocs.Domain.Services
{
    public class DecodeValidateService:IDecodeValidateService
    {
        private const string PDFencodedStart = "JVBERi0"; //%PDF-
        private readonly int maxFileSizeBytes = 5 * 1024 * 1024;
        public  DecodeValidateResponse DecodeValidate(string encoded)
        {
            var response = new DecodeValidateResponse
            {
                IsValidPdf = true
            };

            Span<byte> buffer = new Span<byte>(new byte[encoded.Length]);
            if (!Convert.TryFromBase64String(encoded, buffer, out int bytesParsed))
            {
                response.IsValidPdf = false;
                response.ValidationError = "Invalid Base64 string";
            }
            else 
            {
                response.Decoded = buffer.ToArray();
                if(response.Decoded.Length > maxFileSizeBytes)
                {
                    response.IsValidPdf = false;
                    response.ValidationError = "File is too large";
                }
                if(!encoded.StartsWith("JVBERi0")) 
                {
                    response.IsValidPdf = false;
                    response.ValidationError = "Not a valid PDF";
                }
            }

            return response;
        }
    }
}
