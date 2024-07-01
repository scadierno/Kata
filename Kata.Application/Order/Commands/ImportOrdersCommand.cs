using AutoMapper;
using Kata.Application.Order.Interfaces;
using Kata.Application.Order.Model;
using MediatR;

namespace Kata.Application.Order.Commands
{
    public class ImportOrdersCommand : IRequest<OrderSummaryDto> { }
    public sealed class ImportOrdersCommandHandler : IRequestHandler<ImportOrdersCommand, OrderSummaryDto>
    {
        private readonly IMapper _mapper;
        private readonly IOrderHttpClient _orderHttpClient;
        private readonly IOrderRepository _orderRepository;
        public ImportOrdersCommandHandler(IMapper mapper, IOrderHttpClient orderHttpClient, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderHttpClient = orderHttpClient;
            _orderRepository = orderRepository;
        }

        public async Task<OrderSummaryDto> Handle(ImportOrdersCommand request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync(cancellationToken);
            if (!orders.Any())
            {
                orders = _mapper.Map<IEnumerable<Domain.Entities.Order>>((await _orderHttpClient.GetOrdersAsync(cancellationToken)).Content);
                await _orderRepository.InsertAsync(orders, cancellationToken);
            }

            return _mapper.Map<OrderSummaryDto>(orders);
        }
    }
}
