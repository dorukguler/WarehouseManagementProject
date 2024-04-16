using Application.Features.Sales.Commands.Create;
using Application.Features.Sales.Queries;
using Application.Services.SaleService;
using Application.Services.Repositories;
using Application.Services.StockService;
using Application.Services.TransactionService;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Sales.Commands.Create;

public class CreateSaleCommand : IRequest<CreatedSaleResponse>
{
    public Guid CustomerId { get; set; }
    public DateTime SaleDate { get; set; }
    public List<SaleDetailDto> SaleDetails { get; set; }
    
    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand,CreatedSaleResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionService _transactionService;
        private readonly ISaleRepository _saleRepository;
        private readonly IStockService _stockService;
        private readonly ISaleService _saleService;

        public CreateSaleCommandHandler(ISaleRepository saleRepository,ITransactionService transactionService,IMapper mapper,ISaleService saleService, IStockService stockService)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _transactionService = transactionService;
            _saleService = saleService;
            _stockService = stockService;
        }
        
        public async Task<CreatedSaleResponse> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            Sale sale = _mapper.Map<Sale>(request);
            sale.Id = Guid.NewGuid();
            
            sale.SaleDetails = request.SaleDetails
                .Select(detail => _mapper.Map<SaleDetail>(detail))
                .ToList();

            foreach (var detail in sale.SaleDetails)
            {
                detail.SaleId = sale.Id; // Ensuring each detail is linked to the Sale
                
                Transaction transaction = await _transactionService.CreateSaleTransaction(sale, detail);
                await _transactionService.Add(transaction);
            }

            var productId = sale.SaleDetails.Select(detail => detail.ProductId).Single();
            
            var quantity = sale.SaleDetails.Select(detail => detail.Quantity).Single();

            await _stockService.UpdateStockQuantityBasedOnSaleQuantity(productId, quantity);
            // Transaction transaction = await _transactionService.CreateSaleTransaction(Sale);
            await _saleRepository.AddAsync(sale);

            CreatedSaleResponse createdSaleResponse = _mapper.Map<CreatedSaleResponse>(sale);
            return createdSaleResponse;
        }
        
    }
}