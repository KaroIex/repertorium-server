using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepertoriumAPI.Entities;
using RepertoriumAPI.Models;
using RepertoriumAPI.Services;

namespace RepertoriumAPI.Controllers;

[ApiController]
[Route("api/images")]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;

    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpGet("{advertisementId}")]
    public ActionResult<List<ImageDto>> Get([FromRoute] int advertisementId)
    {
        var result = _imageService.Get(advertisementId);

        return Ok(result);
    }
    
}