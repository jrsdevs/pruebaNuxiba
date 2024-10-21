using Microsoft.AspNetCore.Mvc;
using nuxibaService.Contexto;
using nuxibaService.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;

namespace nuxibaService.Controllers
{
    [Route("api/csv")]
    [ApiController]
    public class CsvController : ControllerBase
    {
        private readonly NuxibaContext _context;
        private Services.ServiceCSV _service;
        public CsvController(NuxibaContext context)
        {
            _context = context;
            _service = new Services.ServiceCSV(_context);
        }

        [HttpGet]
        public IActionResult generaCsv()
        {
            var csv = _service.ProcesaCSV();
            var byteArray = Encoding.UTF8.GetBytes(csv);
            var stream = new MemoryStream(byteArray);

            return File(byteArray, "text/csv", "listaSesiones.csv");

        }





    }
}
