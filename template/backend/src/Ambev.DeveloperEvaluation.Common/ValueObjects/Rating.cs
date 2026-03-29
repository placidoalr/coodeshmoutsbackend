namespace Ambev.DeveloperEvaluation.Common.ValueObjects
{
    /// <summary>
    /// Representa a avaliação de um produto.
    /// </summary>
    public class Rating
    {
        /// <summary>
        /// Nota média atribuída ao produto.
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// Quantidade de avaliações recebidas.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Initializes a new instance of the Rating class with default values.
        /// </summary>
        public Rating()
        {
            Rate = 0;
            Count = 0;
        }

        /// <summary>
        /// Initializes a new instance of the Rating class with specified rate and count.
        /// </summary>
        /// <param name="rate">The rating value.</param>
        /// <param name="count">The count of ratings.</param>
        public Rating(decimal rate, int count)
        {
            Rate = rate;
            Count = count;
        }
    }
}
