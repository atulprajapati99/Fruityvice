using Fruityvice.Services.Interface;
using Fruityvice.Services.Models;

namespace Fruityvice.Services.Services
{
    public class FruitService : IFruitService
    {
        private readonly IFruityviceApiClient _apiClient;

        public FruitService(IFruityviceApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        /// Retrieves all the fruits from the Fruityvice API client.
        /// </summary>
        /// <returns>Task<IEnumerable<Fruit>> - A collection of Fruit objects returned as an asynchronous operation.</returns>
        public async Task<IEnumerable<Fruit>> GetAllFruitsAsync()
        {
            return await _apiClient.GetAllFruitsAsync();
        }

        /// <summary>
        /// Retrieves all the fruits with a specified family from the Fruityvice API client.
        /// </summary>
        /// <param name="fruitFamily"></param>
        /// <returns>Task<IEnumerable<Fruit>> - A collection of Fruit objects returned as an asynchronous operation.</returns>
        public async Task<IEnumerable<Fruit>> GetFruitsByFamilyAsync(string fruitFamily)
        {
            return await _apiClient.GetFruitsByFamilyAsync(fruitFamily);
        }
    }
}
