using Application.Services.Repositories;
using Application.Stocks.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Stocks.Queries.GetList;

public class GetListStockQuery : IRequest<GetListResponse<GetListStockListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListStockQueryHandler : IRequestHandler<GetListStockQuery,GetListResponse<GetListStockListItemDto>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public GetListStockQueryHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListStockListItemDto>> Handle(GetListStockQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Stock> stocks = await _stockRepository.GetListAsync(
                include: p => p.Include(p => p.Product),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
            );
            GetListResponse<GetListStockListItemDto> response = _mapper.Map<GetListResponse<GetListStockListItemDto>>(stocks);
            return response;
        }
    }
}