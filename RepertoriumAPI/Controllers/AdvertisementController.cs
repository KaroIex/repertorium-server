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

    [HttpGet("{advertisementId}")]
    public ActionResult<IEnumerable<AdvertisementDto>> GetAdvertisementById([FromRoute] int advertisementId)
    {
        var advertisements = _advertisementService.GetAdvertisementById(advertisementId);

        return Ok(advertisements);
    }

    [HttpGet]
    public ActionResult<IEnumerable<AdvertisementDto>> GetPagedList([FromQuery] AdvertisementQuery query)
    {
        var advertisements = _advertisementService.GetPagedList(query);

        return Ok(advertisements);
    }

    [HttpPut]
    public ActionResult CreateAdvertisement([FromBody] CreateAdvertisementDto dto)
    {
        var id = _advertisementService.Create(dto);
        return Created($"/api/restaurants/{id}", null);
    }
}