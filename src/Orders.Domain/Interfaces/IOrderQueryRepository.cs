using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Orders.Domain.Entities;

namespace Orders.Domain.Interfaces;

public interface IOrderQueryRepository
{
    Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Order>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Order>> GetByStatusAsync(OrderStatus status, CancellationToken cancellationToken = default);
    Task<IEnumerable<Order>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    Task<PagedResult<Order>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
}

public class PagedResult<T>
{
    public IEnumerable<T> Items { get; }
    public int TotalCount { get; }
    public int PageNumber { get; }
    public int PageSize { get; }

    public PagedResult(IEnumerable<T> items, int totalCount, int pageNumber, int pageSize)
    {
        Items = items ?? throw new ArgumentNullException(nameof(items));
        TotalCount = totalCount;
        PageNumber = pageNumber > 0 ? pageNumber : throw new ArgumentException("Page number must be positive.", nameof(pageNumber));
        PageSize = pageSize > 0 ? pageSize : throw new ArgumentException("Page size must be positive.", nameof(pageSize));
    }
}