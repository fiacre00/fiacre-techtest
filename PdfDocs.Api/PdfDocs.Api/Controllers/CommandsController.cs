using PdfDocs.Api.Models;
using PdfDocs.Api.Transformers;
using PdfDocs.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace PdfDocs.Api.Controllers
{
    [Route("api/v1/commands")]
    public class CommandsController : ControllerBase
    {
        private readonly IPdfFileTransformerService _pdfTransformerService;

       
        public CommandsController(
             IPdfFileTransformerService pdfFileTransformerService)
        {
            _pdfTransformerService = pdfFileTransformerService ?? throw new ArgumentNullException(nameof(pdfFileTransformerService));
            
        }

        [HttpPost]
        [Route("upload")]
        public async Task<int> Upload([FromBody]PdfFileDto pdfFile)
        {
            return StatusCodes.Status201Created;
        }

        [HttpDelete]
        [Route("{location}/delete")]
        public async Task<int> Delete([FromRoute]string location)
        {
            return StatusCodes.Status200OK;
        }

        [HttpPatch]
        [Route("rearrange")]
        public async Task<int> Rearrange([FromBody]FileListDto fileList)
        {
            return StatusCodes.Status200OK;
        }



    }
}
