using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Orders.Application.Queries.GetOrderById;
using Orders.Domain.Entities;
using Orders.Domain.Interfaces;
using Xunit;

namespace Orders.Application.Tests.Queries
{
    public class GetOrderByIdQueryHandlerTests
    {
        private readonly Mock<IOrderQueryRepository> _mockOrderQueryRepository;
        private readonly GetOrderByIdQueryHandler _handler;

        public GetOrderByIdQueryHandlerTests()
        {
            _mockOrderQueryRepository = new Mock<IOrderQueryRepository>();
            _handler = new GetOrderByIdQueryHandler(_mockOrderQueryRepository.Object);
        }

        [Fact]
        public async Task Handle_ValidGetOrderByIdQuery_ReturnsOrder()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            var order = new Order(Guid.NewGuid(), new List<OrderItem> { new OrderItem(Guid.NewGuid(), "Product1", 10.0m, 1) });
            _mockOrderQueryRepository.Setup(repo => repo.GetByIdAsync(orderId, It.IsAny<CancellationToken>())).ReturnsAsync(order);

            var query = new GetOrderByIdQuery(orderId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(orderId, result.Id);
        }

        [Fact]
        public async Task Handle_InvalidGetOrderByIdQuery_ThrowsNotFoundException()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            _mockOrderQueryRepository.Setup(repo => repo.GetByIdAsync(orderId, It.IsAny<CancellationToken>())).ReturnsAsync((Order)null);

            var query = new GetOrderByIdQuery(orderId);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(query, CancellationToken.None));
        }
    }
}