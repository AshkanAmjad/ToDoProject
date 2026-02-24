using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ToDo.Application.Commands.CreateOrUpdate;
using ToDo.Application.Commands.Delete;
using ToDo.Application.DTOs;
using ToDo.Application.Interfaces;
using ToDo.Application.Queries.GetAllItems;
using ToDo.Presentation.Controllers;

public class HomeControllerTests
{
    private readonly Mock<IMediator> _mockMediator;
    private readonly Mock<IItemRepository> _mockRepo;
    private readonly HomeController _controller;

    public HomeControllerTests()
    {
        _mockMediator = new Mock<IMediator>();
        _mockRepo = new Mock<IItemRepository>();
        _controller = new HomeController(_mockRepo.Object, _mockMediator.Object);
    }

    [Fact]
    public async Task Index_Should_Return_View_With_Model()
    {
        var fakeList = new List<GetItemsDto>
        {
            new GetItemsDto { Id = 1, Name = "Test",IsComplete=false,IsActive=true }
        };

        _mockMediator
            .Setup(x => x.Send(It.IsAny<GetAllItemsQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeList);

        var result = await _controller.Index();

        var viewResult = result as ViewResult;

        viewResult.Should().NotBeNull();
        viewResult!.Model.Should().BeEquivalentTo(fakeList);

        _mockMediator.Verify(
            x => x.Send(It.IsAny<GetAllItemsQuery>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task CreateOrUpdate_Post_Should_Redirect_When_Success()
    {
        var dto = new CreateOrUpdateDto();

        _mockMediator
            .Setup(x => x.Send(It.IsAny<CreateOrUpdateCommand>(), default))
            .ReturnsAsync(true);

        var result = await _controller.CreateOrUpdateAsync(dto);

        var redirectResult = result as RedirectResult;

        redirectResult.Should().NotBeNull();
        redirectResult!.Url.Should().Be("/");

        _mockMediator.Verify(
            x => x.Send(It.IsAny<CreateOrUpdateCommand>(), default),
            Times.Once);
    }

    [Fact]
    public async Task CreateOrUpdate_Post_Should_Return_View_When_Fail()
    {
        var dto = new CreateOrUpdateDto();

        _mockMediator
            .Setup(x => x.Send(It.IsAny<CreateOrUpdateCommand>(), default))
            .ReturnsAsync(false);

        var result = await _controller.CreateOrUpdateAsync(dto);

        var viewResult = result as ViewResult;

        viewResult.Should().NotBeNull();
        viewResult!.Model.Should().Be(dto);
    }

    [Fact]
    public async Task Delete_Should_Redirect_To_Index()
    {
        _mockMediator
            .Setup(x => x.Send(It.IsAny<DeleteCommand>(), default))
            .ReturnsAsync(true);

        var result = await _controller.DeleteAsync(1);

        var redirect = result as RedirectToActionResult;

        redirect.Should().NotBeNull();
        redirect!.ActionName.Should().Be("Index");

        _mockMediator.Verify(
            x => x.Send(It.IsAny<DeleteCommand>(), default),
            Times.Once);
    }

    [Fact]
    public async Task CreateOrUpdate_Post_Should_Return_View_When_Failed()
    {
        var dto = new CreateOrUpdateDto();

        _mockMediator
            .Setup(x => x.Send(It.IsAny<CreateOrUpdateCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var result = await _controller.CreateOrUpdateAsync(dto);

        var viewResult = result as ViewResult;

        viewResult.Should().NotBeNull();
        viewResult!.Model.Should().Be(dto);

        _mockMediator.Verify(
            x => x.Send(It.IsAny<CreateOrUpdateCommand>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task CreateOrUpdate_Post_Should_Return_View_When_Exception_Thrown()
    {
        var dto = new CreateOrUpdateDto();

        _mockMediator
            .Setup(x => x.Send(It.IsAny<CreateOrUpdateCommand>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("DB Error"));

        var result = await _controller.CreateOrUpdateAsync(dto);

        var viewResult = result as ViewResult;

        viewResult.Should().NotBeNull();
        viewResult!.Model.Should().Be(dto);

        _mockMediator.Verify(
            x => x.Send(It.IsAny<CreateOrUpdateCommand>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task CreateOrUpdate_Get_Should_Return_Empty_Model_When_Id_Is_Null()
    {
        var result = await _controller.CreateOrUpdateAsync((int?)null);

        var viewResult = result as ViewResult;

        viewResult.Should().NotBeNull();
        viewResult!.Model.Should().NotBeNull();
    }

}