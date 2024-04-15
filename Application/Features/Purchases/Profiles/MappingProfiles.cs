using Application.Features.Purchases.Commands.Create;
using Application.Features.Purchases.Queries;
using Application.Features.Purchases.Queries.GetListPurchaseListItemDto;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Purchases.Profiles;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Purchase, CreatePurchaseCommand>().ReverseMap();
        CreateMap<Purchase, CreatedPurchaseResponse>().ReverseMap();
        
        
        CreateMap<PurchaseDetail, PurchaseDetailDto>()
            .ForMember(destinationMember: p => p.ProductId, 
                 memberOptions: opt => opt.MapFrom( p=> p.ProductId))
            .ReverseMap();
        CreateMap<Paginate<Purchase>, GetListResponse<GetListPurchaseListItemDto>>();
    }
}