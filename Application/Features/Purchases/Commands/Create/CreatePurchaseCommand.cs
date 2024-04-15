using Application.Features.Purchases.Queries;
using Application.Services.PurchaseService;
using Application.Services.Repositories;
using Application.Services.StockService;
using Application.Services.TransactionService;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Purchases.Commands.Create;

public class CreatePurchaseCommand: IRequest<CreatedPurchaseResponse>
{
    public Guid SupplierId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public List<PurchaseDetailDto> PurchaseDetails { get; set; }

    public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand,CreatedPurchaseResponse>
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;
        private readonly ITransactionService _transactionService;
        private readonly IPurchaseService _purchaseService;
        private readonly IStockService _stockService;

        public CreatePurchaseCommandHandler(IPurchaseRepository purchaseRepository,ITransactionService transactionService,IMapper mapper,IPurchaseService purchaseService, IStockService stockService)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
            _transactionService = transactionService;
            _purchaseService = purchaseService;
            _stockService = stockService;
        }
        
        public async Task<CreatedPurchaseResponse> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
        {
            Purchase purchase = _mapper.Map<Purchase>(request);
            purchase.Id = Guid.NewGuid();
            
            purchase.PurchaseDetails = request.PurchaseDetails
                .Select(detail => _mapper.Map<PurchaseDetail>(detail))
                .ToList();

            foreach (var detail in purchase.PurchaseDetails)
            {
                detail.PurchaseId = purchase.Id; // Ensuring each detail is linked to the purchase
                
                Transaction transaction = await _transactionService.CreatePurchaseTransaction(purchase, detail);
                await _transactionService.Add(transaction);
            }

            var productId = purchase.PurchaseDetails.Select(detail => detail.ProductId).Single();
            
            var quantity = purchase.PurchaseDetails.Select(detail => detail.Quantity).Single();

            await _stockService.UpdateStockQuantityBasedOnPurchaseQuantity(productId, quantity);
            // Transaction transaction = await _transactionService.CreatePurchaseTransaction(purchase);
            await _purchaseRepository.AddAsync(purchase);

            CreatedPurchaseResponse createdPurchaseResponse = _mapper.Map<CreatedPurchaseResponse>(purchase);
            return createdPurchaseResponse;
        }
        
    }
}