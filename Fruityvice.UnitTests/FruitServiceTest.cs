using Fruityvice.Services.Interface;
using Fruityvice.Services.Models;
using Fruityvice.Services.Services;
using Moq;

namespace Fruityvice.UnitTests
{
    public class FruitServiceTest
    {
        private readonly Mock<IFruityviceApiClient> _mockFruityviceApiClient;
        private readonly FruitService _fruitService;

        public FruitServiceTest()
        {
            _mockFruityviceApiClient = new Mock<IFruityviceApiClient>();
            _fruitService = new FruitService(_mockFruityviceApiClient.Object);
        }

        [Fact]
        public async Task GetAllFruitsAsync_ShouldReturnListOfFruits()
        {
            // Arrange
            var fruits = new List<Fruit>
            {
                new Fruit { Id = 1, Name = "Apple", Family = "Rosaceae", Genus = "Malus", Order = "Rosales" },
                new Fruit { Id = 2, Name = "Banana", Family = "Musaceae", Genus = "Musa", Order = "Zingiberales" }
            };

            var mockApiClient = new Mock<IFruityviceApiClient>();
            mockApiClient.Setup(x => x.GetAllFruitsAsync()).ReturnsAsync(fruits);

            var fruitService = new FruitService(mockApiClient.Object);

            // Act
            var result = await fruitService.GetAllFruitsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(fruits.Count, result.Count());
            Assert.Equal(fruits, result);
        }

        [Fact]
        public async Task GetFruitsByFamilyAsync_ShouldReturnListOfMatchingFruits()
        {
            // Arrange
            var family = "Rosaceae";

            var fruits = new List<Fruit>
            {
                new Fruit { Id = 1, Name = "Apple", Family = "Rosaceae", Genus = "Malus", Order = "Rosales" },
                new Fruit { Id = 2, Name = "Banana", Family = "Musaceae", Genus = "Musa", Order = "Zingiberales" }
            };

            _mockFruityviceApiClient.Setup(x => x.GetFruitsByFamilyAsync(family)).ReturnsAsync(fruits.Where(x => x.Family == family));

            // Act
            var result = await _fruitService.GetFruitsByFamilyAsync(family);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(fruits.Count(f => f.Family == family), result.Count());
            Assert.All(result, r => Assert.Equal(family, r.Family));
        }
    }
}
