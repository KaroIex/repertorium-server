using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepertoriumAPI.Entities;
using RepertoriumAPI.Models;

namespace RepertoriumAPI.Controllers;

[ApiController]
[Route("api/images")]
public class ImageController : ControllerBase
{
    private readonly RepertoriumDbContext _dbContext;
    private readonly IMapper _mapper;

    public ImageController(RepertoriumDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpGet("{advertisementId}")]
    public ActionResult<List<Image>> Get([FromRoute] int advertisementId)
    {
        var advertisement = _dbContext
            .Advertisements
            .Include(a => a.Images)
            .FirstOrDefault(a => a.Id == advertisementId);

        if (advertisement is null)
            throw new Exception("Restaurant not found");

        var images = advertisement.Images.ToList();

        var result = _mapper.Map<List<ImageDto>>(images);
        
        return Ok(result);
    }
}