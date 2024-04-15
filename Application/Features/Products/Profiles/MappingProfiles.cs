using Application.Features.Products.Commands.Create;
using Application.Features.Products.Queries;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Products.Profiles;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, CreateProductCommand>().ReverseMap();
        CreateMap<Product, CreatedProductResponse>().ReverseMap();
        
        CreateMap<Product, GetListProductListItemDto>()
            .ForMember(destinationMember: p => p.CategoryName, 
                memberOptions: opt => opt.MapFrom( p=> p.Category.Name))
            .ForMember(destinationMember: p => p.SupplierName, 
                memberOptions: opt => opt.MapFrom(p => p.Supplier.Name))
            .ReverseMap();
        CreateMap<Paginate<Product>, GetListResponse<GetListProductListItemDto>>();
    }
}