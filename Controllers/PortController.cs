using ArduinoControl.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArduinoControl.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortController : Controller
    {
        private readonly ILogger<PortController> _logger;
        private readonly IPortService _portService;

        public PortController(ILogger<PortController> logger, IPortService portService)
        {
            _logger = logger;
            _portService = portService;
        }
        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            var data = _portService.GetAll();
            return Json(data);
        }
        [HttpPost]
        // POST: port/OpenPort
        [Route("SendPort")]

         public JsonResult Send(string portName)
        {
            var isOpen = _portService.SendPort(portName);

             return Json(isOpen);
        }
         [HttpPost]
         [Route("ClosePort")]
         public JsonResult PostClose(string portName)
        {
         //  var isClose = _portService.SendPort(portName);
         
             return Json("close");
        }

    }
}