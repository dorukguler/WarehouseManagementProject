using Application.Features.Suppliers.Queries.GetList;
using AutoMapper;

using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Suppliers.Profiles;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
      
        CreateMap<Supplier, GetListSupplierListItemDto>().ReverseMap();
        CreateMap<Paginate<Supplier>, GetListResponse<GetListSupplierListItemDto>>().ReverseMap();
        
    }
}