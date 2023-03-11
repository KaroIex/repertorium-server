using Microsoft.AspNetCore.Mvc;
using RepertoriumAPI.Models;
using RepertoriumAPI.Services;

namespace RepertoriumAPI.Controllers;

[ApiController]
[Route("api/advertisement")]
public class AdvertisementController : ControllerBase
{
    private readonly IAdvertisementService _advertisementService;

    public AdvertisementController(IAdvertisementService advertisementService)
    {
        _advertisementService = advertisementService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<AdvertisementDto>> GetAll()
    {
        var advertisements = _advertisementService.GetAll();

        return Ok(advertisements);
    }

    [HttpPut]
    public ActionResult Create([FromBody] CreateAdvertisementDto dto)
    {
        var advertisements = _advertisementService.GetAll();

        return Ok(advertisements);
    }
}