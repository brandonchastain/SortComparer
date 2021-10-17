using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SortCompare.Controllers
{
    [ApiController]
    public class CompareSortsController : ControllerBase
    {
        private readonly ILogger<CompareSortsController> _logger;

        public CompareSortsController(ILogger<CompareSortsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]")]
        public ActionResult<CompareSortResult> CompareSorts(int arraySize)
        {
            //if (arraySize > 10000)
            //{
            //    return BadRequest();
            //}

            var sortComparer = new SortComparer();
            var result = sortComparer.CompareSorts(arraySize);
            return Ok(result);
        }
    }
}
