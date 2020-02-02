using Moq;
using PdfDocs.Api.Models;
using PdfDocs.Api.Transformers;
using PdfDocs.Domain.Entities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PdfDocs.Api.Tests.Transformers
{
    public partial class FileListTransformerTests
    {
        public class FileListTransformerTransformTest
        {
            private FileListTransformer CreateSut(
                ITransformer<PdfFile, PdfFileDto> pdfFileTransformer = null)
            {
                return new FileListTransformer(
                    pdfFileTransformer ?? Mock.Of<ITransformer<PdfFile, PdfFileDto>>());
            }

            [Fact]
            public void Transform_Uses_FileListTransformer_Transform_With_Source_PdfFile()
            {
                var source = new FileList();
                var pdfFiles = new List<PdfFile>();
                var pdfFile = new PdfFile();
                pdfFiles.Add(pdfFile);
                source.PdfFiles = pdfFiles;
                var pdfFileTransformer = new Mock<ITransformer<PdfFile, PdfFileDto>>();
                var sut = CreateSut(pdfFileTransformer.Object);

                sut.Transform(source);

                pdfFileTransformer.Verify(q => q.Transform(pdfFile), Times.Once());
            }

            [Fact]
            public void Transform_Returns_The_Instance_Of_GameDto_With_Player_Returned_By_PlayerTransformer()
            {
                var source = new FileList();
                var pdfFiles = new List<PdfFile>();
                var pdfFile = new PdfFile();
                pdfFiles.Add(pdfFile);
                source.PdfFiles = pdfFiles;

                var pdfFileTransformer = Mock.Of<ITransformer<PdfFile, PdfFileDto>>();
                var pdfFileDto = new PdfFileDto();

                Mock.Get(pdfFileTransformer)
                    .Setup(q => q.Transform(It.IsAny<PdfFile>()))
                    .Returns(pdfFileDto);

                var result = CreateSut(pdfFileTransformer).Transform(source);

                result.PdfFiles.FirstOrDefault<PdfFileDto>().ShouldBeSameAs(pdfFileDto);
            }
        }
    }
}
