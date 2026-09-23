using MediatR;
using Orders.Domain.Entities;
using Orders.Domain.Interfaces;
using Orders.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Orders.Application.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderCommandRepository _orderCommandRepository;
        private readonly IValidator<Order> _orderValidator;

        public CreateOrderCommandHandler(IOrderCommandRepository orderCommandRepository, IValidator<Order> orderValidator)
        {
            _orderCommandRepository = orderCommandRepository;
            _orderValidator = orderValidator;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(request.CustomerId, request.Items);
            var validationResult = await _orderValidator.ValidateAsync(order, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            await _orderCommandRepository.AddAsync(order, cancellationToken);
            return order.Id;
        }
    }
}