using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Orders.Application.Commands.CreateOrder;
using Orders.Domain.Entities;
using Orders.Domain.Interfaces;
using Xunit;

namespace Orders.Application.Tests.Commands
{
    public class CreateOrderCommandHandlerTests
    {
        private readonly Mock<IOrderCommandRepository> _mockOrderCommandRepository;
        private readonly CreateOrderCommandHandler _handler;

        public CreateOrderCommandHandlerTests()
        {
            _mockOrderCommandRepository = new Mock<IOrderCommandRepository>();
            _handler = new CreateOrderCommandHandler(_mockOrderCommandRepository.Object);
        }

        [Fact]
        public async Task Handle_ValidCreateOrderCommand_AddsOrderToRepository()
        {
            // Arrange
            var command = new CreateOrderCommand(Guid.NewGuid(), new List<OrderItem> { new OrderItem(Guid.NewGuid(), "Product1", 10.0m, 1) });

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mockOrderCommandRepository.Verify(repo => repo.AddAsync(It.IsAny<Order>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidCreateOrderCommand_ThrowsValidationException()
        {
            // Arrange
            var command = new CreateOrderCommand(Guid.Empty, new List<OrderItem> { new OrderItem(Guid.Empty, "", 0.0m, 0) });

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}