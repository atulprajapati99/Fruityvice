using Fruityvice.Services.Models;

namespace Fruityvice.Services.Interface
{
    public interface IFruityviceApiClient
    {
        /// <summary>
        /// Returns all the available fruits.
        /// </summary>
        /// <returns>A collection of <see cref="Fruit"/> objects representing all the available fruits.</returns>
        Task<IEnumerable<Fruit>> GetAllFruitsAsync();

        /// <summary>
        /// Returns all the fruits that belong to the specified family.
        /// </summary>
        /// <param name="fruitFamily">The name of the fruit family.</param>
        /// <returns>A collection of <see cref="Fruit"/> objects representing all the fruits that belong to the specified family.</returns>
        Task<IEnumerable<Fruit>> GetFruitsByFamilyAsync(string fruitFamily);
    }
}
