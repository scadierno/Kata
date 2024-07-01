namespace Kata.Application.Order.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Kata.Domain.Entities.Order>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Kata.Domain.Entities.Order>> GetOrdersFileAsync(CancellationToken cancellationToken);
        Task InsertAsync(IEnumerable<Kata.Domain.Entities.Order> entities, CancellationToken cancellationToken);
    }
}
