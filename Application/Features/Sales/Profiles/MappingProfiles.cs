using Application.Features.Purchases.Queries.GetListPurchaseListItemDto;
using Application.Features.Sales.Commands.Create;
using Application.Features.Sales.Queries;
using Application.Features.Sales.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Sales.Profiles;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Sale, CreateSaleCommand>().ReverseMap();
        CreateMap<Sale, CreatedSaleResponse>().ReverseMap();
        
        
        CreateMap<SaleDetail, SaleDetailDto>()
            .ForMember(destinationMember: p => p.ProductId, 
                memberOptions: opt => opt.MapFrom( p=> p.ProductId))
            .ReverseMap();
        CreateMap<Paginate<Sale>, GetListResponse<GetListSaleListItemDto>>();
    } 
}