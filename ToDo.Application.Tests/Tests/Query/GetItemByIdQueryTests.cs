using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Application.Interfaces;
using ToDo.Application.Queries.GetItemById;
using ToDo.Domain.Entities;
using Xunit;

namespace ToDo.Application.Tests.Tests.Query
{
    public class GetItemByIdQueryTests
    {
        private readonly GetItemByIdForUpdateQueryHandler _handler;
        private readonly Mock<IItemRepository> _mock;

        public GetItemByIdQueryTests()
        {
            _handler = new GetItemByIdForUpdateQueryHandler(_mock.Object);
            _mock = new Mock<IItemRepository>();
        }

        [Fact]
        public async Task Handle_Should_Return_Item_When_Exists()
        {
            var item = new Item { Id = 1, Name = "Test",IsActive=false,IsComplete=true };

            _mock.Setup(x => x.GetItemByIdAsync(1))
                     .ReturnsAsync(item);

            var result = await _handler.Handle(new GetItemByIdForUpdateQuery(1), CancellationToken.None);

            result.Should().NotBeNull();
            result!.Id.Should().Be(1);
            result.Name.Should().Be("Test");
        }

    }
}
