using Fruityvice.Services.Models;

namespace Fruityvice.Services.Interface
{
    public interface IFruitService
    {
        Task<IEnumerable<Fruit>> GetAllFruitsAsync();
        Task<IEnumerable<Fruit>> GetFruitsByFamilyAsync(string fruitFamily);
    }
}
