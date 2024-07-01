using AutoMapper;
using Kata.Application.Order.Interfaces;
using Kata.Application.Order.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Kata.Application.Order.Queries
{
    public class GetOrdersFileQuery : IRequest<FileContentResult> { }
    public sealed class GetOrdersFileQueryHandler : IRequestHandler<GetOrdersFileQuery, FileContentResult>
    {
        private readonly IMapper _mapper;
        private readonly IOrderHttpClient _orderHttpClient;
        private readonly IOrderRepository _orderRepository;
        public GetOrdersFileQueryHandler(IMapper mapper, IOrderHttpClient orderHttpClient, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderHttpClient = orderHttpClient;
            _orderRepository = orderRepository;
        }

        public async Task<FileContentResult> Handle(GetOrdersFileQuery request, CancellationToken cancellationToken)
        {
            var csv = new StringBuilder().AppendLine("Order Id,Order Priority,Order Date,Region,Country,Item Type,Sales Channel,Ship Date,Units Sold,Unit Price,Unit Cost,Total Revenue,Total Cost,Total Profit");
            var orders = await _orderRepository.GetOrdersFileAsync(cancellationToken);
            foreach (var order in _mapper.Map<IEnumerable<OrderDto>>(orders))
            {
                csv.AppendLine($"{order.Id},{order.Priority},{order.Date.ToString("dd/MM/yyyy")},{order.Region},{order.Country},{order.ItemType},{order.SalesChannel},{order.ShipDate.ToString("dd/MM/yyyy")}," +
                    $"{order.UnitsSold},{order.UnitPrice},{order.UnitCost},{order.TotalRevenue},{order.TotalCost},{order.TotalProfit}");
            }

            return new FileContentResult(Encoding.UTF8.GetBytes(csv.ToString()), "application/octet-stream")
            {
                FileDownloadName = "Orders.csv"
            };
        }
    }
}
