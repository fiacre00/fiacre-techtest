using PdfDocs.Api.Models;
using PdfDocs.Api.Transformers;
using PdfDocs.Domain;
using PdfDocs.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PdfDocs.Api.Controllers
{
    [Route("api/v1/queries")]
    public class QueriesController : ControllerBase
    {
       
        private readonly IPdfFileTransformerService _pdfTransformerService;
        public QueriesController(
             IPdfFileTransformerService pdfFileTransformerService)
        {
            
            _pdfTransformerService = pdfFileTransformerService ?? throw new ArgumentNullException(nameof(pdfFileTransformerService));
        }

        [HttpGet]
        [Route("filelist")]
        public async Task<ActionResult<FileListDto>> GetFileList()
        {
            return Ok(new FileListDto());
        }

        [HttpGet]
        [Route("{location}")]
        public async Task<ActionResult<PdfFileDto>> GetFile([FromRoute]string location)
        {
            return Ok(_pdfTransformerService.Transform(new PdfFile()));
        }

    }
}
