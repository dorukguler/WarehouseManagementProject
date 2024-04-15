using Application.Features.Stocks.Rules;
using Application.Services.Repositories;
using Application.Services.StockService;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Stocks.Commands.Create;

public class CreateStockCommand : IRequest<CreatedStockResponse>
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    
    public class CreateStockCommandHandler : IRequestHandler<CreateStockCommand, CreatedStockResponse>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        private readonly IStockService _stockService;
        private readonly StockBusinessRules _stockBusinessRules;
        
        public CreateStockCommandHandler(IStockRepository stockRepository,IMapper mapper, IStockService stockService, StockBusinessRules stockBusinessRules)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
            _stockService = stockService;
            _stockBusinessRules = stockBusinessRules;
        }

        public async Task<CreatedStockResponse> Handle(CreateStockCommand request, CancellationToken cancellationToken)
        {
            await _stockBusinessRules.StockProductMustExistsWhenStockInserted(request.ProductId);
            await _stockBusinessRules.StockProductCanNotBeDuplicatedWhenInserted(request.ProductId);
            //
            // var existingStock = await _stockService.GetStockByProductId(
            //     request.ProductId);

            // if (existingStock != null)
            // {
            //     existingStock.Quantity += request.Quantity;
            //     await _stockRepository.UpdateAsync(existingStock);
            // }
            // else
            // {
            Stock stock = _mapper.Map<Stock>(request); 
            stock.Id = Guid.NewGuid();
            await _stockRepository.AddAsync(stock);
            //}
            
            CreatedStockResponse createdNewStockResponse = _mapper.Map<CreatedStockResponse>(stock);
            return createdNewStockResponse;
        }
    }
}