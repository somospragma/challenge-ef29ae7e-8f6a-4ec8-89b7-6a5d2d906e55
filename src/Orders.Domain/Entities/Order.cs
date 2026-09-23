using System;
using System.Collections.Generic;
using FluentValidation;

namespace Orders.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public DateTime OrderDate { get; private set; }
    public OrderStatus Status { get; private set; }
    public decimal TotalAmount { get; private set; }
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
    private readonly List<OrderItem> _items = new();

    public Order(Guid customerId, IEnumerable<OrderItem> items)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        OrderDate = DateTime.UtcNow;
        Status = OrderStatus.Pending;

        var itemList = items.ToList();
        if (!itemList.Any())
            throw new ArgumentException("An order must have at least one item.", nameof(items));

        _items.AddRange(itemList);
        TotalAmount = _items.Sum(i => i.Price * i.Quantity);
    }

    public void MarkAsPaid()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Only pending orders can be marked as paid.");
        Status = OrderStatus.Paid;
    }

    public void MarkAsShipped()
    {
        if (Status != OrderStatus.Paid)
            throw new InvalidOperationException("Only paid orders can be marked as shipped.");
        Status = OrderStatus.Shipped;
    }

    public void MarkAsCancelled()
    {
        if (Status == OrderStatus.Shipped)
            throw new InvalidOperationException("Shipped orders cannot be cancelled.");
        Status = OrderStatus.Cancelled;
    }

    public void AddItem(OrderItem item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        _items.Add(item);
        TotalAmount = _items.Sum(i => i.Price * i.Quantity);
    }

    public void RemoveItem(Guid productId)
    {
        var item = _items.FirstOrDefault(i => i.ProductId == productId);
        if (item == null) throw new KeyNotFoundException("Item not found in order.");
        _items.Remove(item);
        TotalAmount = _items.Sum(i => i.Price * i.Quantity);
    }
}

public class OrderItem
{
    public Guid ProductId { get; }
    public string ProductName { get; }
    public decimal Price { get; }
    public int Quantity { get; }

    public OrderItem(Guid productId, string productName, decimal price, int quantity)
    {
        ProductId = productId;
        ProductName = productName ?? throw new ArgumentNullException(nameof(productName));
        Price = price > 0 ? price : throw new ArgumentException("Price must be positive.", nameof(price));
        Quantity = quantity > 0 ? quantity : throw new ArgumentException("Quantity must be positive.", nameof(quantity));
    }
}

public enum OrderStatus
{
    Pending,
    Paid,
    Shipped,
    Cancelled
}

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(o => o.CustomerId).NotEmpty();
        RuleFor(o => o.Items).NotEmpty().WithMessage("An order must have at least one item.");
        RuleForEach(o => o.Items).SetValidator(new OrderItemValidator());
    }
}

public class OrderItemValidator : AbstractValidator<OrderItem>
{
    public OrderItemValidator()
    {
        RuleFor(i => i.ProductId).NotEmpty();
        RuleFor(i => i.ProductName).NotEmpty().MaximumLength(100);
        RuleFor(i => i.Price).GreaterThan(0);
        RuleFor(i => i.Quantity).GreaterThan(0);
    }
}