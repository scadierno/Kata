using Kata.Application.Order.Interfaces;
using Kata.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kata.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;
        public OrderRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken) => await _context.Orders.ToListAsync(cancellationToken);

        public async Task<IEnumerable<Order>> GetOrdersFileAsync(CancellationToken cancellationToken) => await _context.Orders.OrderBy(o => o.Id).ToListAsync(cancellationToken);

        public async Task InsertAsync(IEnumerable<Kata.Domain.Entities.Order> entities, CancellationToken cancellationToken)
        {
            await _context.Orders.AddRangeAsync(entities, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
