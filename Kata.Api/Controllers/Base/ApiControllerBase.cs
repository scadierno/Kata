using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kata.Api.Controllers.Base
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;
        public ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected virtual async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(request, cancellationToken);
        }
    }
}