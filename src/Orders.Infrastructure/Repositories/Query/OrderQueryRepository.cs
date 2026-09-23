using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;
using Orders.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Repositories.Query
{
    public class OrderQueryRepository : IOrderQueryRepository
    {
        private readonly OrdersQueryDbContext _context;

        public OrderQueryRepository(OrdersQueryDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Orders
               .Include(o => o.Items)
               .SingleOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default)
        {
            return await _context.Orders
               .Include(o => o.Items)
               .Where(o => o.CustomerId == customerId)
               .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetByStatusAsync(OrderStatus status, CancellationToken cancellationToken = default)
        {
            return await _context.Orders
               .Include(o => o.Items)
               .Where(o => o.Status == status)
               .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            return await _context.Orders
               .Include(o => o.Items)
               .Where(o => o.CreationDate >= startDate && o.CreationDate <= endDate)
               .ToListAsync(cancellationToken);
        }

        public async Task<PagedResult<Order>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var skip = (pageNumber - 1) * pageSize;
            var orders = await _context.Orders
               .Include(o => o.Items)
               .Skip(skip)
               .Take(pageSize)
               .ToListAsync(cancellationToken);
            var totalCount = await _context.Orders.CountAsync(cancellationToken);
            return new PagedResult<Order>(orders, totalCount, pageNumber, pageSize);
        }
    }
}