using Kata.Application.Order.Model;

namespace Kata.Application.Order.Interfaces
{
    public interface IOrderHttpClient
    {
        Task<OrderResponseDto> GetOrdersAsync(CancellationToken cancellationToken);
    }
}
