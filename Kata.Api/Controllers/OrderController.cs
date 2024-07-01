using Kata.Api.Controllers.Base;
using Kata.Application.Order.Commands;
using Kata.Application.Order.Model;
using Kata.Application.Order.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kata.Api.Controllers
{
    [Route("[controller]")]
    public class OrderController : ApiControllerBase
    {
        public OrderController(IMediator mediator) : base(mediator) { }

        [HttpPost("import")]
        public async Task<OrderSummaryDto> ImportAsync(CancellationToken cancellationToken) => await Send(new ImportOrdersCommand(), cancellationToken);

        [HttpPost("export")]
        public async Task<IActionResult> ExportAsync(CancellationToken cancellationToken) => await Send(new GetOrdersFileQuery(), cancellationToken);
    }
}
