using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartDockerRestAPI.Controllers;
using ShoppingCartDockerRestAPI.Models;
using ShoppingCartDockerRestAPI.Services;

namespace ShoppingCartDockerRestAPI.Tests
{
    
    public class ShoppingCartControllerTests
    {
        private readonly Mock<IShoppingCartService> _mockService;
        private readonly ShoppingCartController _controller;

        public ShoppingCartControllerTests()
        {
            _mockService = new Mock<IShoppingCartService>();
            _controller = new ShoppingCartController(_mockService.Object);
        }

        [Fact]
        public async Task GetShoppingCartItems_ReturnsOkResult_WithListOfItems()
        {
            var items = new List<ShoppingCartItem> { new ShoppingCartItem { Id = Guid.NewGuid(), ProductName = "Item1" } };
            _mockService.Setup(service => service.GetShoppingCartItems()).ReturnsAsync(items);

            var result = await _controller.GetShoppingCartItems();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnItems = Assert.IsType<List<ShoppingCartItem>>(okResult.Value);
            Assert.Single(returnItems);
        }

        [Fact]
        public async Task GetShoppingCartItem_ReturnsNotFound_WhenItemDoesNotExist()
        {
            _mockService.Setup(service => service.GetShoppingCartItemById(It.IsAny<Guid>()))
                .ReturnsAsync((ShoppingCartItem)null);

            var result = await _controller.GetShoppingCartItem(Guid.NewGuid());

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task AddShoppingCartItem_ReturnsCreatedAtActionResult_WithNewItem()
        {
            var newItem = new ShoppingCartItem { Id = Guid.NewGuid(), ProductName = "NewItem" };
            _mockService.Setup(service => service.AddShoppingCartItem(It.IsAny<ShoppingCartItem>()));

            var result = await _controller.AddShoppingCartItem(newItem);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnItem = Assert.IsType<ShoppingCartItem>(createdAtActionResult.Value);
            Assert.Equal(newItem.Id, returnItem.Id);
        }

        [Fact]
        public async Task UpdateShoppingCartItem_ReturnsNoContent_WhenUpdateIsSuccessful()
        {
            var existingItem = new ShoppingCartItem { Id = Guid.NewGuid(), ProductName = "ExistingItem" };
            _mockService
                .Setup(service => service.UpdateShoppingCartItem(It.IsAny<Guid>(), It.IsAny<ShoppingCartItem>()));

            var result = await _controller.UpdateShoppingCartItem(existingItem.Id, existingItem);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteShoppingCartItem_ReturnsNoContent_WhenDeleteIsSuccessful()
        {
            _mockService.Setup(service => service.DeleteShoppingCartItem(It.IsAny<Guid>())).ReturnsAsync(true);

            var result = await _controller.DeleteShoppingCartItem(Guid.NewGuid());

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteShoppingCartItem_ReturnsNotFound_WhenItemDoesNotExist()
        {
            _mockService.Setup(service => service.DeleteShoppingCartItem(It.IsAny<Guid>())).ReturnsAsync(false);

            var result = await _controller.DeleteShoppingCartItem(Guid.NewGuid());

            Assert.IsType<NotFoundResult>(result);
        }
    }
}