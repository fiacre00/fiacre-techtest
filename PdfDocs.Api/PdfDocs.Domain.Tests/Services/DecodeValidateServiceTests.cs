using PdfDocs.Domain.Services;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PdfDocs.Domain.Tests.Services
{
    public class DecodeValidateServiceTests
    {
        private DecodeValidateService CreateSut() => new DecodeValidateService();

        [Fact]
        public void InvalidBase64_Returns_Invalid()
        {
            var decodeValidateService = CreateSut();

            var response = decodeValidateService.DecodeValidate("JVBERi0");

            response.IsValidPdf.ShouldBe(false);
        }

        [Fact]
        public void InvalidPdfHeader_Returns_Invalid()
        {
            var decodeValidateService = CreateSut();

            var response = decodeValidateService.DecodeValidate("Tm90UGRm");

            response.IsValidPdf.ShouldBe(false);
          
        }

        [Fact]
        public void ValidPdfHeader_Returns_Valid()
        {
            var decodeValidateService = CreateSut();

            var response = decodeValidateService.DecodeValidate("JVBERi0x");

            response.IsValidPdf.ShouldBe(true);
           
        }
    }
}
