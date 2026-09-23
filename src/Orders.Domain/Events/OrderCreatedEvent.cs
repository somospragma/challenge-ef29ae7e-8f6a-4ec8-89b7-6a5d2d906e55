using System;

namespace Orders.Domain.Events
{
    public class OrderCreatedEvent : DomainEvent
    {
        public Guid OrderId { get; private set; }
        public Guid CustomerId { get; private set; }
        public IReadOnlyCollection<OrderItem> Items { get; private set; }

        public OrderCreatedEvent(Guid orderId, Guid customerId, IReadOnlyCollection<OrderItem> items)
        {
            if (orderId == Guid.Empty)
            {
                throw new ArgumentException("Order ID cannot be empty", nameof(orderId));
            }

            if (customerId == Guid.Empty)
            {
                throw new ArgumentException("Customer ID cannot be empty", nameof(customerId));
            }

            if (items == null ||!items.Any())
            {
                throw new ArgumentException("Items cannot be null or empty", nameof(items));
            }

            OrderId = orderId;
            CustomerId = customerId;
            Items = items;
        }
    }
}