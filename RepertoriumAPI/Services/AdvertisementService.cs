using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepertoriumAPI.Entities;
using RepertoriumAPI.Models;

namespace RepertoriumAPI.Services;

public interface IAdvertisementService
{
    AdvertisementDto GetAdvertisementById(int id);
    PagedResult<AdvertisementPagedDto> GetPagedList(AdvertisementQuery query);
    int Create(CreateAdvertisementDto dto);
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

    public AdvertisementDto GetAdvertisementById(int id)
    {
        var advertisement = _dbContext
            .Advertisements
            .Include(a => a.Category)
            .Include(a => a.Images)
            .FirstOrDefault(a => a.Id == id);

        var advertisementDto = _mapper.Map<AdvertisementDto>(advertisement);
        return advertisementDto;
    }

    public PagedResult<AdvertisementPagedDto> GetPagedList(AdvertisementQuery query)
    {
        var baseQery = _dbContext
            .Advertisements
            .Include(r => r.Category)
            .Where(r => query.SearchPhrase == null || r.Title.ToLower().Contains(query.SearchPhrase.ToLower()) ||
                        r.Description.ToLower().Contains(query.SearchPhrase.ToLower()));


        var advertisements = baseQery
            .Skip(query.PageSize * (query.PageNumber - 1))
            .Take(query.PageSize)
            .ToList();

        var totalItemsCount = baseQery.Count();

        var advertisementsPagedDto = _mapper.Map<List<AdvertisementPagedDto>>(advertisements);

        var pagedResult = new PagedResult<AdvertisementPagedDto>(advertisementsPagedDto, totalItemsCount,
            query.PageSize,
            query.PageNumber);

        return pagedResult;
    }


    public int Create(CreateAdvertisementDto dto)
    {
        var advertisement = _mapper.Map<Advertisement>(dto);
        advertisement.Category = _dbContext
            .Categories
            .FirstOrDefault(c => c.Name == dto.Category);
        _dbContext.Add(advertisement);
        _dbContext.SaveChanges();
        return advertisement.Id;
    }
}