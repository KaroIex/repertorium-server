using AutoMapper;
using RepertoriumAPI.Entities;
using RepertoriumAPI.Models;

namespace RepertoriumAPI.Configure;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Image, ImageDto>();
        CreateMap<Advertisement, AdvertisementDto>()
            .ForMember(a => a.Category,
                a => a.MapFrom(a => a.Category.Name));
        CreateMap<Advertisement, AdvertisementPagedDto>()
            .ForMember(a => a.Category,
                a => a.MapFrom(a => a.Category.Name));
        CreateMap<CreateAdvertisementDto, Advertisement>()
            .ForMember(a => a.Category,
            opt => opt.Ignore());
    }
}