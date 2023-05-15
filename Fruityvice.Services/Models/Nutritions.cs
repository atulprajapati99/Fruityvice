namespace Fruityvice.Services.Models
{
    /// <summary>
    /// Nutritions class represents the nutritional information of a fruit with properties such as carbohydrates, protein, fat, calories, and sugar.
    /// </summary>
    public class Nutritions
    {
        /// <summary>
        ///  Represents the amount of carbohydrates in the fruit.
        /// </summary>
        public double Carbohydrates { get; set; }

        /// <summary>
        /// Represents the amount of protein in the fruit.
        /// </summary>
        public double Protein { get; set; }

        /// <summary>
        ///  Represents the amount of fat in the fruit.
        /// </summary>
        public double Fat { get; set; }

        /// <summary>
        ///  Represents the amount of calories in the fruit.
        /// </summary>
        public int Calories { get; set; }

        /// <summary>
        ///  Represents the amount of sugar in the fruit.
        /// </summary>
        public double Sugar { get; set; }
    }
}
