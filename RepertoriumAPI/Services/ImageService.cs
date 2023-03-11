using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepertoriumAPI.Entities;
using RepertoriumAPI.Models;

namespace RepertoriumAPI.Services;

public interface IImageService
{
    List<ImageDto> Get(int advertisementId);
}

public class ImageService : IImageService
{
    private readonly RepertoriumDbContext _dbContext;
    private readonly IMapper _mapper;

    public ImageService(RepertoriumDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<ImageDto> Get(int advertisementId)
    {
        var advertisement = _dbContext
            .Advertisements
            .Include(a => a.Images)
            .FirstOrDefault(a => a.Id == advertisementId);

        if (advertisement is null)
            throw new Exception("Restaurant not found");

        var images = advertisement.Images.ToList();

        var result = _mapper.Map<List<ImageDto>>(images);
        return result;
    }
}