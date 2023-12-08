using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Chatbot.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult GetHttpResponse(in HttpStatusCode status, in object body, in string errorMessage, in string uri = null)
        {
            var httpResponse = new { status, body, errorMessage };

            if (status == HttpStatusCode.BadRequest)
                return BadRequest(httpResponse);
            if (status == HttpStatusCode.Conflict)
                return Conflict(httpResponse);
            if (status == HttpStatusCode.Unauthorized)
                return Unauthorized(httpResponse);
            if (status == HttpStatusCode.Forbidden)
                return Forbid();
            if (status == HttpStatusCode.NotFound)
                return NotFound(httpResponse);

            if (status == HttpStatusCode.OK)
                return Ok(httpResponse);
            if (status == HttpStatusCode.Created)
                return Created(uri!, httpResponse);

            if (status == HttpStatusCode.InternalServerError)
                return StatusCode(500);

            return NoContent();
        }
    }
}
