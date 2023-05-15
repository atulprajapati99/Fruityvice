using Fruityvice.API.Controllers;
using Fruityvice.API.Requests;
using Fruityvice.Services.Interface;
using Fruityvice.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Fruityvice.UnitTests
{
    public class FruitsControllerTests
    {
        private readonly Mock<IFruitService> _mockFruitService;
        private readonly FruitsController _fruitsController;

        public FruitsControllerTests()
        {
            _mockFruitService = new Mock<IFruitService>();
            _fruitsController = new FruitsController(_mockFruitService.Object);
        }

        [Fact]
        public async Task GetAllFruitsAsync_ReturnsOkResult_WithListOfFruits()
        {
            // Arrange
            var fruits = new List<Fruit>
            {
                new Fruit { Id = 1, Name = "Apple", Family = "Rosaceae", Genus = "Malus", Order = "Rosales" },
                new Fruit { Id = 2, Name = "Banana", Family = "Musaceae", Genus = "Musa", Order = "Zingiberales" }
            };

            _mockFruitService.Setup(x => x.GetAllFruitsAsync()).ReturnsAsync(fruits);

            // Act
            var result = await _fruitsController.GetAllFruitsAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var fruitsResult = Assert.IsAssignableFrom<IEnumerable<Fruit>>(okResult.Value);
            Assert.Equal(fruits.Count(), fruitsResult.Count());
        }

        [Fact]
        public async Task GetFruitsByFamilyAsync_WithValidFruiteFamily_ReturnsOkResult_WithListOfMatchingFruits()
        {
            // Arrange
            var family = "Rosaceae";
            var fruits = new List<Fruit>
            {
                new Fruit { Id = 1, Name = "Apple", Family = "Rosaceae", Genus = "Malus", Order = "Rosales" },
                new Fruit { Id = 2, Name = "Banana", Family = "Musaceae", Genus = "Musa", Order = "Zingiberales" }
            };

            _mockFruitService.Setup(x => x.GetFruitsByFamilyAsync(family)).ReturnsAsync(fruits.Where(x => x.Family == family));

            var request = new FruiteRequest { FruiteFamily = family };

            // Act
            var result = await _fruitsController.GetFruitsByFamilyAsync(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var fruitsResult = Assert.IsAssignableFrom<IEnumerable<Fruit>>(okResult.Value);
            Assert.Equal(fruits.Count(f => f.Family == family), fruitsResult.Count());
            Assert.All(fruitsResult, r => Assert.Equal(family, r.Family));
        }

        [Fact]
        public async Task GetFruitsByFamilyAsync_WithInvalidFruiteFamily_ReturnsNotFoundResult()
        {
            // Arrange
            var family = "InvalidFamily";

            _mockFruitService.Setup(x => x.GetFruitsByFamilyAsync(family)).ReturnsAsync((IEnumerable<Fruit>)null);

            var request = new FruiteRequest { FruiteFamily = family };

            // Act
            var result = await _fruitsController.GetFruitsByFamilyAsync(request);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
