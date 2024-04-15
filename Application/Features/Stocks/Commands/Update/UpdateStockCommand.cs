using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Stocks.Commands.Update;

public class UpdateStockCommand : IRequest<UpdatedStockResponse>
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    
    public class UpdateStockCommandHandler: IRequestHandler<UpdateStockCommand, UpdatedStockResponse>
    {
        private IStockRepository _stockRepository;
        private IMapper _mapper;

        public UpdateStockCommandHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }


        public async Task<UpdatedStockResponse> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            Stock stock = _mapper.Map<Stock>(request);

            await _stockRepository.UpdateAsync(stock);

            UpdatedStockResponse updatedStockResponse = _mapper.Map<UpdatedStockResponse>(stock);

            return updatedStockResponse;
        }
    }
}