using Application.Features.Stocks.Commands.Create;
using Application.Stocks.Queries;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Stocks.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Stock, CreateStockCommand>().ReverseMap();
        CreateMap<Stock, CreatedStockResponse>().ReverseMap();
        
        CreateMap<Stock, GetListStockListItemDto>()
            .ForMember(destinationMember: p => p.ProductName, 
                memberOptions: opt => opt.MapFrom( p=> p.Product.Name))
            .ReverseMap();
        CreateMap<Paginate<Stock>, GetListResponse<GetListStockListItemDto>>();
    }
}