using Orders.Domain.Entities;
using Orders.Domain.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Orders.Application.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
        public List<OrderItem> Items { get; set; }

        public class Validator : AbstractValidator<CreateOrderCommand>
        {
            public Validator()
            {
                RuleFor(x => x.CustomerId).NotEmpty();
                RuleFor(x => x.Items).NotEmpty();
                RuleForEach(x => x.Items).SetValidator(new OrderItemValidator());
            }
        }
    }
}