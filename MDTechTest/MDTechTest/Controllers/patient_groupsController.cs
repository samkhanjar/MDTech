using MDTechTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDTechTest.Controllers
{
    public class patient_groupsController : Controller
    {
        private readonly ILogger _logger;

        public patient_groupsController(ILogger<patient_groupsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("api/[controller]/calculate")]
        public IActionResult Calculate([FromBody] PatientModel patients)
        {
            _logger.LogInformation("Calculating number of groups");
            
            return Ok();
        }
    }
}
