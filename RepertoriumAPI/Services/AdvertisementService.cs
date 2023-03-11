using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepertoriumAPI.Entities;
using RepertoriumAPI.Models;

namespace RepertoriumAPI.Services;

public interface IAdvertisementService
{
    List<AdvertisementDto> GetAll();
}

public class AdvertisementService : IAdvertisementService
{
    private readonly RepertoriumDbContext _dbContext;
    private readonly IMapper _mapper;

    public AdvertisementService(RepertoriumDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<AdvertisementDto> GetAll()
    {
        var advertisements = _dbContext
            .Advertisements
            .Include(a => a.Category)
            .Include(a => a.Images)
            .ToList();
        var a = _mapper.Map<List<AdvertisementDto>>(advertisements);
        return a;
    }
}