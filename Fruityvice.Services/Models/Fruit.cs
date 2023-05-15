namespace Fruityvice.Services.Models
{
    /// <summary>
    /// Fruit class represents a fruit with various properties such as id, name, genus, family, order, and nutritions.
    /// </summary>
    public class Fruit
    {
        /// <summary>
        /// // Represents the unique id of the fruit.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///  Represents the name of the fruit.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents the genus of the fruit.
        /// </summary>
        public string Genus { get; set; }

        /// <summary>
        /// Represents the family of the fruit.
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// Represents the order of the fruit.
        /// </summary>
        public string Order { get; set; }

        /// <summary>
        ///  // Represents the nutritions information of the fruit.
        /// </summary>
        public Nutritions Nutritions { get; set; }
    }
}
