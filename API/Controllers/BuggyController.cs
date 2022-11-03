using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseAPIController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public IActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(42);
            if (thing == null)
                return NotFound(new APIResponse(StatusCodes.Status404NotFound));

            return Ok();
        }

        [HttpGet("servererror")]
        public IActionResult GetServerErrorRequest()
        {
            var thing = _context.Products.Find(42);
            var str = thing.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new APIResponse(StatusCodes.Status404NotFound));
        }

        [HttpGet("badrequest/{id}")]
        public IActionResult GetBadRequest(int id)
        {
            return Ok();
        }
    }
}