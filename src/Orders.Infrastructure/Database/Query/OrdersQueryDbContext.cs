using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;
using Orders.Domain.Interfaces;

namespace Orders.Infrastructure.Database.Query
{
    public class OrdersQueryDbContext : DbContext, IOrderQueryRepository
    {
        public OrdersQueryDbContext(DbContextOptions<OrdersQueryDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        public async Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await Orders.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default)
        {
            return await Orders.Where(o => o.CustomerId == customerId).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetByStatusAsync(OrderStatus status, CancellationToken cancellationToken = default)
        {
            return await Orders.Where(o => o.Status == status).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            return await Orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate).ToListAsync(cancellationToken);
        }

        public async Task<PagedResult<Order>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var orders = await Orders.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
            var totalCount = await Orders.CountAsync(cancellationToken);
            return new PagedResult<Order>(orders, totalCount, pageNumber, pageSize);
        }
    }
}