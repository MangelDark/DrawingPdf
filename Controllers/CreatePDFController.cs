using DrawingPdf.Methods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DrawingPdf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreatePDFController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CreatePDFController> _logger;
        private readonly PdfServices _pdfServices;
        public CreatePDFController(ILogger<CreatePDFController> logger, PdfServices pdfServices)
        {
            _logger = logger;
            _pdfServices = pdfServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _pdfServices.GenerarPdfMemoryStreamToTabla();
      
            return File(result, "application/pdf", "Reporte.pdf"); 
        }
    }
}
