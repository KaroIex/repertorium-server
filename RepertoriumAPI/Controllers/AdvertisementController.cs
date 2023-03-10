using Microsoft.AspNetCore.Mvc;
using RepertoriumAPI.Entities;

namespace RepertoriumAPI.Controllers;

[ApiController]
[Route("api/advertisement")]
public class AdvertisementController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Advertisement>> GetAll()
    {
        return Ok();
    }
}