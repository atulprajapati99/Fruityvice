using Fruityvice.Services.Interface;
using Fruityvice.Services.Models;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;

namespace Fruityvice.Services.ApiClient
{
    /// <summary>
    /// A client to access Fruityvice API endpoints.
    /// </summary>
    public class FruityviceApiClient : IFruityviceApiClient
    {
        private readonly HttpClient _httpClient;
        /// <summary>
        /// Initializes a new instance of the <see cref="FruityviceApiClient"/> class.
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public FruityviceApiClient(IHttpClientFactory httpClientFactory, IOptions<Settings> options)
        {
            _httpClient = httpClientFactory.CreateClient("Fruite");
            _httpClient.BaseAddress = new Uri(options.Value.ApiURL.BaseUrl);
            _httpClient.Timeout = TimeSpan.FromSeconds(30);           
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Fruit>> GetAllFruitsAsync()
        {
            var response = await _httpClient.GetAsync($"{ApiConstants.FruitEndpoint}");
            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get All Fruits: {response.StatusCode}");
            }

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var responseStream = await response.Content.ReadAsStreamAsync();
            var fruits = await JsonSerializer.DeserializeAsync<List<Fruit>>(responseStream, options: options);
            return fruits;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Fruit>> GetFruitsByFamilyAsync(string fruitFamily)
        {
            var response = await _httpClient.GetAsync($"{ApiConstants.FruitFamilyEndpoint}/{fruitFamily}");
            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get Fruits by family: {response.StatusCode}");
            }

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var responseStream = await response.Content.ReadAsStreamAsync();
            var fruits = await JsonSerializer.DeserializeAsync<List<Fruit>>(responseStream, options: options);
            return fruits;
        }
    }
}
