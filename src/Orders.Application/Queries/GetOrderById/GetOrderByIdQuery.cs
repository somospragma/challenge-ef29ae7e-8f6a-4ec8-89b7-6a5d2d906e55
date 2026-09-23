using MediatR;
using Orders.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Orders.Application.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public Guid Id { get; set; }
    }

    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IOrderQueryRepository _orderQueryRepository;

        public GetOrderByIdQueryHandler(IOrderQueryRepository orderQueryRepository)
        {
            _orderQueryRepository = orderQueryRepository;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderQueryRepository.GetByIdAsync(request.Id, cancellationToken);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            return order;
        }
    }
}