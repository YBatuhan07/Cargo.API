using Cargo.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Cargo.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomBaseController : ControllerBase
{
    [NonAction]
    public IActionResult CreateActionResult<T>(ServiceResult<T> result)
    {
        if (result.StatusCode == HttpStatusCode.NoContent)
            return NoContent();

        if (result.StatusCode == HttpStatusCode.Created)
            return Created();

        return new ObjectResult(result) { StatusCode = (int)result.StatusCode };
    }

    [NonAction]
    public IActionResult CreateActionResult(ServiceResult result)
    {
        if (result.StatusCode == HttpStatusCode.NoContent)
            return NoContent();

        return new ObjectResult(result) { StatusCode = (int)result.StatusCode };
    }
}